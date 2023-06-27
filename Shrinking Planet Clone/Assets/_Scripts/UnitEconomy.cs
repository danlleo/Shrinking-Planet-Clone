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

    private int _currentUnitMoneyAmount;

    public void AddMoneyToCurrentAmount(int recievedMoneyAmount) => _currentUnitMoneyAmount += recievedMoneyAmount;
    
    public void ClearCurrentMoneyAmount() => _currentUnitMoneyAmount = 0;

    public int GetCurrentUnitMoneyAmount() => _currentUnitMoneyAmount;

    public void InvokeOnUnitReadyToReceiveMoney(bool successfullyFinishedWork) => OnUnitReadyToReceiveMoney?.Invoke(this, new UnitReadyToReceiveMoneyEventArgs(successfullyFinishedWork));

    public void InvokeOnUnitRecievedMoney() => OnUnitReceivedMoney?.Invoke(this, EventArgs.Empty);
}
