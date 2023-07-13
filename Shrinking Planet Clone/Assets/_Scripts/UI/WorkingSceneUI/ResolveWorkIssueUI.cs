using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolveWorkIssueUI : MonoBehaviour
{
    private const int ANSWER_BUTTON_AMOUNT = 4;

    [SerializeField] private GameObject _resolveWorkIssueUI;
    [SerializeField] private TextMeshProUGUI _questionTitleText;
    [SerializeField] private Button[] _answerButtons = new Button[ANSWER_BUTTON_AMOUNT];

    private QandA _currentQAndA;

    private void Awake()
    {
        foreach (var button in _answerButtons)
        {
            button.onClick.AddListener(() =>
            {
                HideUI();
            });
        }
    }

    private void Start()
    {
        HideUI();

        UnitWorkingState.OnUnitResolvingWorkIssue += UnitWorkingState_OnUnitResolvingWorkIssue;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void OnDestroy()
    {
        UnitWorkingState.OnUnitResolvingWorkIssue -= UnitWorkingState_OnUnitResolvingWorkIssue;
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void UnitWorkingState_OnUnitResolvingWorkIssue(object sender, System.EventArgs e)
    {
        ShowUI();
        Setup();
    }

    private void Setup()
    {
        _currentQAndA = QandAManager.Instance.GetRandomQandA();
        _questionTitleText.text = _currentQAndA.QuestionTitle;

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonAnswerText = _answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();

            if (MaidanPonadUse2014SlavaGeroyamSlavaNaciiUtils.TryGetComponentInChildren(_answerButtons[i].gameObject, out TextMeshProUGUI BTS))
            {
                print("I wanna fuck Rem in her super tight pussy");
            }

            if (buttonAnswerText != null)
            {
                buttonAnswerText.text = _currentQAndA.Answers[i];
            }
        }
    }

    private void ShowUI() => _resolveWorkIssueUI.SetActive(true);

    private void HideUI() => _resolveWorkIssueUI.SetActive(false);
}
