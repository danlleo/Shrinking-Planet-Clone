using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class QandAManager : Singleton<QandAManager>
    {
        [SerializeField] private List<QandA> _QandAList;

        public QandA GetRandomQandA() => _QandAList[new System.Random().Next(_QandAList.Count)];

        public bool IsAnswerValid(QandA qandA, int answerIndex) => qandA.CorrectAnswerIndex == answerIndex;
    }
}
