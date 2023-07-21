using System;
using System.Diagnostics;
using static UnitEconomy;

public class UnitWorkingState : UnitBaseState
{
    public static event EventHandler<UnitRecievedPaymentEventArgs> OnUnitReceivedPayment;
    public static event EventHandler OnUnitResolvingWorkIssue;

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
    private UnitNeed _unitNeed;
    private UnitNeedType _unitNeedType;

    private bool _isReadyToRecievePayment;
    private bool _canUnitWork;
    private bool _hasRequest;

    private int _defaultRecieveUnitMoney = 100;

    private float _loseRecieveUnitMoneyPercentage = .15f;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _unitStateManager = unitStateManager;
        _unit = unitStateManager.GetComponent<Unit>();
        _unitEconomy = unitStateManager.GetComponent<UnitEconomy>();
        _unitOccupation = unitStateManager.GetComponent<UnitOccupation>();

        _unit.transform.rotation = _unit.GetUnitReachedDeskRotaion();
        _unit.transform.position = _unit.GetUnitPlaceOnChairPosition();

        _unit.InvokeUnitBeganWorkEvent();
        _unit.InvokeUnitPerformedWorkPiece();

        _unit.OnUnitNeedFulfilled += Unit_OnUnitNeedFulfilled;
        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitReceivedMoney; ;
        _unitEconomy.OnUnitReadyToReceiveMoney += UnitEconomy_OnUnitReadyToReceiveMoney;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        ResolveWorkIssueUI.OnResolvedWorkIssue += ResolveWorkIssueUI_OnResolvedWorkIssue;
        ResolveWorkIssueUI.OnResolvingFailedWorkIssue += ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
    }

    private void Unit_OnUnitNeedFulfilled(object sender, EventArgs e)
    {
        _hasRequest = false;
    }

    private void ResolveWorkIssueUI_OnResolvingFailedWorkIssue(object sender, EventArgs e)
    {
        Unit unit = (Unit)sender;

        if (ReferenceEquals(unit, _unit))
        {
            _canUnitWork = true;
            SetNotReadyToRecievePayment();
        }
    }

    private void ResolveWorkIssueUI_OnResolvedWorkIssue(object sender, EventArgs e)
    {
        Unit unit = (Unit)sender;

        if (ReferenceEquals(unit, _unit))
        {
            _canUnitWork = true;
        }
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
            _canUnitWork = false;
            return;
        }

        UnitNeed randomUnitNeed = UnitNeedManager.Instance.GetRandomNeed();

        _unitNeed = randomUnitNeed;
        _unitNeedType = randomUnitNeed.Type;

        _unit.InvokeUnitNeedRequest(randomUnitNeed);

        _hasRequest = true;
        _canUnitWork = true;
    }

    private void UnitEconomy_OnUnitReceivedMoney(object sender, EventArgs e)
    {
        SetNotReadyToRecievePayment();
    }

    public override void UpdateState(UnitStateManager unitStateManager)
    {
        HandleUnitRecievedPayment();
    }

    private void HandleUnitRecievedPayment()
    {
        if (InputManager.Instance.IsMouseButtonDownThisFrame())
        {
            if (UnitActionSystem.Instance.TryGetSelectedUnit(out Unit selectedUnit))
            {
                if (ReferenceEquals(selectedUnit, _unit))
                {
                    if (_hasRequest)
                    {
                        if (_unitNeed.Type != UnitNeedType.Thirsty)
                        {
                            InteractSystem.Instance.SetHandsBusyBy(_unitNeedType);
                            UnitNeedManager.Instance.SetCurrentNeed(_unitNeed);
                            UnitNeedManager.Instance.SetUnitWithNeed(_unit);
                        }

                        return;
                    }
    
                    if (!_isReadyToRecievePayment)
                        return;

                    // Calculate amount that unit received, if occupation set properly unit will receive full amount, otherwise - loose percent
                    int unitMoneyAmountReceived = _unitOccupation.GetUnitOccupation() == _unitOccupation.GetDefaultUnitOccupation()
                        ? _defaultRecieveUnitMoney
                        : _defaultRecieveUnitMoney - (int)(_defaultRecieveUnitMoney * _loseRecieveUnitMoneyPercentage);

                    // If unit didn't finish work successfully
                    if (!_canUnitWork)
                    {
                        OnUnitResolvingWorkIssue?.Invoke(_unit, EventArgs.Empty);
                        return;
                    }

                    // Fire an event if everything was OK
                    _unitEconomy.InvokeOnUnitRecievedMoney();
                    OnUnitReceivedPayment?.Invoke(_unit, new UnitRecievedPaymentEventArgs(unitMoneyAmountReceived));
                }
            }
        }
    }

    private void SetReadyToRecievePayment() => _isReadyToRecievePayment = true;

    private void SetNotReadyToRecievePayment() => _isReadyToRecievePayment = false;
}
