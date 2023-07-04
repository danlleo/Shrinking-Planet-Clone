using UnityEngine;

public class JudgeIdleState : JudgeBaseState
{
    public override void EnterState(JudgeStateManager judgeStateManager)
    {
        Debug.Log("Hello");
    }

    public override void UpdateState(JudgeStateManager judgeStateManager)
    {
        Debug.Log("Update state");
    }
}
