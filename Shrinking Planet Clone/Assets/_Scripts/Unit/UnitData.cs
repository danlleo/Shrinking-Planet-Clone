using UnityEngine;

[System.Serializable]
public class UnitData
{
    public string UnitSOName;
    public string UnitName;
    public string UnitGreetings;
    public string UnitDefaultOccupation;
    public float[] UnitSpawnPosition;
    public float[] UnitTargetDeskPosition;

    public UnitData(Unit unit)
    {
        UnitSOName = unit.GetUnitSOName();

        Vector3 unitSpawnPosition = unit.GetUnitSpawnPosition();
        Vector3 unitTargetDeskPosition = unit.GetUnitDeskPosition();

        UnitSpawnPosition = new float[]
        {
            unitSpawnPosition.x,
            unitSpawnPosition.y,
            unitSpawnPosition.z,
        };

        UnitTargetDeskPosition = new float[]
        {
            unitTargetDeskPosition.x,
            unitTargetDeskPosition.y,
            unitTargetDeskPosition.z,
        };
    }
}
