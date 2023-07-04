using UnityEngine;

public class JudgeStateManager : MonoBehaviour
{
    // Holds a reference to the active state in a state machine
    private JudgeBaseState _currentState;

    // Instances of a concrete states
    public JudgeIdleState _idleState = new JudgeIdleState();
    public JudgeThinkingState _thinkingState = new JudgeThinkingState();

    private void Start()
    {
        _currentState = _idleState;

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
