using UnityEngine;

public class JudgeQuestionsManager : Singleton<JudgeQuestionsManager>
{
    [SerializeField] private Question[] _questionArray = new Question[8];

    private const int MAX_QUESTIONS = 5;
    private int _correctlyAnsweredQuestionsCount = 0;
    private int _totalQuestionsCount = 0;

    private Question _currentQuestion;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SetRandomQuestion()
    {
        int randomIndex = Random.Range(0, _questionArray.Length);
        _currentQuestion = _questionArray[randomIndex];
    }

    public bool HasAskedAllQuestions()
    {
        _totalQuestionsCount++;

        if (_totalQuestionsCount == MAX_QUESTIONS)
            return true;

        return false;
    }

    public bool ValidateQuestion(UnitOccupationTypes occupationType)
    {
        if (occupationType == _currentQuestion.QuestionType)
        {
            _correctlyAnsweredQuestionsCount++;
            return true;
        }

        return false;
    }

    public Question GetCurrenQuestion() => _currentQuestion;
}
