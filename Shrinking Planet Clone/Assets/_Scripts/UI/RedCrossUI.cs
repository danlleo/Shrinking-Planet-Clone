using UnityEngine;

public class RedCrossUI : MonoBehaviour
{
    [SerializeField] private GameObject _redCrossUI;
    [SerializeField] private Unit _unit;
    [SerializeField] private UnitEconomy _unitEconomy;

    private void Start()
    {
        Hide();

        _unitEconomy.OnUnitReadyToReceiveMoney += UnitEconomy_OnUnitReadyToReceiveMoney;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        UnitWorkingState.OnUnitResolvedWorkIssue += UnitWorkingState_OnUnitResolvedWorkIssue;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void UnitWorkingState_OnUnitResolvedWorkIssue(object sender, System.EventArgs e)
    {
        Unit senderUnit = (Unit)sender;

        if (ReferenceEquals(senderUnit, _unit))
        {
            Hide();
        }
    }

    private void UnitEconomy_OnUnitReadyToReceiveMoney(object sender, UnitEconomy.UnitReadyToReceiveMoneyEventArgs e)
    {
        if (!e.SuccessfullyFinishedWork)
        {
            Show();
        }
    }

    private void Show() => _redCrossUI.SetActive(true);

    private void Hide() => _redCrossUI.SetActive(false);
}
