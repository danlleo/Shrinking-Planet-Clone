using System;
using UnityEngine;

public class UnitEconomy : MonoBehaviour
{
    public event EventHandler OnUnitReadyToReceiveMoney;
    public event EventHandler OnUnitReceivedMoney;

    private int _currentMoneyAmount;

    public void AddMoneyToCurrentAmount(int recievedMoneyAmount) => _currentMoneyAmount += recievedMoneyAmount;
    
    public void ClearCurrentMoneyAmount() => _currentMoneyAmount = 0;

    public void InvokeOnUnitReadyToReceiveMoney() => OnUnitReadyToReceiveMoney?.Invoke(this, EventArgs.Empty);

    public void InvokeOnUnitRecievedMoney() => OnUnitReceivedMoney?.Invoke(this, EventArgs.Empty);
}
