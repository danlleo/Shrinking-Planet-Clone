using Managers;
using UI.InterviewSceneUI;
using UnityEngine;
using static Judge.Judge;

namespace JudgeStates
{
    public class JudgeThinkingState : JudgeBaseState
    {
        private Judge.Judge _judge;
        private InterviewUnit.InterviewUnit _interviewUnit;

        private float _timer;
        private readonly float _delayTime = 5f;

        private bool _hasAskedQuestion;

        public override void EnterState(JudgeStateManager judgeStateManager)
        {
            if (judgeStateManager.TryGetComponent(out Judge.Judge judge))
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

            if (!InputManager.Instance.IsMouseButtonDownThisFrame()) return;
            if (!InterviewUnitActionSystem.Instance.TryGetSelectedInterviewUnit(
                    out InterviewUnit.InterviewUnit selectedInterviewUnit)) return;
            _interviewUnit = selectedInterviewUnit;

            bool isAnswerCorrect =
                JudgeQuestionsManager.Instance.ValidateQuestion(_interviewUnit.GetInterviewUnitOccupationType());

            _interviewUnit.InvokeInterviewUnitAnsweredEvent(_judge, isAnswerCorrect);
        }

        private void Judge_OnJudgeReceivedAnswer(object sender, ReceivedAnswerArgs e)
        {
            ResetTimer();
            ResetInterviewUnit();

            int currentQuestionCount = JudgeQuestionsManager.Instance.GetCorrectlyAnsweredQuestionsCount();

            QuestionsUI.Instance.UpdateQuestionCountText(currentQuestionCount);

            if (JudgeQuestionsManager.Instance.HasAskedAllQuestions())
            {
                _judge.InvokeJudgeFinishedJobEvent();
                return;
            }

            _hasAskedQuestion = false;
        }

        private void DelayAskingQuestion()
        {
            _timer += Time.deltaTime;

            if (!(_timer > _delayTime) || _hasAskedQuestion) return;

            AskQuestion();
            ResetTimer();
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
}
