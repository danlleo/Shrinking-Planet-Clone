using UnityEngine;

public class CheckmarkUI : MonoBehaviour
{
    [SerializeField] private GameObject _checkmarkUI;
    [SerializeField] private UnitEconomy _unitEconomy;
    [SerializeField] private Unit _unit;

    private void Start()
    {
        UnitWorkingState.OnUnitResolvedWorkIssue += UnitWorkingState_OnUnitResolvedWorkIssue;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitReceivedMoney;

        Hide();
    }

    private void OnDestroy()
    {
        UnitWorkingState.OnUnitResolvedWorkIssue -= UnitWorkingState_OnUnitResolvedWorkIssue;
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
        _unitEconomy.OnUnitReceivedMoney -= UnitEconomy_OnUnitReceivedMoney;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UnitEconomy_OnUnitReceivedMoney(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UnitWorkingState_OnUnitResolvedWorkIssue(object sender, System.EventArgs e)
    {
        Unit senderUnit = (Unit)sender;

        if (ReferenceEquals(senderUnit, _unit))
        {
            Show();
        }
    }

    private void Show() => _checkmarkUI.SetActive(true);

    private void Hide() => _checkmarkUI.SetActive(false);
}
