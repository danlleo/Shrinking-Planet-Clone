using UnityEngine;

public class UnitStateManager : MonoBehaviour
{
    // Holds a reference to the active state in a state machine
    private UnitBaseState _currentState;

    // Instances of a concrete states
    public UnitIdleState _idleState = new UnitIdleState();
    public UnitWalkingState _walkingState = new UnitWalkingState();
    public UnitReachedDeskState _reachedDeskState = new UnitReachedDeskState();
    public UnitWorkingState _workingState = new UnitWorkingState();

    private void Start()
    {
        _currentState = _idleState;

        _currentState.EnterState(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(UnitBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }
}
