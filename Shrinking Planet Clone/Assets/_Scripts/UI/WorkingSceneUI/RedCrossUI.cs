using Managers;
using Unit;
using UnityEngine;

namespace UI.WorkingSceneUI
{
    public class RedCrossUI : MonoBehaviour
    {
        [SerializeField] private GameObject _redCrossUI;
        [SerializeField] private Unit.Unit _unit;
        [SerializeField] private UnitEconomy _unitEconomy;

        private void Start()
        {
            HideUI();

            _unitEconomy.OnUnitReadyToReceiveMoney += UnitEconomy_OnUnitReadyToReceiveMoney;
            DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
            ResolveWorkIssueUI.OnResolvedWorkIssue += ResolveWorkIssueUI_OnResolvedWorkIssue;
            ResolveWorkIssueUI.OnResolvingFailedWorkIssue += ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
        }

        private void OnDestroy()
        {
            _unitEconomy.OnUnitReadyToReceiveMoney -= UnitEconomy_OnUnitReadyToReceiveMoney;
            DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
            ResolveWorkIssueUI.OnResolvedWorkIssue -= ResolveWorkIssueUI_OnResolvedWorkIssue;
            ResolveWorkIssueUI.OnResolvingFailedWorkIssue -= ResolveWorkIssueUI_OnResolvingFailedWorkIssue;
        }

        private void ResolveWorkIssueUI_OnResolvedWorkIssue(object sender, System.EventArgs e)
        {
            Unit.Unit unit = (Unit.Unit)sender;

            if (ReferenceEquals(unit, _unit))
            {
                HideUI();
            }
        }

        private void ResolveWorkIssueUI_OnResolvingFailedWorkIssue(object sender, System.EventArgs e)
        {
            Unit.Unit unit = (Unit.Unit)sender;

            if (ReferenceEquals(unit,_unit))
            {
                HideUI();
            }
        }

        private void UnitEconomy_OnUnitReadyToReceiveMoney(object sender,
            UnitEconomy.UnitReadyToReceiveMoneyEventArgs e)
        {
            // If Unit didn't finish the work successfully, show this UI 
            if (!e.SuccessfullyFinishedWork)
            {
                ShowUI();
            }
        }

        private void DayManager_OnDayEnded(object sender, System.EventArgs e)
        {
            HideUI();
        }

        private void ShowUI() => _redCrossUI.SetActive(true);

        private void HideUI() => _redCrossUI.SetActive(false);
    }
}
