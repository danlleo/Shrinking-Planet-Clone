using UnityEngine;
using UnityEngine.EventSystems;

public class UnitActionSystem : Singleton<UnitActionSystem>
{
    protected override void Awake()
    {
        base.Awake();
    }

    // Refactor this later...
    public bool TryGetSelectedUnit(out Unit selectedUnit)
    {
        if (InputManager.Instance.IsMouseButtonDownThisFrame())
        {
            Vector3 cameraPosition = Camera.main.transform.position;

            if (!Physics.Raycast(cameraPosition, MouseWorld.GetPosition() - cameraPosition, out RaycastHit hitInfo, float.MaxValue))
            {
                selectedUnit = null;
                return false;
            }

            if (!hitInfo.collider.TryGetComponent(out Unit unit))
            {
                selectedUnit = null;
                return false;
            }

            // If mouse pointer is over UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                selectedUnit = null;
                return false;
            }

            selectedUnit = unit;
            return true;
        }

        selectedUnit = null;
        return false;
    }
}
