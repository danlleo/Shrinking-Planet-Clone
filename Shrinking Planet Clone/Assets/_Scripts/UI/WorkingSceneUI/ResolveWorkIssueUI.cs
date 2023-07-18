using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolveWorkIssueUI : MonoBehaviour
{
    public static event EventHandler OnResolvedWorkIssue;
    public static event EventHandler OnResolvingFailedWorkIssue;

    private const int ANSWER_BUTTON_AMOUNT = 4;

    [SerializeField] private GameObject _resolveWorkIssueUI;
    [SerializeField] private TextMeshProUGUI _questionTitleText;
    [SerializeField] private Button[] _answerButtons = new Button[ANSWER_BUTTON_AMOUNT];

    private QandA _currentQAndA;
    private Unit _unit;

    private void Awake()
    {
        foreach (var button in _answerButtons)
        {
            button.onClick.AddListener(() =>
            {
                if (QandAManager.Instance.IsAnswerValid(_currentQAndA, Array.IndexOf(_answerButtons, button)))
                {
                    OnResolvedWorkIssue?.Invoke(_unit, EventArgs.Empty);
                }
                else
                {
                    ScreenShake.Instance.InvokeScreenShake();
                    OnResolvingFailedWorkIssue?.Invoke(_unit, EventArgs.Empty);
                }


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

    private void DayManager_OnDayEnded(object sender, EventArgs e)
    {
        HideUI();
    }

    private void UnitWorkingState_OnUnitResolvingWorkIssue(object sender, EventArgs e)
    {
        Unit unit = (Unit)sender;

        ShowUI();
        Setup(unit);
    }

    private void Setup(Unit unit)
    {
        _currentQAndA = QandAManager.Instance.GetRandomQandA();
        _questionTitleText.text = _currentQAndA.QuestionTitle;
        _unit = unit;

        for (int i = 0; i < _answerButtons.Length; i++)
        {
            if (ComponentUtils.TryGetComponentInChildren(_answerButtons[i].gameObject, out TextMeshProUGUI buttonAnswerText))
            {
                buttonAnswerText.text = _currentQAndA.Answers[i];
            }
        }
    }

    private void ShowUI() => _resolveWorkIssueUI.SetActive(true);

    private void HideUI() => _resolveWorkIssueUI.SetActive(false);
}
