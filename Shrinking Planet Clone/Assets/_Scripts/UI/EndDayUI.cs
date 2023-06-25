using System.Collections.Generic;
using UnityEngine;

public class EndDayUI : MonoBehaviour
{
    [SerializeField] private GameObject _endDayUI;

    private void Start()
    {
        Hide();
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        Show();

        List<Unit> unitList = UnitManager.Instance.GetAllUnits();

        foreach (Unit unit in unitList)
        {
            print(unit.GetUnitName());
        }
    }

    private void Show() => _endDayUI.SetActive(true);

    private void Hide() => _endDayUI.SetActive(false);
}
