using UnityEngine;
using static UnitWorkingState;

public class EconomyManager : Singleton<EconomyManager>
{
    [SerializeField] private Transform _moneyIconPrefab;
    [SerializeField] private Transform _canvasUI;
    [SerializeField] private Transform _moneyBoxUI;

    private int _totalCurrentMoneyAmount;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        UnitWorkingState.OnUnitReceivedPayment += UnitWorkingState_OnUnitReceivedPayment;
    }

    private void UnitWorkingState_OnUnitReceivedPayment(object sender, UnitRecievedPaymentEventArgs e)
    {
        AddMoneyToCurrentAmount(e.MoneyAmount);
    }

    private void AddMoneyToCurrentAmount(int moneyAmount) => _totalCurrentMoneyAmount += moneyAmount;

    public int GetTotalCurrentMoneyAmount() => _totalCurrentMoneyAmount;
}
