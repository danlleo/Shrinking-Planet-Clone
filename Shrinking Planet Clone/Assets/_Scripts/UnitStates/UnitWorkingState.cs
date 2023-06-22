using UnityEngine;

public class UnitWorkingState : UnitBaseState
{
    private Unit _unit;

    private bool _isReadyToRecievePayment;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _unit = unitStateManager.GetComponent<Unit>();
        _unit.InvokeUnitBeganWorkEvent();
        _unit.InvokeUnitPerformedWorkPiece();
    }

    public override void UpdateState(UnitStateManager unitStateManager)
    {
        HandleUnitRecievedPayment();
    }

    private void HandleUnitRecievedPayment()
    {
        if (!_isReadyToRecievePayment)
            return;

        if (UnitActionSystem.Instance.TryGetSelectedUnit(out Unit selectedUnit))
        {

        }
    }

    private void SetReadyToRecievePayment() => _isReadyToRecievePayment = true;
}
