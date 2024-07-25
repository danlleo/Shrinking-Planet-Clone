using Unit.UnitStates;
using UnityEngine;

namespace Managers
{
    public class UnitStateManager : MonoBehaviour
    {
        // Holds a reference to the active state in a state machine
        private UnitBaseState _currentState;

        // Instances of a concrete states
        public readonly UnitIdleState IdleState = new();
        public readonly UnitWalkingState WalkingState = new();
        public readonly UnitReachedDeskState ReachedDeskState = new();
        public readonly UnitWorkingState WorkingState = new();

        private void Start()
        {
            _currentState = IdleState;
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
}
