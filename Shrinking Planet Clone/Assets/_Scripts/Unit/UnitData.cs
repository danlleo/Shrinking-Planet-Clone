[System.Serializable]
public class UnitData
{
    public string UnitSOName;
    public int UnitLevel;
    public int UnitLelfOverXPs;

    public UnitData(string unitSOName, int unitLevel, int unitLelfOverXPs)
    {
        UnitSOName = unitSOName;
        UnitLevel = unitLevel;
        UnitLelfOverXPs = unitLelfOverXPs;
    }
}
