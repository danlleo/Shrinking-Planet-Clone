using System;
using Managers;
using Unit.UnitStates;
using UnityEngine;

namespace Unit
{
    public class UnitEconomy : MonoBehaviour
    {
        public event EventHandler<UnitReadyToReceiveMoneyEventArgs> OnUnitReadyToReceiveMoney;
        public event EventHandler OnUnitReceivedMoney;

        public class UnitReadyToReceiveMoneyEventArgs : EventArgs
        {
            public bool SuccessfullyFinishedWork;

            public UnitReadyToReceiveMoneyEventArgs(bool successfullyFinishedWork)
            {
                SuccessfullyFinishedWork = successfullyFinishedWork;
            }
        }

        [SerializeField] private Transform _moneyReceivedAnimationPosition;
        [SerializeField] private GameObject _moneyReceivedAnimationPrefab;

        private global::Unit.Unit _unit;

        private int _currentUnitMoneyAmount;

        private void Start()
        {
            _unit = GetComponent<global::Unit.Unit>();
            UnitWorkingState.OnUnitReceivedPayment += UnitWorkingState_OnUnitReceivedPayment;
        }

        private void OnDestroy()
        {
            UnitWorkingState.OnUnitReceivedPayment -= UnitWorkingState_OnUnitReceivedPayment;
        }

        private void UnitWorkingState_OnUnitReceivedPayment(object sender, UnitWorkingState.UnitRecievedPaymentEventArgs e)
        {
            global::Unit.Unit selectedUnit = (global::Unit.Unit)sender;

            if (ReferenceEquals(_unit, selectedUnit))
            {
                AddMoneyToCurrentAmount(e.MoneyAmount);
                InstantiateMoneyReceivedAnimation(e.MoneyAmount);
                SoundManager.Instance.PlayCoinCollectSound();
            }
        }

        private void InstantiateMoneyReceivedAnimation(int moneyAmount)
        {
            GameObject moneyAnimation = Instantiate(_moneyReceivedAnimationPrefab, _moneyReceivedAnimationPosition);

            if (moneyAnimation.TryGetComponent(out MoneyReceivedAnimationPrefab moneyReceivedAnimationPrefab))
            {
                moneyReceivedAnimationPrefab.SetMoneyReceivedText(moneyAmount);
            }
        }

        public void AddMoneyToCurrentAmount(int recievedMoneyAmount) => _currentUnitMoneyAmount += recievedMoneyAmount;

        public void ClearCurrentMoneyAmount() => _currentUnitMoneyAmount = 0;

        public int GetCurrentUnitMoneyAmount() => _currentUnitMoneyAmount;

        public int GetBonusMoneyPercentAmountAccordingToLevel(int level)
        {
            return level switch
            {
                1 => 0,
                2 => 10,
                3 => 25,
                4 => 50,
                5 => 60,
                _ => 0,
            };
        }

        public void InvokeOnUnitReadyToReceiveMoney(bool successfullyFinishedWork) => OnUnitReadyToReceiveMoney?.Invoke(this, new UnitReadyToReceiveMoneyEventArgs(successfullyFinishedWork));

        public void InvokeOnUnitRecievedMoney() => OnUnitReceivedMoney?.Invoke(this, EventArgs.Empty);
    }
}
