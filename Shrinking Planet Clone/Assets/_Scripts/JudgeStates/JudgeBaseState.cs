using Managers;

namespace JudgeStates
{
    public abstract class JudgeBaseState
    {
        public abstract void EnterState(JudgeStateManager judgeStateManager);

        public abstract void UpdateState(JudgeStateManager judgeStateManager);
    }
}
