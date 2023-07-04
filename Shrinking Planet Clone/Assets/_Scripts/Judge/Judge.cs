using System;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public event EventHandler OnJudgeThinking;

    public void InvokeJudgeThinkingEvent() => OnJudgeThinking?.Invoke(this, EventArgs.Empty);
}
