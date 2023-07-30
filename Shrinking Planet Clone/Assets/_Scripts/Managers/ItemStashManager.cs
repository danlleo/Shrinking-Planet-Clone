using System.Collections.Generic;

public class ItemStashManager : Singleton<ItemStashManager>
{
    private Dictionary<int, PurchasableItem> _purchasedItems = new Dictionary<int, PurchasableItem>();

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        IEnumerable<PurchasableItem> purchasedItemsList = SaveGameManager.Instance.RetrievePurchasedItems();

        foreach (var purchasedItem  in purchasedItemsList)
        {
            if (purchasedItem.ItemSO.ItemGameObject.TryGetComponent(out Unit unit))    
                continue;

            AddPurchasedItem(purchasedItem);
        }
    }

    public void AddPurchasedItem(PurchasableItem purchasableItem) => _purchasedItems.Add(purchasableItem.ID, purchasableItem);

    public IEnumerable<PurchasableItem> GetPurchasedItems() => _purchasedItems.Values;

    public bool HasPurchasedItem(int purchasedItemID) => _purchasedItems.ContainsKey(purchasedItemID);
}
