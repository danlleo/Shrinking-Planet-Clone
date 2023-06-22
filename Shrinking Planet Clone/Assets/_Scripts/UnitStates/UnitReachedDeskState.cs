using System;
using UnityEngine;

public class UnitReachedDeskState : UnitBaseState
{
    private Unit _unit;
    private UnitOccupation _unitOccupation;
    private UnitStateManager _unitStateManager;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _unit = unitStateManager.GetComponent<Unit>();
        _unitOccupation = unitStateManager.GetComponent<UnitOccupation>();
        _unitStateManager = unitStateManager;

        _unit.InvokeUnitReachedDeskEvent();
        _unitOccupation.OnUnitOccupationSet += UnitOccupation_OnUnitOccupationSet;
    }

    private void UnitOccupation_OnUnitOccupationSet(object sender, EventArgs e)
    {
        _unitStateManager.SwitchState(_unitStateManager._workingState);
    }

    public override void UpdateState(UnitStateManager unitStateManager)
    {
        HandleUnitJobSelect();
    }

    private void HandleUnitJobSelect()
    {
        if (UnitActionSystem.Instance.TryGetSelectedUnit(out Unit selectedUnit))
        {
            if (ReferenceEquals(selectedUnit, _unit))
            {
                _unit.InvokeUnitSelectingJobEvent();
            }
        }
    }
}
