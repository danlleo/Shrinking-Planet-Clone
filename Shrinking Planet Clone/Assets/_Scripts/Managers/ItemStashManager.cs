using System.Collections.Generic;

namespace Managers
{
    public class ItemStashManager : Singleton<ItemStashManager>
    {
        private readonly Dictionary<int, PurchasableItem> _purchasedItems = new();

        private void Start()
        {
            IEnumerable<PurchasableItem> purchasedItemsList = SaveGameManager.Instance.RetrievePurchasedItems();

            foreach (PurchasableItem purchasedItem in purchasedItemsList)
            {
                if (purchasedItem.ItemSO.ItemGameObject.TryGetComponent(out Unit.Unit _))
                    continue;

                AddPurchasedItem(purchasedItem);
            }
        }

        public void AddPurchasedItem(PurchasableItem purchasableItem) =>
            _purchasedItems.Add(purchasableItem.ID, purchasableItem);

        public IEnumerable<PurchasableItem> GetPurchasedItems() => _purchasedItems.Values;

        public bool HasPurchasedItem(int purchasedItemID) => _purchasedItems.ContainsKey(purchasedItemID);
    }
}
