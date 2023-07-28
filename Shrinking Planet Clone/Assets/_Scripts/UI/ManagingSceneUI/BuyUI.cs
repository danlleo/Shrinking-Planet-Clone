using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyUI : MonoBehaviour
{
    public static event EventHandler OnOpenBuyUIClose;

    [SerializeField] private GameObject _buyUI;
    [SerializeField] private Transform _containerParent;
    [SerializeField] private BuyItemUISingle _buyItemUIPrefab;
    [SerializeField] private TextMeshProUGUI _moneyAmountText;
    [SerializeField] private TextMeshProUGUI _ownEverythingText;
    [SerializeField] private Button _closeButton;

    private List<PurchasableItem> _displayedPurchasableItemList = new();

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
        ShopManager.Instance.OnItemBought += ShopManager_OnItemBought;

        IEnumerable<PurchasableItem> buyItemList = ShopManager.Instance.GetPurchasableItemList();

        foreach (PurchasableItem purchasableItem in buyItemList)
        {
            if (ShopManager.Instance.HasBoughtItem(purchasableItem))
                continue;

            BuyItemUISingle spawnedBuyItem = Instantiate(_buyItemUIPrefab, _containerParent);
            spawnedBuyItem.Initialize(purchasableItem);
            _displayedPurchasableItemList.Add(purchasableItem);
        }
        
        UpdateMoneyAmountText(SaveGameManager.Instance.GetMoneyAmount());

        if (_displayedPurchasableItemList.Count == 0)
            DisplayOwnEverythingText();
    }

    private void OnDestroy()
    {
        ManagingUI.OnOpenBuyUI -= ManagingUI_OnOpenBuyUI;
        ShopManager.Instance.OnItemBought -= ShopManager_OnItemBought;
    }

    private void ShopManager_OnItemBought(object sender, ShopManager.BoughtItemEventArgs e)
    {
        UpdateMoneyAmountText(EconomyManager.Instance.GetTotalCurrentMoneyAmount());

        _displayedPurchasableItemList.Remove(e.PurchasedItem);
        
        if (_displayedPurchasableItemList.Count == 0)
            DisplayOwnEverythingText();
    }

    private void ManagingUI_OnOpenBuyUI(object sender, EventArgs e)
    {
        ShowUI();
    }

    private void DisplayOwnEverythingText() => _ownEverythingText.gameObject.SetActive(true);
    
    private void UpdateMoneyAmountText(int moneyAmount) => _moneyAmountText.text = $"{moneyAmount}";

    private void ShowUI() => _buyUI.SetActive(true);

    private void HideUI() => _buyUI.SetActive(false);
}
