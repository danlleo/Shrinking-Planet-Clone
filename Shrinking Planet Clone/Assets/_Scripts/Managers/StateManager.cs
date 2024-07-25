using UnityEngine;

namespace Managers
{
    public class StateManager : MonoBehaviour
    {
        private State _currentState;

        private void Update()
        {
            RunStateMachine();
        }

        private void RunStateMachine()
        {
            State nextState = _currentState?.RunCurrentState();

            if (nextState != null)
            {
                SwitchToTheNextState(nextState);
            }
        }

        private void SwitchToTheNextState(State nextState) => _currentState = nextState;
    }
}
