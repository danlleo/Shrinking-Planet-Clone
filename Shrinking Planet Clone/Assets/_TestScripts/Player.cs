using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryObject Inventory;

    public void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();

        if (item)
        {
            Inventory.AddItem(item.ItemObj, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        Inventory.Container.Clear();
    }
}
