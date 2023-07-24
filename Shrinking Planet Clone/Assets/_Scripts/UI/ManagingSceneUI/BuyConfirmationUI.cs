using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static BuyItemUISingle;

public class BuyConfirmationUI : MonoBehaviour
{
    [SerializeField] private GameObject _buyConfirmationUI;
    [SerializeField] private TextMeshProUGUI _priceAmountText;
    [SerializeField] private Button _confirmButton;
    [SerializeField] private Button _declineButton;

    private PurchasableItem _purchasableItem;

    private void Awake()
    {
        HideUI();

        _declineButton.onClick.AddListener(() =>
        {
            HideUI();
        });

        _confirmButton.onClick.AddListener(() =>
        {
            ShopManager.Instance.TryPurchaseItem(_purchasableItem, out Action resultAction);
            resultAction?.Invoke();
        });
    }

    private void Start()
    {
        OnBuyItemClick += BuyItemUISingle_OnBuyItemClick;
        ShopManager.Instance.OnItemBought += ShopManager_OnItemBought;
    }

    private void OnDestroy()
    {
        OnBuyItemClick -= BuyItemUISingle_OnBuyItemClick;
        ShopManager.Instance.OnItemBought -= ShopManager_OnItemBought;
    }

    private void ShopManager_OnItemBought(object sender, EventArgs e)
    {
        HideUI();
    }

    private void Initialize(PurchasableItem purchasableItem)
    {
        _purchasableItem = purchasableItem;
        _priceAmountText.text = $"{_purchasableItem.Price}";
    }

    private void BuyItemUISingle_OnBuyItemClick(object sender, BuyItemClickArgs e)
    {
        ShowUI();
        Initialize(e.PurchasableItemArgs);
    }

    private void ShowUI() => _buyConfirmationUI.SetActive(true);

    private void HideUI() => _buyConfirmationUI.SetActive(false);
}
