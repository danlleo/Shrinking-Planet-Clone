using UnityEngine;

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
            SwithToTheNextState(nextState);
        }
    }

    private void SwithToTheNextState(State nextState) => _currentState = nextState;
}
