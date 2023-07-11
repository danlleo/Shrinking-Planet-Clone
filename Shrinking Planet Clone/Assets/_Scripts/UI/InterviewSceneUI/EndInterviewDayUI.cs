using UnityEngine;
using UnityEngine.UI;

public class EndInterviewDayUI : MonoBehaviour
{
    [SerializeField] private GameObject _endInterviewDayUI;
    [SerializeField] private Button _proceedButton;

    private void Awake()
    {
        _proceedButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.ManagingScene);
        });
    }

    private void Start()
    {
        HideUI();
        Judge.OnJudgeFinishedJob += Judge_OnJudgeFinishedJob;
    }

    private void Judge_OnJudgeFinishedJob(object sender, System.EventArgs e)
    {
        ShowUI();
    }

    private void ShowUI() => _endInterviewDayUI.SetActive(true);

    private void HideUI() => _endInterviewDayUI.SetActive(false);
}
