using System;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public event EventHandler OnJudgeThinking;
    public event EventHandler OnJudgeAsking;

    public void InvokeJudgeThinkingEvent() => OnJudgeThinking?.Invoke(this, EventArgs.Empty);

    public void InvokeJudgeAskingEvent() => OnJudgeAsking?.Invoke(this, EventArgs.Empty);
}
