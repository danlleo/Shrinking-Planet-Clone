using UnityEngine;

public class TrashBin : MonoBehaviour, IInteractable
{
    [SerializeField] private UnitNeedType _unitNeedType;

    public void Interact()
    {
        if (!InteractSystem.Instance.AreHandsBusy()) 
            return;

        if (UnitNeedManager.Instance.GetCurrentNeed().Type == _unitNeedType)
        {
            Unit unit = UnitNeedManager.Instance.GetUnitWithNeed();

            unit.InvokeUnitNeedFulfilled();
            InteractSystem.Instance.SetHandsFree();
            InteractSystem.Instance.InvokeObjectDrop();

            print("Recycled");

            return;
        }
    }
}
