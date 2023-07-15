using System.Collections.Generic;
using UnityEngine;

public class InterviewUnitManager : Singleton<InterviewUnitManager>
{
    private const int MAX_SELECTED_UNITS = 3;

    [SerializeField] private InterviewUnit _interviewUnit;

    [SerializeField] private Vector3[] _interviewUnitsPredefinedPositions = new Vector3[MAX_SELECTED_UNITS];

    private List<UnitData> _unitDataList = new List<UnitData>();
    private List<UnitSO> _unitInterviewSOList = new List<UnitSO>();

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

            _unitInterviewSOList.Add(unitSO);
        }
    }

    public void SpawnInterviewUnits()
    {
        List<UnitSO> unitSOList = UnitUIPickerManager.Instance.GetUnitSOList();
        List<InterviewCameraTransform> interviewCameraTransformsList = InterviewCameraManager.Instance.GetUnitCameraTransformList();

        for (int i = 0; i < unitSOList.Count; i++)
        {
            InterviewUnit interviewUnit = Instantiate(_interviewUnit);
            interviewUnit.Setup(
                _interviewUnitsPredefinedPositions[i],
                unitSOList[i],
                interviewCameraTransformsList[i]
            );
        }
    }

    public List<UnitSO> GetInterviewUnitSOList() => _unitInterviewSOList;
}
