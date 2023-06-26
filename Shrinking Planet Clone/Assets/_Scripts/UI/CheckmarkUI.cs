using UnityEngine;

public class CheckmarkUI : MonoBehaviour
{
    [SerializeField] private GameObject _checkmarkUI;
    [SerializeField] private UnitEconomy _unitEconomy;
    [SerializeField] private Unit _unit;

    private void Start()
    {
        UnitWorkingState.OnUnitResolvedWorkIssue += UnitWorkingState_OnUnitResolvedWorkIssue;
        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitReceivedMoney;

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
