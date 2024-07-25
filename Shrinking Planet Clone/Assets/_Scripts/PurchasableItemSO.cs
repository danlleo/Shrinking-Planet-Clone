using UnityEngine;

[CreateAssetMenu]
public class PurchasableItemSO : ScriptableObject
{
    [field: SerializeField] public GameObject ItemGameObject { get; private set; }
    [field: SerializeField] public Vector3 SpawnPosition { get; private set; }
    [field: SerializeField] public Vector3 SpawnRotation { get; private set; }
}
