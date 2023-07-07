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
        OnUnitReceivedPayment += UnitWorkingState_OnUnitReceivedPayment;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        // Save money here
    }

    private void OnDestroy()
    {
        OnUnitReceivedPayment -= UnitWorkingState_OnUnitReceivedPayment;
    }

    private void UnitWorkingState_OnUnitReceivedPayment(object sender, UnitRecievedPaymentEventArgs e)
    {
        AddMoneyToCurrentAmount(e.MoneyAmount);
    }

    public void AddMoneyToCurrentAmount(int moneyAmount) => _totalCurrentMoneyAmount += moneyAmount;

    public int GetTotalCurrentMoneyAmount() => _totalCurrentMoneyAmount;
}
