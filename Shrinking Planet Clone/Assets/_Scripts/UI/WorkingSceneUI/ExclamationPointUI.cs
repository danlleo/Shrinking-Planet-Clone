using UnityEngine;

public class ExclamationPointUI : MonoBehaviour
{
    [SerializeField] private GameObject _exclamationPointUI;
    [SerializeField] private UnitEconomy _unitEconomy;
    [SerializeField] private Unit.Unit _unit;

    private void Awake()
    {
        HideUI();
    }

    private void Start()
    {
        _unitEconomy.OnUnitReadyToReceiveMoney += UnitEconomy_OnUnitReadyToReceiveMoney;
        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitReceivedMoney;
        _unit.OnUnitNeedFulfilled += Unit_OnUnitNeedFulfilled;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        UnitWorkingState.OnUnitNeedRequested += UnitWorkingState_OnUnitNeedRequested;
    }

    private void OnDestroy()
    {
        _unitEconomy.OnUnitReadyToReceiveMoney -= UnitEconomy_OnUnitReadyToReceiveMoney;
        _unitEconomy.OnUnitReceivedMoney -= UnitEconomy_OnUnitReceivedMoney;
        _unit.OnUnitNeedFulfilled -= Unit_OnUnitNeedFulfilled;
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
        UnitWorkingState.OnUnitNeedRequested -= UnitWorkingState_OnUnitNeedRequested;
    }

    private void Unit_OnUnitNeedFulfilled(object sender, System.EventArgs e)
    {
        Unit.Unit senderUnit = (Unit.Unit)sender;

        if (ReferenceEquals(senderUnit, _unit))
        {
            ShowUI();
        }
    }

    private void UnitWorkingState_OnUnitNeedRequested(object sender, System.EventArgs e)
    {
        Unit.Unit senderUnit = (Unit.Unit)sender;

        if (ReferenceEquals(senderUnit, _unit)) 
        {
            HideUI();
        }
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void UnitEconomy_OnUnitReceivedMoney(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void UnitEconomy_OnUnitReadyToReceiveMoney(object sender, UnitEconomy.UnitReadyToReceiveMoneyEventArgs e)
    {
        if (e.SuccessfullyFinishedWork)
            ShowUI();
    }

    private void ShowUI() => _exclamationPointUI.SetActive(true);

    private void HideUI() => _exclamationPointUI.SetActive(false);
}
