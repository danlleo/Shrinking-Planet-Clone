using System.Collections.Generic;
using Unit;
using UnityEngine;

namespace Managers
{
    public class InterviewUnitManager : Singleton<InterviewUnitManager>
    {
        private const int MaxSelectedUnits = 3;

        [SerializeField] private InterviewUnit.InterviewUnit _interviewUnit;

        [SerializeField] private Vector3[] _interviewUnitsPredefinedPositions = new Vector3[MaxSelectedUnits];

        private IEnumerable<UnitData> _unitDataList = new List<UnitData>();
        private readonly List<UnitSO> _unitInterviewSOList = new();

        private void Start()
        {
            _unitDataList = SaveGameManager.Instance.GetUnitDataList();

            foreach (UnitData unitData in _unitDataList)
            {
                UnitSO unitSO = SaveGameManager.Instance.GetUnitSO(unitData.UnitSOName);

                _unitInterviewSOList.Add(unitSO);
            }
        }

        public void SpawnInterviewUnits()
        {
            List<UnitSO> unitSOList = UnitUIPickerManager.Instance.GetUnitSOList();
            List<InterviewCameraTransform> interviewCameraTransformsList =
                InterviewCameraManager.Instance.GetUnitCameraTransformList();

            for (int i = 0; i < unitSOList.Count; i++)
            {
                InterviewUnit.InterviewUnit interviewUnit = Instantiate(_interviewUnit);
                interviewUnit.Setup(
                    _interviewUnitsPredefinedPositions[i],
                    unitSOList[i],
                    interviewCameraTransformsList[i]
                );
            }
        }

        public IEnumerable<UnitSO> GetInterviewUnitSOList() => _unitInterviewSOList;
    }
}
