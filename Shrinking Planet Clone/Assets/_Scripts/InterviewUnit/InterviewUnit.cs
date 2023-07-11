using UnityEngine;

public class InterviewUnit : MonoBehaviour
{
    private UnitSO _unitSO;

    public void Setup(Vector3 spawnPosition, UnitSO unitSO)
    {
        transform.position = spawnPosition;
        _unitSO = unitSO;
    }

    public Sprite GetInterviewUnitSprite() => _unitSO.UnitOccupationImage;

    public UnitOccupationType GetInterviewUnitOccupationType() => _unitSO.DefaultOccupation;
}
