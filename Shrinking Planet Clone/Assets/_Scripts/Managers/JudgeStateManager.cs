using JudgeStates;
using UnityEngine;

namespace Managers
{
    public class JudgeStateManager : MonoBehaviour
    {
        // Holds a reference to the active state in a state machine
        private JudgeBaseState _currentState;

        // Instances of a concrete states
        public readonly JudgeIdleState IdleState = new();
        public readonly JudgeThinkingState ThinkingState = new();

        private void Start()
        {
            _currentState = IdleState;

            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(JudgeBaseState state)
        {
            _currentState = state;
            state.EnterState(this);
        }
    }
}
