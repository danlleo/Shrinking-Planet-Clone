using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUI : MonoBehaviour
{
    public static event EventHandler OnOpenBuyUIClose;

    [SerializeField] private GameObject _buyUI;
    [SerializeField] private Transform _containerParent;
    [SerializeField] private BuyItemUISingle _buyItemUIPrefab;
    [SerializeField] private Button _closeButton;

    private void Awake()
    {
        _closeButton.onClick.AddListener(() =>
        {
            HideUI();
            OnOpenBuyUIClose?.Invoke(this, EventArgs.Empty);
        });
    }

    private void Start()
    {
        ManagingUI.OnOpenBuyUI += ManagingUI_OnOpenBuyUI;

        IEnumerable<PurchasableItem> buyItemList = ShopManager.Instance.GetPurchasableItemList();

        foreach (PurchasableItem purchasableItem in buyItemList)
        {
            BuyItemUISingle spawnedBuyItem = Instantiate(_buyItemUIPrefab, _containerParent);
            spawnedBuyItem.Initialize(purchasableItem.Icon, purchasableItem.Title, purchasableItem.Description);
        }
    }

    private void OnDestroy()
    {
        ManagingUI.OnOpenBuyUI -= ManagingUI_OnOpenBuyUI;
    }

    private void ManagingUI_OnOpenBuyUI(object sender, System.EventArgs e)
    {
        ShowUI();
    }

    private void ShowUI() => _buyUI.SetActive(true);

    private void HideUI() => _buyUI.SetActive(false);
}
