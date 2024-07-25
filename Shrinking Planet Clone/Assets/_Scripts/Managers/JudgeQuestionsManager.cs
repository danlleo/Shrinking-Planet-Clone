using Unit;
using UnityEngine;

namespace Managers
{
    public class JudgeQuestionsManager : Singleton<JudgeQuestionsManager>
    {
        private const int JudgeQuestionCount = 8;
        private const int QuestionCountToPass = 3;

        [SerializeField] private InterviewQuestion[] _questionArray = new InterviewQuestion[JudgeQuestionCount];

        private const int MaxQuestions = 5;
        private int _correctlyAnsweredQuestionsCount;
        private int _currentQuestionsCount;

        private InterviewQuestion _currentQuestion;

        public void SetRandomQuestion() =>
            _currentQuestion = _questionArray[new System.Random().Next(_questionArray.Length)];

        public bool HasAskedAllQuestions() => _currentQuestionsCount == MaxQuestions;

        public bool ValidateQuestion(UnitOccupationType occupationType)
        {
            if (occupationType != _currentQuestion.QuestionType) return false;
            _correctlyAnsweredQuestionsCount++;
            
            return true;
        }

        public InterviewQuestion GetCurrentQuestion() => _currentQuestion;

        public void IncreaseCurrentQuestionCount() => _currentQuestionsCount++;

        public int GetCurrentQuestionCount() => _currentQuestionsCount;

        public int GetMaxQuestionsCount() => MaxQuestions;

        public int GetCorrectlyAnsweredQuestionsCount() => _correctlyAnsweredQuestionsCount;

        public bool HasFinishedInterviewWithSuccess() => _correctlyAnsweredQuestionsCount >= QuestionCountToPass;
    }
}
