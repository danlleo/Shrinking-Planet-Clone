using System;
using UI.InterviewSceneUI;
using UnityEngine;

namespace Managers
{
    public class InterviewDayManager : Singleton<InterviewDayManager>
    {
        [SerializeField] private Judge.Judge _judgePrefab;

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
            int nextCompanyRankPosition;

            if (JudgeQuestionsManager.Instance.HasFinishedInterviewWithSuccess())
            {
                nextCompanyRankPosition = CompanyProgress.GetNextCompanyRankPosition(SaveGameManager.Instance.GetCompanyRankPosition());

                if (nextCompanyRankPosition == CompanyProgress.GetFinalCompanyRankPosition())
                {
                    Loader.Load(Loader.Scene.EndGameScene);
                    return;
                }
            }
            else
            {
                // Stays the same
                nextCompanyRankPosition = SaveGameManager.Instance.GetCompanyRankPosition();
            }

            int day = DayManager.Instance.GetCurrentDay() + 1;
            int moneyAmount = SaveGameManager.Instance.GetMoneyAmount();

            SaveGameManager.Instance.SaveGame(nextCompanyRankPosition, day, moneyAmount);
            Loader.Load(Loader.Scene.ManagingScene);
        }
    }
}
