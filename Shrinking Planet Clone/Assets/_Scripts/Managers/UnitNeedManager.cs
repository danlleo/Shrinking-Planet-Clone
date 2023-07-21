using System.Collections.Generic;
using UnityEngine;

public class UnitNeedManager : Singleton<UnitNeedManager>
{
    [SerializeField] private List<UnitNeed> _unitNeedList = new List<UnitNeed>();

    private Unit _unit;
    private UnitNeed _currentNeed;

    protected override void Awake()
    {
        base.Awake();
    }

    public UnitNeed GetRandomNeed() => _unitNeedList[Random.Range(0, _unitNeedList.Count)];

    public void SetCurrentNeed(UnitNeed need) => _currentNeed = need;

    public UnitNeed GetCurrentNeed() => _currentNeed;

    public void SetUnitWithNeed(Unit unit) => _unit = unit;

    public Unit GetUnitWithNeed() => _unit;
}
