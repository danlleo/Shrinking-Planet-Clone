using System;
using UnityEngine;

public class UnitWorkingState : UnitBaseState
{
    public static event EventHandler OnUnitReceivedPayment;

    private Unit _unit;
    private UnitEconomy _unitEconomy;

    private bool _isReadyToRecievePayment;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _unit = unitStateManager.GetComponent<Unit>();
        _unitEconomy = unitStateManager.GetComponent<UnitEconomy>();
        _unit.InvokeUnitBeganWorkEvent();
        _unit.InvokeUnitPerformedWorkPiece();

        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitRecievedMoney;
        _unitEconomy.OnUnitReadyToReceiveMoney += UnitEconomy_OnUnitReadyToReceiveMoney;
    }

    private void UnitEconomy_OnUnitReadyToReceiveMoney(object sender, EventArgs e)
    {
        SetReadyToRecievePayment();
    }

    private void UnitEconomy_OnUnitRecievedMoney(object sender, EventArgs e)
    {
        SetNotReadyToRecievePayment();
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
            if (ReferenceEquals(selectedUnit, _unit))
            {
                _unitEconomy.InvokeOnUnitRecievedMoney();
                OnUnitReceivedPayment?.Invoke(_unit, EventArgs.Empty);
            }
        }
    }

    private void SetReadyToRecievePayment() => _isReadyToRecievePayment = true;

    private void SetNotReadyToRecievePayment() => _isReadyToRecievePayment = false;
}
