using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct QandA
{
    [field: SerializeField] public string QuestionTitle { get; private set; }
    [field: SerializeField] public List<string> Answers { get; private set; }
    [field: SerializeField] public int CorrectAnswerIndex { get; private set; }
}
