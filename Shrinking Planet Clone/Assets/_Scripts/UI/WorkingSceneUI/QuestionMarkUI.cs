using UnityEngine;

public class QuestionMarkUI : MonoBehaviour
{
    [SerializeField] private GameObject _questionMarkUI;
    [SerializeField] private Unit.Unit _unit;

    private void Start()
    {
        _unit.OnUnitReachedDesk += Unit_OnUnitReachedDesk;
        _unit.OnUnitBeganWork += Unit_OnUnitBeganWork;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void OnDestroy()
    {
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void Unit_OnUnitBeganWork(object sender, System.EventArgs e)
    {
        HideUI();
    }

    private void Unit_OnUnitReachedDesk(object sender, System.EventArgs e)
    {
        ShowUI();
    }
    
    private void ShowUI() => _questionMarkUI.SetActive(true); 

    private void HideUI() => _questionMarkUI.SetActive(false);
}
