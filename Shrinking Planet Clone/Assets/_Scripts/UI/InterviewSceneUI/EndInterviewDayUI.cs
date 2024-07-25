using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InterviewSceneUI
{
    public class EndInterviewDayUI : MonoBehaviour
    {
        [SerializeField] private GameObject _endInterviewDayUI;
        [SerializeField] private GameObject _endInterviewDayUIInfo;
        [SerializeField] private TextMeshProUGUI _interviewResultText;
        [SerializeField] private TextMeshProUGUI _correctAnswersText;
        [SerializeField] private TextMeshProUGUI _newCompanyRankPositionText;
        [SerializeField] private Button _proceedButton;

        private void Awake()
        {
            _proceedButton.onClick.AddListener(() =>
            {
                InterviewDayManager.Instance.EndDay();
            });
        }

        private void Start()
        {
            HideUI();
            Judge.Judge.OnJudgeFinishedJob += Judge_OnJudgeFinishedJob;
        }

        private void OnDestroy()
        {
            Judge.Judge.OnJudgeFinishedJob -= Judge_OnJudgeFinishedJob;
        }

        private void Judge_OnJudgeFinishedJob(object sender, System.EventArgs e)
        {
            ShowUI();

            if (JudgeQuestionsManager.Instance.HasFinishedInterviewWithSuccess())
            {
                _endInterviewDayUIInfo.SetActive(true);
                _interviewResultText.text = "Success";
                _correctAnswersText.text =
                    $"Correct answers {JudgeQuestionsManager.Instance.GetCorrectlyAnsweredQuestionsCount()}";

                int currentCompanyRankPosition = SaveGameManager.Instance.GetCompanyRankPosition();

                _newCompanyRankPositionText.text =
                    $"New Company Rank Position {currentCompanyRankPosition} → {CompanyProgress.GetNextCompanyRankPosition(currentCompanyRankPosition)}";
            }
            else
            {
                _endInterviewDayUIInfo.SetActive(false);
                _interviewResultText.text = "Fail";
            }
        }

        private void ShowUI() => _endInterviewDayUI.SetActive(true);

        private void HideUI() => _endInterviewDayUI.SetActive(false);
    }
}
