using System.Collections.Generic;
using UnityEngine;

public class UnitLevelUpSystem : Singleton<UnitLevelUpSystem>
{
    private int _XPToNextLevel = 100;

    protected override void Awake()
    {
        base.Awake();
    }

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
        int unitCurrentXP = unitLevel.GetUnitCurrentXPValue();

        if (unitCurrentXP <= _XPToNextLevel)
        {
            unitLevel.SetUnitPreviousXP(unitCurrentXP);
            print("Unit Level Stays The Same");
            return;
        }

        unitLevel.IncreaseUnitLevel();
        unitLevel.SetUnitPreviousXP(0);
        unitLevel.SetUnitCurrentXP(unitCurrentXP - _XPToNextLevel);
        print("Unit Level Increased");
        CheckLevelUp(unitLevel);
    }

    public int GetXPToNextLevel() => _XPToNextLevel;
}
