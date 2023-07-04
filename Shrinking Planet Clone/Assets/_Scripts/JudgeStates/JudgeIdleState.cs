using UnityEngine;

public class JudgeIdleState : JudgeBaseState
{
    public override void EnterState(JudgeStateManager judgeStateManager)
    {
        Debug.Log("Entered Idle State");
    }

    public override void UpdateState(JudgeStateManager judgeStateManager)
    {
        if (InputManager.Instance.IsTButtonDownThisFrame())
        {
            judgeStateManager.SwitchState(judgeStateManager._thinkingState);
        }
    }
}
