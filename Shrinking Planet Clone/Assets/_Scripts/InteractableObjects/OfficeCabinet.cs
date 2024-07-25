using Managers;
using UnityEngine;

namespace InteractableObjects
{
    public class OfficeCabinet : MonoBehaviour, IInteractable, ISelectable
    {
        private const int DefaultLayer = 0;
        private const int OutlineLayer = 31;

        [SerializeField] private GameObject _officeCabinetVisual;
        [SerializeField] private UnitNeedType _unitNeedType;

        public void Interact()
        {
            if (!InteractSystem.Instance.AreHandsBusy())
                return;

            if (UnitNeedManager.Instance.GetCurrentNeed().Type != _unitNeedType) return;
            SoundManager.Instance.PlayDocumentDeliveredSound();

            Unit.Unit unit = UnitNeedManager.Instance.GetUnitWithNeed();

            unit.InvokeUnitNeedFulfilled();
            InteractSystem.Instance.SetHandsFree();
            InteractSystem.Instance.InvokeObjectDrop();
        }

        public void OnMouseEnter()
        {
            SoundManager.Instance.PlayUnitMouseHover();
            ChangeLayerInObject(_officeCabinetVisual, OutlineLayer);
        }

        public void OnMouseExit()
        {
            ChangeLayerInObject(_officeCabinetVisual, DefaultLayer);
        }

        public void ChangeLayerInObject(GameObject targetObject, int newLayer)
        {
            targetObject.layer = newLayer;
        }
    }
}
