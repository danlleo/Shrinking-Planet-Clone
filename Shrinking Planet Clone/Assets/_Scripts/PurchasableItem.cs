using System;
using UnityEngine;

[Serializable]
public struct PurchasableItem
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public string Title { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public PurchasableItemSO ItemSO { get; private set; }
}
