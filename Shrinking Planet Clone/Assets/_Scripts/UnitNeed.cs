using System;
using UnityEngine;

[Serializable]
public struct UnitNeed 
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public Sprite PickUpIcon { get; private set; }
    [field: SerializeField] public UnitNeedType Type { get; private set; }
}
