using System;
using Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Unit.UnitStates
{
    public class UnitWalkingState : UnitBaseState
    {
        public static event EventHandler OnUnitBeganWalking;
        public static event EventHandler OnUnitEndedWalking;

        private global::Unit.Unit _unit;
        private NavMeshAgent _navmeshAgent;

        private float _stoppingDistance = .25f;

        private Vector3 _targetDeskPosition;

        public override void EnterState(UnitStateManager unitStateManager)
        {
            _unit = unitStateManager.GetComponent<global::Unit.Unit>();
            _navmeshAgent = _unit.GetUnitNavmeshAgent();
            _targetDeskPosition = _unit.GetUnitDeskPosition();
            _unit.InvokeUnitMovedEvent();

            OnUnitBeganWalking?.Invoke(_unit, EventArgs.Empty);
        }

        public override void UpdateState(UnitStateManager unitStateManager)
        {
            _navmeshAgent.SetDestination(_targetDeskPosition);
        
            if (Vector3.Distance(_unit.transform.position, _targetDeskPosition) <= _stoppingDistance)
            {
                _navmeshAgent.isStopped = true;
                OnUnitEndedWalking?.Invoke(_unit, EventArgs.Empty);
                unitStateManager.SwitchState(unitStateManager.ReachedDeskState);
            }
        }

        public override void ExitState()
        {
            // ...
        }
    }
}
