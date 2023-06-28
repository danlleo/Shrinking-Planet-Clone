using System;
using static UnitEconomy;

public class UnitWorkingState : UnitBaseState
{
    public static event EventHandler<UnitRecievedPaymentEventArgs> OnUnitReceivedPayment;
    public static event EventHandler OnUnitResolvedWorkIssue;

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
    private UnitStateManager _unitStateManager;

    private bool _isReadyToRecievePayment;
    private bool _hasUnitSuccessfullyFinishedWork;

    private int _defaultRecieveUnitMoney = 100;

    private float _loseRecieveUnitMoneyPercentage = .15f;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _unitStateManager = unitStateManager;
        _unit = unitStateManager.GetComponent<Unit>();
        _unitEconomy = unitStateManager.GetComponent<UnitEconomy>();
        _unitOccupation = unitStateManager.GetComponent<UnitOccupation>();

        _unit.InvokeUnitBeganWorkEvent();
        _unit.InvokeUnitPerformedWorkPiece();

        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitRecievedMoney;
        _unitEconomy.OnUnitReadyToReceiveMoney += UnitEconomy_OnUnitReadyToReceiveMoney;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void OnDestroy()
    {
        _unitEconomy.OnUnitReceivedMoney -= UnitEconomy_OnUnitRecievedMoney;
        _unitEconomy.OnUnitReadyToReceiveMoney -= UnitEconomy_OnUnitReadyToReceiveMoney;
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, EventArgs e)
    {
        _unitStateManager.SwitchState(_unitStateManager._leavingState);
    }

    private void UnitEconomy_OnUnitReadyToReceiveMoney(object sender, UnitReadyToReceiveMoneyEventArgs e)
    {
        SetReadyToRecievePayment();
        
        if (!e.SuccessfullyFinishedWork)
        {
            _hasUnitSuccessfullyFinishedWork = false;
            return;
        }
        
        _hasUnitSuccessfullyFinishedWork = true;
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
                // Calculate amount that unit received, if occupation set properly unit will receive full amount, otherwise - loose percent
                int unitMoneyAmountReceived = _unitOccupation.GetUnitOccupation() == _unitOccupation.GetDefaultUnitOccupation() 
                    ? _defaultRecieveUnitMoney 
                    : _defaultRecieveUnitMoney - (int)(_defaultRecieveUnitMoney * _loseRecieveUnitMoneyPercentage);
                
                // If unit didn't finish work successfully
                if (!_hasUnitSuccessfullyFinishedWork)
                {
                    _hasUnitSuccessfullyFinishedWork = true;
                    OnUnitResolvedWorkIssue?.Invoke(_unit, EventArgs.Empty);
                    return;
                }

                _unitEconomy.InvokeOnUnitRecievedMoney();
                OnUnitReceivedPayment?.Invoke(_unit, new UnitRecievedPaymentEventArgs(unitMoneyAmountReceived));
            }
        }
    }

    private void SetReadyToRecievePayment() => _isReadyToRecievePayment = true;

    private void SetNotReadyToRecievePayment() => _isReadyToRecievePayment = false;
}
