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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
    private void Start()
    {
        _unitDataList = SaveGameManager.Instance.GetUnitDataList();

        foreach (var unitData in _unitDataList)
        {
            UnitSO unitSO = SaveGameManager.Instance.GetUnitSO(unitData.UnitSOName);
            GameObject unitGameObject = Instantiate(_unitPrefab);
            
            if (unitGameObject.TryGetComponent(out Unit unit))
            {
                unit.Initialize(unitSO);
            }

            if (unitGameObject.TryGetComponent(out UnitOccupation unitOccupation))
            {
                unitOccupation.Initialize(unitSO);
            }
        }
    }

>>>>>>> parent of ee6369f (Fixing)
=======
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
=======
>>>>>>> parent of b54ff3c (Added unstable save system, adding UI for choosing units for the interview)
    public void AddUnit(Unit unit) => _unitList.Add(unit);

    public void RemoveUnit(Unit unit) => _unitList.Remove(unit);

    public List<Unit> GetAllUnits() => _unitList;
}
