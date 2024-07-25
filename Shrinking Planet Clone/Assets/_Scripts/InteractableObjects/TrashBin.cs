using Managers;
using UnityEngine;

namespace InteractableObjects
{
    public class TrashBin : MonoBehaviour, IInteractable, ISelectable
    {
        private const int DefaultLayer = 0;
        private const int OutlineLayer = 31;

        [SerializeField] private UnitNeedType _unitNeedType;
        [SerializeField] private GameObject _trashBinVisual;

        public void Interact()
        {
            if (!InteractSystem.Instance.AreHandsBusy())
                return;

            if (UnitNeedManager.Instance.GetCurrentNeed().Type != _unitNeedType) return;
            SoundManager.Instance.PlayTrashDisposeSound();

            Unit.Unit unit = UnitNeedManager.Instance.GetUnitWithNeed();

            unit.InvokeUnitNeedFulfilled();
            InteractSystem.Instance.SetHandsFree();
            InteractSystem.Instance.InvokeObjectDrop();
        }

        public void OnMouseEnter()
        {
            SoundManager.Instance.PlayUnitMouseHover();
            ChangeLayerInObject(_trashBinVisual, OutlineLayer);
        }

        public void OnMouseExit()
        {
            ChangeLayerInObject(_trashBinVisual, DefaultLayer);
        }

        public void ChangeLayerInObject(GameObject targetObject, int newLayer)
        {
            targetObject.layer = newLayer;
        }
    }
}
