using UnityEngine;

public class OfficeCabinet : MonoBehaviour, IInteractable
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

            print("Placed documents");

            return;
        }
    }
}
