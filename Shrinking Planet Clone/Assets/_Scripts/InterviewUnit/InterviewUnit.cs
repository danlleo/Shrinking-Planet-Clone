using UnityEngine;

public class InterviewUnit : MonoBehaviour, ISelectable
{
    private const int DEFAULT_LAYER = 0;
    private const int OUTLINE_LAYER = 31;

    [SerializeField] private GameObject _unitVisual;

    private UnitSO _unitSO;

    public void Setup(Vector3 spawnPosition, UnitSO unitSO)
    {
        transform.position = spawnPosition;
        _unitSO = unitSO;
    }

    public Sprite GetInterviewUnitSprite() => _unitSO.UnitOccupationImage;

    public UnitOccupationType GetInterviewUnitOccupationType() => _unitSO.DefaultOccupation;

    public void OnMouseEnter()
    {
        ChangeLayerInObject(_unitVisual, OUTLINE_LAYER);
    }

    public void OnMouseExit()
    {
        ChangeLayerInObject(_unitVisual, DEFAULT_LAYER);
    }

    public void ChangeLayerInObject(GameObject targetObject, int newLayer)
    {
        targetObject.layer = newLayer;
    }
}
