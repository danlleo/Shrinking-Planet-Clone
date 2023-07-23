using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private List<PurchasableItem> _purchasableItemList;

    protected override void Awake()
    {
        base.Awake();
    }

    public bool CanPurchase(int itemPrice)
    {
        int totalMoney = EconomyManager.Instance.GetTotalCurrentMoneyAmount();

        return totalMoney >= itemPrice;
    }

    public IEnumerable<PurchasableItem> GetPurchasableItemList() => _purchasableItemList;
}
