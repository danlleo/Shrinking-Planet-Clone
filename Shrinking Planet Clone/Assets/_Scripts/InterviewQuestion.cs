using System;
using Unit;
using UnityEngine;

[Serializable]
public struct InterviewQuestion
{
    [field: SerializeField] public Sprite QuestionIcon { get; private set; }
    [field: SerializeField] public UnitOccupationType QuestionType { get; private set; }
    [field: SerializeField] public string QuestionText { get; private set; }
}