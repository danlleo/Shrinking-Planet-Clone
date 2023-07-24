using System.Collections.Generic;
using UnityEngine;

public class DisplayItemsManager : MonoBehaviour
{
    private void Start()
    {
        IEnumerable<PurchasableItem> purchasableItemList = ItemStashManager.Instance.GetPurchasedItems();

        foreach (var pur in purchasableItemList)
        {
            Instantiate(pur.ItemSO.ItemGameObject, pur.ItemSO.SpawnPosition, Quaternion.Euler(pur.ItemSO.SpawnRotation));
        }
    }
}
