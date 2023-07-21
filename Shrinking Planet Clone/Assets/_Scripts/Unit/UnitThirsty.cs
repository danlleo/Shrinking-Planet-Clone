using UnityEngine;

public class UnitThirsty : MonoBehaviour, IInteractable
{
    [SerializeField] private Unit _unit;
    [SerializeField] private UnitNeedType _unitNeedType;

    public void Interact()
    {
        if (!InteractSystem.Instance.AreHandsBusy())
            return;

        if (UnitNeedManager.Instance.GetCurrentNeed().Type == _unitNeedType)
        {
            _unit.InvokeUnitNeedFulfilled();

            print("Drank water");

            return;
        }
    }
}
