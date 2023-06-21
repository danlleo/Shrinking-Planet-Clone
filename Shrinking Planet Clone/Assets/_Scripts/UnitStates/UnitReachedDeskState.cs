using System;
using UnityEngine;

public class UnitReachedDeskState : UnitBaseState
{
    private Unit _unit;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _unit = unitStateManager.GetComponent<Unit>();
        _unit.InvokeUnitReachedDeskEvent();
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
                _unit.InvokeUnitSelectingJob();
            }
        }
    }
}
