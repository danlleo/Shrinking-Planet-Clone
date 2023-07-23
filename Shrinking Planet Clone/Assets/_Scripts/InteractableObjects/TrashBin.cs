using UnityEngine;

public class TrashBin : MonoBehaviour, IInteractable, ISelectable
{
    private const int DEFAULT_LAYER = 0;
    private const int OUTLINE_LAYER = 31;

    [SerializeField] private UnitNeedType _unitNeedType;
    [SerializeField] private GameObject _trashBinVisual;

    public void Interact()
    {
        if (!InteractSystem.Instance.AreHandsBusy())
            return;

        if (UnitNeedManager.Instance.GetCurrentNeed().Type == _unitNeedType)
        {
            SoundManager.Instance.PlayTrashDisposeSound();

            Unit unit = UnitNeedManager.Instance.GetUnitWithNeed();

            unit.InvokeUnitNeedFulfilled();
            InteractSystem.Instance.SetHandsFree();
            InteractSystem.Instance.InvokeObjectDrop();

            return;
        }
    }

    public void OnMouseEnter()
    {
        SoundManager.Instance.PlayUnitMouseHover();
        ChangeLayerInObject(_trashBinVisual, OUTLINE_LAYER);
    }

    public void OnMouseExit()
    {
        ChangeLayerInObject(_trashBinVisual, DEFAULT_LAYER);
    }

    public void ChangeLayerInObject(GameObject targetObject, int newLayer)
    {
        targetObject.layer = newLayer;
    }
}
