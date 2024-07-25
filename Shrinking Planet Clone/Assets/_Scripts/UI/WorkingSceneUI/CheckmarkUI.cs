using Managers;
using Unit;
using UnityEngine;

namespace UI.WorkingSceneUI
{
    public class CheckmarkUI : MonoBehaviour
    {
        [SerializeField] private GameObject _checkmarkUI;
        [SerializeField] private UnitEconomy _unitEconomy;
        [SerializeField] private Unit.Unit _unit;

        private void Start()
        {
            DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
            _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitReceivedMoney;
            ResolveWorkIssueUI.OnResolvedWorkIssue += ResolveWorkIssueUI_OnResolvedWorkIssue;
            ResolveWorkIssueUI.OnResolvingFailedWorkIssue += ResolveWorkIssueUI_OnResolvingFailedWorkIssue;

            HideUI();
        }

        private void OnDestroy()
        {
            DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
            _unitEconomy.OnUnitReceivedMoney -= UnitEconomy_OnUnitReceivedMoney;
            ResolveWorkIssueUI.OnResolvedWorkIssue += ResolveWorkIssueUI_OnResolvedWorkIssue;
            ResolveWorkIssueUI.OnResolvingFailedWorkIssue += ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
        }

        private void ResolveWorkIssueUI_OnResolvedWorkIssue(object sender, System.EventArgs e)
        {
            Unit.Unit unit = (Unit.Unit)sender;

            if (ReferenceEquals(unit, _unit))
            {
                ShowUI();
            }
        }

        // Think if it's really needed in the future
        private void ResolveWorkIssueUI_OnResolvingFailedWorkIssue(object sender, System.EventArgs e)
        {
            Unit.Unit unit = (Unit.Unit)sender;

            if (ReferenceEquals(unit, _unit))
            {
                HideUI();
            }
        }

        private void UnitEconomy_OnUnitReceivedMoney(object sender, System.EventArgs e)
        {
            HideUI();
        }

        private void DayManager_OnDayEnded(object sender, System.EventArgs e)
        {
            HideUI();
        }

        private void ShowUI() => _checkmarkUI.SetActive(true);

        private void HideUI() => _checkmarkUI.SetActive(false);
    }
}
