using UnityEngine;
using static Judge;

public class JudgeThinkingState : JudgeBaseState
{
    private Judge _judge;
    private InterviewUnit _interviewUnit;

    private float _timer = 0f;
    private float _delayTime = 5f;

    private bool _hasAskedQuestion;

    public override void EnterState(JudgeStateManager judgeStateManager)
    {
        if (judgeStateManager.TryGetComponent<Judge>(out Judge judge))
        {
            _judge = judge;
        }

        _judge.InvokeJudgeThinkingEvent();
        OnJudgeReceivedAnswer += Judge_OnJudgeReceivedAnswer;
    }

    private void Judge_OnJudgeReceivedAnswer(object sender, ReceivedAnswerArgs e)
    {
        ResetTimer();
        ResetInterviewUnit();

        if (JudgeQuestionsManager.Instance.HasAskedAllQuestions())
        {
            _judge.InvokeJudgeFinishedJobEvent();
            return;
        }
        
        _hasAskedQuestion = false;

        int currentQuestionCount = JudgeQuestionsManager.Instance.GetCorrectlyAnsweredQuestionsCount();

        QuestionsUI.Instance.UpdateQuestionCountText(currentQuestionCount);
    }

    public override void UpdateState(JudgeStateManager judgeStateManager)
    {
        DelayAskingQuestion();

        if (!_hasAskedQuestion)
            return;

        if (_interviewUnit != null)
            return;

        if (InterviewUnitActionSystem.Instance.TryGetSelectedInterviewUnit(out InterviewUnit selectedInterviewUnit))
        {
            _interviewUnit = selectedInterviewUnit;

            bool isAnswerCorrect = JudgeQuestionsManager.Instance.ValidateQuestion(_interviewUnit.GetInterviewUnitOccupationType());

            _judge.InvokeJudgeReceivedAnswerEvent(isAnswerCorrect);
        }
    }

    private void DelayAskingQuestion()
    {
        _timer += Time.deltaTime;

        if (_timer > _delayTime && !_hasAskedQuestion)
        {
            JudgeQuestionsManager.Instance.IncreaseCurrentQuestionCount();
            JudgeQuestionsManager.Instance.SetRandomQuestion();
            _judge.InvokeJudgeAskingEvent();
            _timer = 0f;
            _hasAskedQuestion = true;
        }
    }

    private void ResetTimer() => _timer = 0f;

    private void ResetInterviewUnit() => _interviewUnit = null;
}
