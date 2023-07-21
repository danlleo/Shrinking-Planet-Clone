using UnityEngine;

public class UnitThirsty : MonoBehaviour, IInteractable
{
    [SerializeField] private Unit _unit;
    [SerializeField] private UnitNeed _unitNeed;
    [SerializeField] private UnitNeedType _unitNeedType;

    public void Interact()
    {
        if (!InteractSystem.Instance.AreHandsBusy())
            return;

        if (UnitNeedManager.Instance.GetCurrentNeed().Type == _unitNeedType)
        {
            _unit.InvokeUnitNeedFulfilled();

            InteractSystem.Instance.SetHandsFree();
            return;
        }
    }
}
