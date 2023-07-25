using System;
using UnityEngine;

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

    private Unit _unit;

    private int _currentUnitMoneyAmount;

    private void Start()
    {
        _unit = GetComponent<Unit>();
        UnitWorkingState.OnUnitReceivedPayment += UnitWorkingState_OnUnitReceivedPayment;
    }

    private void OnDestroy()
    {
        UnitWorkingState.OnUnitReceivedPayment -= UnitWorkingState_OnUnitReceivedPayment;
    }

    private void UnitWorkingState_OnUnitReceivedPayment(object sender, UnitWorkingState.UnitRecievedPaymentEventArgs e)
    {
        Unit selectedUnit = (Unit)sender;

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

    public void InvokeOnUnitReadyToReceiveMoney(bool successfullyFinishedWork) => OnUnitReadyToReceiveMoney?.Invoke(this, new UnitReadyToReceiveMoneyEventArgs(successfullyFinishedWork));

    public void InvokeOnUnitRecievedMoney() => OnUnitReceivedMoney?.Invoke(this, EventArgs.Empty);
}
