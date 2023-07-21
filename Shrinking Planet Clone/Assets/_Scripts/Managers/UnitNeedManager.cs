using System.Collections.Generic;
using UnityEngine;

public class UnitNeedManager : Singleton<UnitNeedManager>
{
    [SerializeField] private List<UnitNeed> _unitNeedList = new List<UnitNeed>();

    protected override void Awake()
    {
        base.Awake();
    }

    public UnitNeed GetRandomNeed() => _unitNeedList[Random.Range(0, _unitNeedList.Count)];
}
