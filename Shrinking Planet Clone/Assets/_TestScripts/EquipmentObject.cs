using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
public class EquipmentObject : ItemObject
{
    public float AttackBonus;
    public float DefenseBonus;

    public void Awake()
    {
        Type = ItemType.Equipment;
    }
}
