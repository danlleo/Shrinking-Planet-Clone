[System.Serializable]
public class UnitData
{
    public string UnitSOName;
    public int UnitLevel;
    public int UnitLelfOverXPs;

    public UnitData(Unit unit, int unitLevel, int unitLelfOverXPs)
    {
        UnitSOName = unit.GetUnitSOName();
        UnitLevel = unitLevel;
        UnitLelfOverXPs = unitLelfOverXPs;
    }
}
