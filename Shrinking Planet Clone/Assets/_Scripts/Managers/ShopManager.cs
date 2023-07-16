using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private ShopItemBase _samUnitItem;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Update()
    {
        // For testing purposes
        if (Input.GetKeyDown(KeyCode.B))
        {
            _samUnitItem.Purchase();
        }
    }

    public bool CanPurchase(int itemPrice)
    {
        int totalMoney = EconomyManager.Instance.GetTotalCurrentMoneyAmount();

        return totalMoney >= itemPrice;
    }
}
