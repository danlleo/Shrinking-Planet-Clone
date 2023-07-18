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
        int companyPosition;

        if (JudgeQuestionsManager.Instance.HasFinishedInterviewWithSuccess())
        {
            companyPosition = SaveGameManager.Instance.GetCompanyRankPosition() - 10;
            print(companyPosition);
        }
        else
        {
            // Stays the same
            companyPosition = SaveGameManager.Instance.GetCompanyRankPosition();
        }

        int day = DayManager.Instance.GetCurrentDay() + 1;
        int moneyAmount = SaveGameManager.Instance.GetMoneyAmount();

        SaveGameManager.Instance.SaveGame(companyPosition, day, moneyAmount);
    }
}
