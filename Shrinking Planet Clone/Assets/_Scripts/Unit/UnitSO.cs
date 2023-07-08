using UnityEngine;

[CreateAssetMenu()]
public class UnitSO : ScriptableObject
{
    public string UnitName;
    public string Greetings;
    public UnitOccupationTypes DefaultOccupation;
    public Vector3 UnitSpawnPosition;
    public Vector3 UnitTargetDeskPosition;
    public Sprite UnitDisplayImage;
}
