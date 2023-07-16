using UnityEngine;
using static UnitWorkingState;

public class EconomyManager : Singleton<EconomyManager>
{
    // Remove it later!!!
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
        _totalCurrentMoneyAmount = SaveGameManager.Instance.GetMoneyAmount();
        OnUnitReceivedPayment += UnitWorkingState_OnUnitReceivedPayment;
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
