using UnityEngine;

[CreateAssetMenu()]
public class UnitSO : ScriptableObject
{
    public string UnitName;
    public string Greetings;
    public UnitOccupationType DefaultOccupation;
    public Vector3 UnitSpawnPosition;
    public Vector3 UnitSpawnRotation;
    public Vector3 UnitTargetDeskPosition;
    public Vector3 UnitTargetReachedDeskRotation;
    public Sprite UnitDisplayImage;
    public Sprite UnitOccupationImage;
}
