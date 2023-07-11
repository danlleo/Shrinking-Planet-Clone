using UnityEngine;

public class ExclamationPointUI : MonoBehaviour
{
    [SerializeField] private GameObject _exclamationPointUI;
    [SerializeField] private UnitEconomy _unitEconomy;

    private void Start()
    {
        _unitEconomy.OnUnitReadyToReceiveMoney += UnitEconomy_OnUnitReadyToReceiveMoney;
        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitReceivedMoney;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;

        HideUI();
    }

    private void OnDestroy()
    {
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
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
