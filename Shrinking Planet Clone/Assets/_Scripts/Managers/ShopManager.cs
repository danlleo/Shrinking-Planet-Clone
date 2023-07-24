using System;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public event EventHandler OnItemBought;
    public event EventHandler OnItemFailedPurchase;

    [SerializeField] private List<PurchasableItem> _purchasableItemList;

    private PurchasableItem _selectedPurchasableItem;
    private int _selectedItemPrice;

    protected override void Awake()
    {
        base.Awake();
    }

    public bool TryPurchaseItem(PurchasableItem purchaseItem, out Action resultAction)
    {
        if (purchaseItem.Price > EconomyManager.Instance.GetTotalCurrentMoneyAmount())
        {
            resultAction = Failed;
            return false;
        }

        if (ItemStashManager.Instance.HasPurchasedItem(purchaseItem.ID))
        {
            resultAction = Failed;
            return false;
        }

        _selectedPurchasableItem = purchaseItem;
        _selectedItemPrice = purchaseItem.Price;
        resultAction = Success;

        return true;
    }

    public IEnumerable<PurchasableItem> GetPurchasableItemList() => _purchasableItemList;

    private void Failed()
    {
        OnItemFailedPurchase?.Invoke(this, EventArgs.Empty);
    }

    private void Success()
    {
        EconomyManager.Instance.SubstractCurrentMoneyAmountBy(_selectedItemPrice);
        OnItemBought?.Invoke(this, EventArgs.Empty);
        ItemStashManager.Instance.AddPurchasedItem(_selectedPurchasableItem);
    }
}
