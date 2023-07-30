using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager>
{
    [SerializeField] private GameObject _unitPrefab;

    private List<Unit> _unitList = new List<Unit>();
    private IEnumerable<UnitData> _unitDataList = new List<UnitData>();

    private float _spawnUnitDelayInSeconds = 4f;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        StartCoroutine(DelayUnitSpawnRoutine());
    }

    public void AddUnit(Unit unit) => _unitList.Add(unit);

    public void RemoveUnit(Unit unit) => _unitList.Remove(unit);

    public IEnumerable<Unit> GetAllUnits() => _unitList;

    private IEnumerator DelayUnitSpawnRoutine()
    {
        _unitDataList = SaveGameManager.Instance.GetUnitDataList();

        foreach (var unitData in _unitDataList)
        {
            UnitSO unitSO = SaveGameManager.Instance.GetUnitSO(unitData.UnitSOName);
            
            if (unitSO.AvailableOnlyOnInterview)
                continue;

            GameObject unitGameObject = Instantiate(_unitPrefab);

            if (unitGameObject.TryGetComponent(out Unit unit))
            {
                unit.Initialize(unitSO);
            }

            if (unitGameObject.TryGetComponent(out UnitOccupation unitOccupation))
            {
                unitOccupation.Initialize(unitSO);
            }

            if (unitGameObject.TryGetComponent(out UnitLevel unitLevel))
            {
                unitLevel.SetCurrentLevel(unitData.UnitLevel);
            }

            yield return new WaitForSeconds(_spawnUnitDelayInSeconds);
        }
    }
}
