using UnityEngine;

public class InterviewDayManager : MonoBehaviour
{
    [SerializeField] private Judge _judgePrefab;

    private void Start()
    {
        UnitPickerUI.OnUnitsPicked += UnitPickerUI_OnUnitsPicked;
    }

    private void UnitPickerUI_OnUnitsPicked(object sender, System.EventArgs e)
    {
        Instantiate(_judgePrefab);
        InterviewUnitManager.Instance.SpawnInterviewUnits();
    }
}
