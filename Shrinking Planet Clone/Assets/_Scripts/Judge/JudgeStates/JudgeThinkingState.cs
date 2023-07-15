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

        OnJudgeReviewedAnswer += Judge_OnJudgeReceivedAnswer;
        AskQuestion();
    }

    public override void UpdateState(JudgeStateManager judgeStateManager)
    {
        DelayAskingQuestion();

        if (!_hasAskedQuestion)
            return;

        if (_interviewUnit != null)
            return;

        if (InputManager.Instance.IsMouseButtonDownThisFrame())
        {
            if (InterviewUnitActionSystem.Instance.TryGetSelectedInterviewUnit(out InterviewUnit selectedInterviewUnit))
            {
                _interviewUnit = selectedInterviewUnit;

                bool isAnswerCorrect = JudgeQuestionsManager.Instance.ValidateQuestion(_interviewUnit.GetInterviewUnitOccupationType());

                _interviewUnit.InvokeInterviewUnitAnsweredEvent(_judge, isAnswerCorrect);

                // _judge.InvokeJudgeReceivedAnswerEvent(isAnswerCorrect);
            }
        }

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

    private void DelayAskingQuestion()
    {
        _timer += Time.deltaTime;

        if (_timer > _delayTime && !_hasAskedQuestion)
        {
            AskQuestion();
            ResetTimer();
        }
    }

    private void AskQuestion()
    {
        JudgeQuestionsManager.Instance.IncreaseCurrentQuestionCount();
        JudgeQuestionsManager.Instance.SetRandomQuestion();
        _judge.InvokeJudgeAskingEvent();
        _hasAskedQuestion = true;
    } 

    private void ResetTimer() => _timer = 0f;

    private void ResetInterviewUnit() => _interviewUnit = null;
}
