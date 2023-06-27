using System.Collections.Generic;
using UnityEngine;

public class UnitLevelUpSystem : MonoBehaviour
{
    private int _XPToNextLevel = 300;

    private void Start()
    {
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        List<Unit> units = UnitManager.Instance.GetAllUnits();

        foreach (var unit in units)
        {
            UnitLevel unitLevel = unit.GetComponent<UnitLevel>();

            if (unitLevel != null)
            {
                CheckLevelUp(unitLevel);
            }
        }
    }

    private void CheckLevelUp(UnitLevel unitLevel)
    {
        int unitCurrentXP = unitLevel.GetUnitCurrentXP();

        if (unitCurrentXP >= _XPToNextLevel)
        {
            unitLevel.IncreaseUnitLevel();
            unitLevel.SetUnitXP(unitCurrentXP - _XPToNextLevel);
            print("Unit Level Increased");
        }
        else
        {
            print("Unit Level Stays The Same");
        }
    }
}
