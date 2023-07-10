using System;
using UnityEngine;

public class JudgeThinkingState : JudgeBaseState
{
    private Judge _judge;
    private InterviewUnit _interviewUnit;

    private float _timer = 0f;
    private float _delayTime = 5f;

    private bool _askedQuestion;

    public override void EnterState(JudgeStateManager judgeStateManager)
    {
        if (judgeStateManager.TryGetComponent<Judge>(out Judge judge))
        {
            _judge = judge;
        }

        _judge.InvokeJudgeThinkingEvent();
    }

    public override void UpdateState(JudgeStateManager judgeStateManager)
    {
        DelayAskingQuestion();

        if (!_askedQuestion)
            return;

        if (InterviewUnitActionSystem.Instance.TryGetSelectedInterviewUnit(out InterviewUnit selectedInterviewUnit))
        {
            if (ReferenceEquals(selectedInterviewUnit, _interviewUnit))
                return;

            _interviewUnit = selectedInterviewUnit;
            Debug.Log("test");
        }
    }

    private void DelayAskingQuestion()
    {
        _timer += Time.deltaTime;

        if (_timer > _delayTime && !_askedQuestion)
        {
            JudgeQuestionsManager.Instance.SetRandomQuestion();
            _judge.InvokeJudgeAskingEvent();
            _timer = 0f;
            _askedQuestion = true;
        }
    }
}
