using UnityEngine;

public class JudgeQuestionsManager : Singleton<JudgeQuestionsManager>
{
    [SerializeField] private Question[] _questionArray = new Question[5]; 

    protected override void Awake()
    {
        base.Awake();
    }
}
