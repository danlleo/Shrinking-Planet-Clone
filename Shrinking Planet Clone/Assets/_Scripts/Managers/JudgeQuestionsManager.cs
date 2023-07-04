using UnityEngine;

public class JudgeQuestionsManager : Singleton<JudgeQuestionsManager>
{
    [SerializeField] private Question[] _questionArray = new Question[8];

    private const int MAX_QUESTIONS = 5;
    private int _answeredQuestionsCount = 0;

    private Question _currentQuestion;

    protected override void Awake()
    {
        base.Awake();
    }

    public Question GetAndSetRandomQuestion()
    {
        int randomIndex = Random.Range(0, _questionArray.Length);
        _currentQuestion = _questionArray[randomIndex];

        return _questionArray[randomIndex];
    }

    public void ValidateQuestion(UnitOccupationType occupationType)
    {
        if (occupationType == _currentQuestion.QuestionType)
        {
            IncreaseAnsweredQuestionsCount();
            return;
        }
        
        // Otherwise
    }

    public Question GetCurrenQuestion() => _currentQuestion;

    private void IncreaseAnsweredQuestionsCount() => _answeredQuestionsCount++;
}
