using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyItemUISingle : MonoBehaviour, IPurchasable, IPointerClickHandler
{
    public static event EventHandler<BuyItemClickArgs> OnBuyItemClick;

    public class BuyItemClickArgs : EventArgs
    {
        public PurchasableItem PurchasableItemArgs;

        public BuyItemClickArgs(PurchasableItem purchasableItem)
        {
            PurchasableItemArgs = purchasableItem;
        }
    }

    [SerializeField] private Image _iconImage;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;

    private PurchasableItem _purchasableItem;

    private void OnDestroy()
    {
        ShopManager.Instance.OnItemBought -= ShopManager_OnItemBought;
    }

    public void Initialize(PurchasableItem purchasableItem)
    {
        ShopManager.Instance.OnItemBought += ShopManager_OnItemBought;
        
        _iconImage.sprite = purchasableItem.Icon;
        _titleText.text = purchasableItem.Title;
        _descriptionText.text = purchasableItem.Description;
        _purchasableItem = purchasableItem;
    }

    private void ShopManager_OnItemBought(object sender, ShopManager.BoughtItemEventArgs e)
    {
        if (_purchasableItem.Title == e.PurchasedItem.Title)
            Destroy(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Purchase();
    }

    public void Purchase()
    {
        OnBuyItemClick?.Invoke(this, new BuyItemClickArgs(_purchasableItem));
    }
}
