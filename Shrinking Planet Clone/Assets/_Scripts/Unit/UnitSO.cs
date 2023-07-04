using UnityEngine;

[CreateAssetMenu()]
public class UnitSO : ScriptableObject
{
    public string UnitName;
    public string Greetings;
    public UnitOccupationType DefaultOccupation;
    public Vector3 UnitTargetDeskPosition;
    public Sprite UnitDisplayImage;
}
