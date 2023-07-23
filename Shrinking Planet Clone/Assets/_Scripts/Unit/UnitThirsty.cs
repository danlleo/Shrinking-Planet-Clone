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

        if (UnitNeedManager.Instance.GetCurrentNeed().Type == _unitNeedType && _unit.GetUnitRequestedNeed().Type == _unitNeedType)
        {
            _unit.InvokeUnitNeedFulfilled();

            SoundManager.Instance.PlayWaterDrankSound();

            InteractSystem.Instance.SetHandsFree();
            InteractSystem.Instance.InvokeObjectDrop();

            return;
        }
    }
}
