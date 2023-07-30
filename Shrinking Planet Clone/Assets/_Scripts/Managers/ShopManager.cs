using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public event EventHandler<BoughtItemEventArgs> OnItemBought;

    public class BoughtItemEventArgs : EventArgs
    {
        public PurchasableItem PurchasedItem;

        public BoughtItemEventArgs(PurchasableItem purchasedItem)
        {
            PurchasedItem = purchasedItem;
        }
    }

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

    public bool HasBoughtItem(PurchasableItem purchaseItem) => SaveGameManager.Instance.RetrievePurchasedItems().Contains(purchaseItem);

    private void Failed()
    {
        OnItemFailedPurchase?.Invoke(this, EventArgs.Empty);
    }

    private void Success()
    {
        EconomyManager.Instance.SubstractCurrentMoneyAmountBy(_selectedItemPrice);
        OnItemBought?.Invoke(this, new BoughtItemEventArgs(_selectedPurchasableItem));

        if (_selectedPurchasableItem.ItemSO.ItemGameObject.TryGetComponent(out Unit unit))
        {
            UnitData unitData = new UnitData("SamUnit", 1, 0);

            SaveGameManager.Instance.AddUnit(unitData);
        }

        ItemStashManager.Instance.AddPurchasedItem(_selectedPurchasableItem);
    }
}
