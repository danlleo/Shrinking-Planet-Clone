using System;
using UnityEngine;

public class InterviewDayManager : Singleton<InterviewDayManager>
{
    [SerializeField] private Judge _judgePrefab;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        UnitPickerUI.OnUnitsPicked += UnitPickerUI_OnUnitsPicked;
    }

    private void OnDestroy()
    {
        UnitPickerUI.OnUnitsPicked -= UnitPickerUI_OnUnitsPicked;
    }

    private void UnitPickerUI_OnUnitsPicked(object sender, EventArgs e)
    {
        Instantiate(_judgePrefab);
        InterviewUnitManager.Instance.SpawnInterviewUnits();
    }

    public void EndDay()
    {
        int moneyAmount = SaveGameManager.Instance.GetMoneyAmount();
        int day = DayManager.Instance.GetCurrentDay() + 1;

        SaveGameManager.Instance.SaveGame(100, day, moneyAmount);
    }
}
