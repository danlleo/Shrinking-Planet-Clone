using System.Collections.Generic;
using UnityEngine;

public class InterviewUnitManager : Singleton<InterviewUnitManager>
{
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

    public List<UnitSO> GetInterviewUnitSOList() => _unitInterviewSOList;
}
