using System.Collections;
using System.Collections.Generic;
using Unit;
using UnityEngine;

namespace Managers
{
    public class UnitManager : Singleton<UnitManager>
    {
        [SerializeField] private GameObject _unitPrefab;

        private readonly List<Unit.Unit> _unitList = new();
        private IEnumerable<UnitData> _unitDataList = new List<UnitData>();

        private const float SpawnUnitDelayInSeconds = 4f;

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => SaveGameManager.Instance is not null);
            StartCoroutine(DelayUnitSpawnRoutine());
        }

        public void AddUnit(Unit.Unit unit) => _unitList.Add(unit);

        public void RemoveUnit(Unit.Unit unit) => _unitList.Remove(unit);

        public IEnumerable<Unit.Unit> GetAllUnits() => _unitList;

        private IEnumerator DelayUnitSpawnRoutine()
        {
            _unitDataList = SaveGameManager.Instance.GetUnitDataList();
            
            foreach (UnitData unitData in _unitDataList)
            {
                UnitSO unitSO = SaveGameManager.Instance.GetUnitSO(unitData.UnitSOName);
            
                print(unitSO);
                
                if (unitSO.AvailableOnlyOnInterview)
                    continue;

                GameObject unitGameObject = Instantiate(_unitPrefab);

                if (unitGameObject.TryGetComponent(out Unit.Unit unit))
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

                yield return new WaitForSeconds(SpawnUnitDelayInSeconds);
            }
        }
    }
}
