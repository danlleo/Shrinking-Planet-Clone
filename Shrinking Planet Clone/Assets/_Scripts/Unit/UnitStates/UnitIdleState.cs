using System;
using Managers;
using UnityEngine;

namespace Unit.UnitStates
{
    public class UnitIdleState : UnitBaseState
    {
        public static event EventHandler OnUnitSpawned;

        private float _timer;

        public override void EnterState(UnitStateManager unitStateManager)
        {
            global::Unit.Unit unit = unitStateManager.GetComponent<global::Unit.Unit>();

            OnUnitSpawned?.Invoke(unit, EventArgs.Empty);
            _timer = 0f;
        }

        public override void UpdateState(UnitStateManager unitStateManager)
        {
            _timer += Time.deltaTime;

            if (_timer >= 3f)
                unitStateManager.SwitchState(unitStateManager.WalkingState);
        }

        public override void ExitState()
        {
            // ...
        }
    }
}
