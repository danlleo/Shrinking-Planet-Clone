[System.Serializable]
public class UnitData
{
    public string UnitSOName;

    public UnitData(Unit unit)
    {
        UnitSOName = unit.GetUnitSOName();
    }
}
