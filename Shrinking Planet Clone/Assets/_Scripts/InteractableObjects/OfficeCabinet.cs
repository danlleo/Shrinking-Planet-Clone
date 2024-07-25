using Managers;
using UnityEngine;

public class OfficeCabinet : MonoBehaviour, IInteractable, ISelectable
{
    private const int DEFAULT_LAYER = 0;
    private const int OUTLINE_LAYER = 31;

    [SerializeField] private GameObject _officeCabinetVisual;
    [SerializeField] private UnitNeedType _unitNeedType;

    public void Interact()
    {
        if (!InteractSystem.Instance.AreHandsBusy())
            return;

        if (UnitNeedManager.Instance.GetCurrentNeed().Type == _unitNeedType)
        {
            SoundManager.Instance.PlayDocumentDeliveredSound();

            Unit.Unit unit = UnitNeedManager.Instance.GetUnitWithNeed();

            unit.InvokeUnitNeedFulfilled();
            InteractSystem.Instance.SetHandsFree();
            InteractSystem.Instance.InvokeObjectDrop();

            return;
        }
    }

    public void OnMouseEnter()
    {
        SoundManager.Instance.PlayUnitMouseHover();
        ChangeLayerInObject(_officeCabinetVisual, OUTLINE_LAYER);
    }

    public void OnMouseExit()
    {
        ChangeLayerInObject(_officeCabinetVisual, DEFAULT_LAYER);
    }

    public void ChangeLayerInObject(GameObject targetObject, int newLayer)
    {
        targetObject.layer = newLayer;
    }
}
