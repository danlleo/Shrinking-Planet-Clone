using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class UnitNeedManager : Singleton<UnitNeedManager>
    {
        [SerializeField] private List<UnitNeed> _unitNeedList = new();

        private Unit.Unit _unit;
        private UnitNeed _currentNeed;

        public UnitNeed GetRandomNeed() => _unitNeedList[Random.Range(0, _unitNeedList.Count)];

        public void SetCurrentNeed(UnitNeed need) => _currentNeed = need;

        public UnitNeed GetCurrentNeed() => _currentNeed;

        public void SetUnitWithNeed(Unit.Unit unit) => _unit = unit;

        public Unit.Unit GetUnitWithNeed() => _unit;
    }
}
