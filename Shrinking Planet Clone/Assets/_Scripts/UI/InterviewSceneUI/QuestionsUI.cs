using System.Collections;
using Managers;
using TMPro;
using UnityEngine;

namespace UI.InterviewSceneUI
{
    public class QuestionsUI : Singleton<QuestionsUI>
    {
        [SerializeField] private GameObject _questionsUI;
        [SerializeField] private TextMeshProUGUI _correctQuestionsText;
        [SerializeField] private TextMeshProUGUI _questionNumberText;

        private int _maxQuestionCount;

        private readonly float _questionNumberTextDisplayTime = 1f;

        private void Start()
        {
            HideQuestionNumberText();
            HideUI();
            UnitPickerUI.OnUnitsPicked += UnitPickerUI_OnUnitsPicked;
            Judge.Judge.OnJudgeAsking += Judge_OnJudgeAsking;
            Judge.Judge.OnJudgeFinishedJob += Judge_OnJudgeFinishedJob;
        }

        private void OnDestroy()
        {
            UnitPickerUI.OnUnitsPicked -= UnitPickerUI_OnUnitsPicked;
            Judge.Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
            Judge.Judge.OnJudgeFinishedJob -= Judge_OnJudgeFinishedJob;
        }

        private void Judge_OnJudgeFinishedJob(object sender, System.EventArgs e)
        {
            HideUI();
        }

        private void Judge_OnJudgeAsking(object sender, System.EventArgs e)
        {
            int currentQuestionCount = JudgeQuestionsManager.Instance.GetCurrentQuestionCount();
            _questionNumberText.text = $"Question {currentQuestionCount}";
            StartCoroutine(DisplayQuestionNumberTextInSecondsRoutine());
        }

        private void UnitPickerUI_OnUnitsPicked(object sender, System.EventArgs e)
        {
            ShowUI();
            Initialize();
        }

        private void Initialize()
        {
            int maxQuestionCount = JudgeQuestionsManager.Instance.GetMaxQuestionsCount();

            _maxQuestionCount = maxQuestionCount;
            _correctQuestionsText.text = $"0 / {_maxQuestionCount}";
        }

        private void ShowUI() => _questionsUI.SetActive(true);

        private void HideUI() => _questionsUI.SetActive(false);

        private void ShowQuestionNumberText() => _questionNumberText.gameObject.SetActive(true);

        private void HideQuestionNumberText() => _questionNumberText.gameObject.SetActive(false);

        private IEnumerator DisplayQuestionNumberTextInSecondsRoutine()
        {
            ShowQuestionNumberText();

            yield return new WaitForSeconds(_questionNumberTextDisplayTime);

            HideQuestionNumberText();
        }

        public void UpdateQuestionCountText(int count) => _correctQuestionsText.text = $"{count} / {_maxQuestionCount}";
    }
}
