using System;
using Managers;
using UI.WorkingSceneUI;
using Utils;
using static Unit.UnitEconomy;

namespace Unit.UnitStates
{
    public class UnitWorkingState : UnitBaseState
    {
        private const float DEFAULT_NEED_OCCURRENCE_CHANCE = 80f;
        private const float OCCURENCE_CHANCE_DIVISOR = 10f;

        public static event EventHandler<UnitRecievedPaymentEventArgs> OnUnitReceivedPayment;
        public static event EventHandler OnUnitResolvingWorkIssue;
        public static event EventHandler OnUnitNeedRequested;
        public static event EventHandler OnUnitPickedObject;

        public class UnitRecievedPaymentEventArgs : EventArgs
        {
            public int MoneyAmount { get; }

            public UnitRecievedPaymentEventArgs(int moneyAmount)
            {
                MoneyAmount = moneyAmount;
            }
        }

        private global::Unit.Unit _unit;
        private UnitLevel _unitLevel;
        private UnitEconomy _unitEconomy;
        private UnitOccupation _unitOccupation;
        private UnitNeed _unitNeed;
        private UnitNeedType _unitNeedType;

        private bool _isReadyToRecievePayment;
        private bool _canUnitWork;
        private bool _hasRequest;

        private int _defaultRecieveUnitMoney = 100;

        private float _loseRecieveUnitMoneyPercentage = .15f;

        public override void EnterState(UnitStateManager unitStateManager)
        {
            _unit = unitStateManager.GetComponent<global::Unit.Unit>();
            _unitEconomy = unitStateManager.GetComponent<UnitEconomy>();
            _unitOccupation = unitStateManager.GetComponent<UnitOccupation>();
            _unitLevel = unitStateManager.GetComponent<UnitLevel>();

            _unit.transform.rotation = _unit.GetUnitReachedDeskRotation();
            _unit.transform.position = _unit.GetUnitPlaceOnChairPosition();

            _unit.InvokeUnitBeganWorkEvent();
            _unit.InvokeUnitPerformedWorkPiece();
            _unit.PlayTypingSound();

            _unit.OnUnitNeedFulfilled += Unit_OnUnitNeedFulfilled;
            _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitReceivedMoney; ;
            _unitEconomy.OnUnitReadyToReceiveMoney += UnitEconomy_OnUnitReadyToReceiveMoney;
            ResolveWorkIssueUI.OnResolvedWorkIssue += ResolveWorkIssueUI_OnResolvedWorkIssue;
            ResolveWorkIssueUI.OnResolvingFailedWorkIssue += ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
            DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        }

        public override void UpdateState(UnitStateManager unitStateManager)
        {
            HandleUnitRecievedPayment();
        }
    
        public override void ExitState()
        {
            _unit.OnUnitNeedFulfilled -= Unit_OnUnitNeedFulfilled;
            _unitEconomy.OnUnitReceivedMoney -= UnitEconomy_OnUnitReceivedMoney; ;
            _unitEconomy.OnUnitReadyToReceiveMoney -= UnitEconomy_OnUnitReadyToReceiveMoney;
            ResolveWorkIssueUI.OnResolvedWorkIssue -= ResolveWorkIssueUI_OnResolvedWorkIssue;
            ResolveWorkIssueUI.OnResolvingFailedWorkIssue -= ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
        }

        private void DayManager_OnDayEnded(object sender, EventArgs e)
        {
            ExitState();
        }

        private void Unit_OnUnitNeedFulfilled(object sender, EventArgs e)
        {
            _hasRequest = false;
        }

        private void ResolveWorkIssueUI_OnResolvingFailedWorkIssue(object sender, EventArgs e)
        {
            global::Unit.Unit unit = (global::Unit.Unit)sender;

            if (ReferenceEquals(unit, _unit))
            {
                _canUnitWork = true;
                SetNotReadyToRecievePayment();
            }
        }

        private void ResolveWorkIssueUI_OnResolvedWorkIssue(object sender, EventArgs e)
        {
            global::Unit.Unit unit = (global::Unit.Unit)sender;

            if (ReferenceEquals(unit, _unit))
            {
                _canUnitWork = true;
            }
        }

        private void UnitEconomy_OnUnitReadyToReceiveMoney(object sender, UnitReadyToReceiveMoneyEventArgs e)
        {   
            SetReadyToRecievePayment();

            if (!e.SuccessfullyFinishedWork)
            {
                _canUnitWork = false;
                return;
            }

            // Calculate chance of requesting need
            float randomValue = UnityEngine.Random.value;
            float needOccurrenceChance = MathUtils.NormalizeValue(DEFAULT_NEED_OCCURRENCE_CHANCE - _unitLevel.GetCurrentLevel() * OCCURENCE_CHANCE_DIVISOR, 0, 100);

            if (randomValue <= needOccurrenceChance)
            {
                OnUnitNeedRequested?.Invoke(_unit, EventArgs.Empty);

                UnitNeed randomUnitNeed = UnitNeedManager.Instance.GetRandomNeed();

                _unitNeed = randomUnitNeed;
                _unitNeedType = randomUnitNeed.Type;

                _unit.InvokeUnitNeedRequest(randomUnitNeed);

                _hasRequest = true;
            }

            _canUnitWork = true;
        }

        private void UnitEconomy_OnUnitReceivedMoney(object sender, EventArgs e)
        {
            SetNotReadyToRecievePayment();
        }

        private void HandleUnitRecievedPayment()
        {
            if (InputManager.Instance.IsMouseButtonDownThisFrame())
            {
                if (UnitActionSystem.Instance.TryGetSelectedUnit(out global::Unit.Unit selectedUnit))
                {
                    if (ReferenceEquals(selectedUnit, _unit))
                    {
                        if (_hasRequest)
                        {
                            if (_unitNeedType == UnitNeedType.Thirsty)
                                return;

                            InteractSystem.Instance.InvokeObjectPickUp(_unitNeed.PickUpIcon);
                            InteractSystem.Instance.SetHandsBusyBy(_unitNeedType);
                            UnitNeedManager.Instance.SetCurrentNeed(_unitNeed);
                            UnitNeedManager.Instance.SetUnitWithNeed(_unit);

                            OnUnitPickedObject?.Invoke(_unit, EventArgs.Empty);

                            return;
                        }
    
                        if (!_isReadyToRecievePayment)
                            return;

                        // Calculate amount that unit received, if occupation set properly unit will receive full amount, otherwise - loose percent
                        int unitMoneyAmountReceived = _unitOccupation.GetUnitOccupation() == _unitOccupation.GetDefaultUnitOccupation()
                            ? _defaultRecieveUnitMoney
                            : _defaultRecieveUnitMoney - (int)(_defaultRecieveUnitMoney * _loseRecieveUnitMoneyPercentage);

                        int bonusPercent = _unitEconomy.GetBonusMoneyPercentAmountAccordingToLevel(_unitLevel.GetCurrentLevel());

                        unitMoneyAmountReceived = MathUtils.AddPercentToValue(unitMoneyAmountReceived, bonusPercent);

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
}
