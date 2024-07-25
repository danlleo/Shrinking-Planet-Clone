using System;
using Managers;
using UnityEngine;

public class JudgeIdleState : JudgeBaseState
{
    public static event EventHandler OnJudgeEnteredIdleState;

    private float _timer = 0f;
    private float _delayTime = 5f;

    public override void EnterState(JudgeStateManager judgeStateManager)
    {
        OnJudgeEnteredIdleState?.Invoke(this, EventArgs.Empty);
    }

    public override void UpdateState(JudgeStateManager judgeStateManager)
    {
        DelayJudgeIdle(judgeStateManager);
    }

    private void DelayJudgeIdle(JudgeStateManager judgeStateManager)
    {
        _timer += Time.deltaTime;

        if (_timer > _delayTime)
        {
            judgeStateManager.SwitchState(judgeStateManager.ThinkingState);
        }
    }
}
