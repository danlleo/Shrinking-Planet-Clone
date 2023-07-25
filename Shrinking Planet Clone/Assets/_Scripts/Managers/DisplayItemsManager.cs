using System.Collections.Generic;
using UnityEngine;

public class DisplayItemsManager : MonoBehaviour
{
    private void Start()
    {
        IEnumerable<PurchasableItem> purchasableItemList = ItemStashManager.Instance.GetPurchasedItems();

        foreach (var purchasableItem in purchasableItemList)
        {
            Instantiate(purchasableItem.ItemSO.ItemGameObject, purchasableItem.ItemSO.SpawnPosition, Quaternion.Euler(purchasableItem.ItemSO.SpawnRotation));
        }
    }
}
