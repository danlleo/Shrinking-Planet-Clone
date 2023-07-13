using System;
using System.Collections.Generic;

[Serializable]
public struct QandA
{
    public string QuestionTitle;
    public List<string> Answers;
    public int CorrectAnswerIndex;
}
