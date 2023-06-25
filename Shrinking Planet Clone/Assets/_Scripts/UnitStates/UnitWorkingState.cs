using System;
using Unity.VisualScripting;
using UnityEngine;

public class UnitWorkingState : UnitBaseState
{
    public static event EventHandler<UnitRecievedPaymentEventArgs> OnUnitReceivedPayment;

    public class UnitRecievedPaymentEventArgs : EventArgs
    {
        public int MoneyAmount { get; }

        public UnitRecievedPaymentEventArgs(int moneyAmount)
        {
            MoneyAmount = moneyAmount;
        }
    }

    private Unit _unit;
    private UnitEconomy _unitEconomy;
    private UnitOccupation _unitOccupation;

    private bool _isReadyToRecievePayment;

    private int _defaultRecieveUnitMoney = 100;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _unit = unitStateManager.GetComponent<Unit>();
        _unitEconomy = unitStateManager.GetComponent<UnitEconomy>();
        _unitOccupation = unitStateManager.GetComponent<UnitOccupation>();
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
                // Calculate amount that unit received
                int unitMoneyAmountReceived = _unitOccupation.GetUnitOccupation() == _unitOccupation.GetDefaultUnitOccupation() 
                    ? _defaultRecieveUnitMoney 
                    : _defaultRecieveUnitMoney - (int)(_defaultRecieveUnitMoney * .15);

                _unitEconomy.InvokeOnUnitRecievedMoney();
                OnUnitReceivedPayment?.Invoke(_unit, new UnitRecievedPaymentEventArgs(unitMoneyAmountReceived));
            }
        }
    }

    private void SetReadyToRecievePayment() => _isReadyToRecievePayment = true;

    private void SetNotReadyToRecievePayment() => _isReadyToRecievePayment = false;
}
