using UnityEngine;

public class UnitEconomy : MonoBehaviour
{
    private int _currentMoneyAmount;

    public void AddMoneyToCurrentAmount(int recievedMoneyAmount) => _currentMoneyAmount += recievedMoneyAmount;
    
    public void ClearCurrentMoneyAmount() => _currentMoneyAmount = 0;
}
