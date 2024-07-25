using System;
using Managers;
using UnityEngine;

namespace JudgeStates
{
    public class JudgeIdleState : JudgeBaseState
    {
        public static event EventHandler OnJudgeEnteredIdleState;

        private float _timer;
        private readonly float _delayTime = 5f;

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
}
