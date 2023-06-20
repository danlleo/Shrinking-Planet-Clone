using UnityEngine;

public class UnitActionSystem : Singleton<UnitActionSystem>
{
    protected override void Awake()
    {
        base.Awake();
    }

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

            selectedUnit = unit;

            return true;
        }

        selectedUnit = null;
        return false;
    }
}
