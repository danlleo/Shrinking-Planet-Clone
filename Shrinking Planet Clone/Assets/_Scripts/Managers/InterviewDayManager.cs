using System;
using UnityEngine;

public class InterviewDayManager : MonoBehaviour
{
    public static event EventHandler OnInterviewDayEnded;

    [SerializeField] private Judge _judgePrefab;

    private void Start()
    {
        UnitPickerUI.OnUnitsPicked += UnitPickerUI_OnUnitsPicked;
    }

    private void UnitPickerUI_OnUnitsPicked(object sender, EventArgs e)
    {
        Instantiate(_judgePrefab);
        InterviewUnitManager.Instance.SpawnInterviewUnits();
    }
}
