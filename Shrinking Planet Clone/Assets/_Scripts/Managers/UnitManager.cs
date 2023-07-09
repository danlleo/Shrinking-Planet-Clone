using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    [SerializeField] private GameObject _unitPrefab;

    private List<Unit> _unitList = new List<Unit>();
    private List<UnitData> _unitDataList = new List<UnitData>();

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _unitDataList = SaveGameManager.Instance.GetUnitDataList();

        foreach (var unitData in _unitDataList)
        {
            UnitSO unitSO = SaveGameManager.Instance.GetUnitSO(unitData.UnitSOName);
            GameObject unitPrefab = Instantiate(_unitPrefab);
            
            if (unitPrefab.TryGetComponent(out Unit unit))
            {
                unit.Initialize(unitSO);
            }

            if (unitPrefab.TryGetComponent(out UnitOccupation unitOccupation))
            {
                unitOccupation.Initialize(unitSO);
            }
        }
    }

    public void AddUnit(Unit unit) => _unitList.Add(unit);

    public void RemoveUnit(Unit unit) => _unitList.Remove(unit);

    public List<Unit> GetAllUnits() => _unitList;
}
