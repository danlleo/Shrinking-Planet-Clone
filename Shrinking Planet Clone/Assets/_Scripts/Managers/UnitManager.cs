using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    [SerializeField] private List<UnitSO> _unitSOList = new List<UnitSO>();
    [SerializeField] private GameObject _unitPrefab;

    private List<Unit> _unitList = new List<Unit>();

    protected override void Awake()
    {
        base.Awake();
    }

    public void AddUnit(Unit unit) => _unitList.Add(unit);

    public void RemoveUnit(Unit unit) => _unitList.Remove(unit);

    public List<Unit> GetAllUnits() => _unitList;
}
