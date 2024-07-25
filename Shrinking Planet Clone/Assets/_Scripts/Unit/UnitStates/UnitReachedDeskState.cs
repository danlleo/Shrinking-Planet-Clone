using System;
using Managers;

namespace Unit.UnitStates
{
    public class UnitReachedDeskState : UnitBaseState
    {
        private global::Unit.Unit _unit;
        private UnitOccupation _unitOccupation;
        private UnitStateManager _unitStateManager;

        public override void EnterState(UnitStateManager unitStateManager)
        {
            _unit = unitStateManager.GetComponent<global::Unit.Unit>();
            _unitOccupation = unitStateManager.GetComponent<UnitOccupation>();
            _unitStateManager = unitStateManager;

            _unit.InvokeUnitReachedDeskEvent();
            _unitOccupation.OnUnitOccupationSet += UnitOccupation_OnUnitOccupationSet;
        }

        private void UnitOccupation_OnUnitOccupationSet(object sender, EventArgs e)
        {
            ExitState();
        }

        public override void UpdateState(UnitStateManager unitStateManager)
        {
            HandleUnitJobSelect();
        }

        private void HandleUnitJobSelect()
        {
            if (InputManager.Instance.IsMouseButtonDownThisFrame())
            {
                if (UnitActionSystem.Instance.TryGetSelectedUnit(out global::Unit.Unit selectedUnit))
                {
                    if (ReferenceEquals(selectedUnit, _unit))
                    {
                        _unit.InvokeUnitSelectingJobEvent();
                    }
                }
            }
        }

        public override void ExitState()
        {
            _unitOccupation.OnUnitOccupationSet -= UnitOccupation_OnUnitOccupationSet;
            _unitStateManager.SwitchState(_unitStateManager.WorkingState);
        }
    }
}
