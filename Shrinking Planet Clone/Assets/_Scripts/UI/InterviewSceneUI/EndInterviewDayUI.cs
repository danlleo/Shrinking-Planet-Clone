using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndInterviewDayUI : MonoBehaviour
{
    [SerializeField] private GameObject _endInterviewDayUI;
    [SerializeField] private TextMeshProUGUI _interviewResultText;
    [SerializeField] private Button _proceedButton;

    private void Awake()
    {
        _proceedButton.onClick.AddListener(() =>
        {
            InterviewDayManager.Instance.EndDay();
            Loader.Load(Loader.Scene.ManagingScene);
        });
    }

    private void Start()
    {
        HideUI();
        Judge.OnJudgeFinishedJob += Judge_OnJudgeFinishedJob;
    }

    private void OnDestroy()
    {
        Judge.OnJudgeFinishedJob -= Judge_OnJudgeFinishedJob;
    }

    private void Judge_OnJudgeFinishedJob(object sender, System.EventArgs e)
    {
        ShowUI();

        if (JudgeQuestionsManager.Instance.HasFinishedInterviewWithSuccess())
        {
            _interviewResultText.text = "Success";
        }
        else
        {
            _interviewResultText.text = "Fail";
        }
    }

    private void ShowUI() => _endInterviewDayUI.SetActive(true);

    private void HideUI() => _endInterviewDayUI.SetActive(false);
}
