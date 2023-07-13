using System.Collections.Generic;
using UnityEngine;

public class QandAManager : Singleton<QandAManager>
{
    [SerializeField] private List<QandA> _QandAList;

    protected override void Awake()
    {
        base.Awake();
    }

    public QandA GetRandomQandA() => _QandAList[new System.Random().Next(_QandAList.Count)];

    public bool IsAnswerValid(QandA qandA, int answerIndex) => qandA.CorrectAnswerIndex == answerIndex;
}
