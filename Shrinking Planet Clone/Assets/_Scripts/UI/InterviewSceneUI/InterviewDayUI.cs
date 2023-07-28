using UnityEngine;
using UnityEngine.UI;

public class InterviewDayUI : MonoBehaviour
{
    [SerializeField] private GameObject _interviewDayUI;
    [SerializeField] private Button _pauseButton;

    private void Awake()
    {
        ShowUI();

        _pauseButton.onClick.AddListener(() =>
        {
            GameManager.Instance.Pause();
        });
    }

    private void Start()
    {
        Judge.OnJudgeFinishedJob += Judge_OnJudgeFinishedJob;
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused += GameManager_OnGameUnpaused;
    }

    private void OnDestroy()
    {
        Judge.OnJudgeFinishedJob -= Judge_OnJudgeFinishedJob;
        GameManager.Instance.OnGamePaused -= GameManager_OnGamePaused;
        GameManager.Instance.OnGameUnpaused -= GameManager_OnGameUnpaused;
    }

    private void Judge_OnJudgeFinishedJob(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void GameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        ShowUI();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void ShowUI() => _interviewDayUI.SetActive(true);

    private void HideUI() => _interviewDayUI.SetActive(false);
}
