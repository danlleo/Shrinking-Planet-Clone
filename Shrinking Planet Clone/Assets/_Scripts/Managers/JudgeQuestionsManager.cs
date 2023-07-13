using UnityEngine;

public class JudgeQuestionsManager : Singleton<JudgeQuestionsManager>
{
    private const int JUDGE_QUESTION_COUNT = 8;

    [SerializeField] private InterviewQuestion[] _questionArray = new InterviewQuestion[JUDGE_QUESTION_COUNT];

    private const int MAX_QUESTIONS = 5;
    private int _correctlyAnsweredQuestionsCount = 0;
    private int _currentQuestionsCount = 0;

    private InterviewQuestion _currentQuestion;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetRandomQuestion() =>_currentQuestion = _questionArray[new System.Random().Next(_questionArray.Length)];

    public bool HasAskedAllQuestions() => _currentQuestionsCount == MAX_QUESTIONS;

    public bool ValidateQuestion(UnitOccupationType occupationType)
    {
        if (occupationType == _currentQuestion.QuestionType)
        {
            _correctlyAnsweredQuestionsCount++;
            return true;
        }

        return false;
    }

    public InterviewQuestion GetCurrentQuestion() => _currentQuestion;

    public void IncreaseCurrentQuestionCount() => _currentQuestionsCount++;

    public int GetCurrentQuestionCount() => _currentQuestionsCount;

    public int GetMaxQuestionsCount() => MAX_QUESTIONS;

    public int GetCorrectlyAnsweredQuestionsCount() => _correctlyAnsweredQuestionsCount;
}
