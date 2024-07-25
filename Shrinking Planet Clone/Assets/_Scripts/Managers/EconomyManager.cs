using UnityEngine;
using static Unit.UnitStates.UnitWorkingState;

namespace Managers
{
    public class EconomyManager : Singleton<EconomyManager>
    {
        // Remove it later!!!
        [SerializeField] private Transform _moneyIconPrefab;
        [SerializeField] private Transform _canvasUI;
        [SerializeField] private Transform _moneyBoxUI;

        private int _totalCurrentMoneyAmount;

        private void Start()
        {
            _totalCurrentMoneyAmount = SaveGameManager.Instance.GetMoneyAmount();
       
            OnUnitReceivedPayment += UnitWorkingState_OnUnitReceivedPayment;
        }

        private void OnDestroy()
        {
            OnUnitReceivedPayment -= UnitWorkingState_OnUnitReceivedPayment;
        }

        public void SubtractCurrentMoneyAmountBy(int subtractAmount)
        {
            if (subtractAmount <= 0)
                throw new System.Exception("An error occured: sustract amount has negative value or null");

            _totalCurrentMoneyAmount -= subtractAmount;
        }

        public int GetTotalCurrentMoneyAmount() => _totalCurrentMoneyAmount;

        private void UnitWorkingState_OnUnitReceivedPayment(object sender, UnitRecievedPaymentEventArgs e)
        {
            AddMoneyToCurrentAmount(e.MoneyAmount);
        }

        private void AddMoneyToCurrentAmount(int moneyAmount) => _totalCurrentMoneyAmount += moneyAmount;
    }
}
