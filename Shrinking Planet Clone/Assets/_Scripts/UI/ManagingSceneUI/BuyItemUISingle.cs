using System;
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

    private int _price;

    public void Initialize(PurchasableItem purchasableItem)
    {
        _iconImage.sprite = purchasableItem.Icon;
        _titleText.text = purchasableItem.Title;
        _descriptionText.text = purchasableItem.Description;
        _price = purchasableItem.Price;
        _purchasableItem = purchasableItem;
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
