using UnityEngine;

public class UnitActionSystem : Singleton<UnitActionSystem>
{
    private Unit _selectedUnit;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Update()
    {
        if (InputManager.Instance.IsMouseButtonDownThisFrame())
        {
            Vector3 cameraPosition = Camera.main.transform.position;

            if (!Physics.Raycast(cameraPosition, MouseWorld.GetPosition() - cameraPosition, out RaycastHit hitInfo, float.MaxValue))
                return;

            if (!hitInfo.collider.TryGetComponent(out Unit unit))
                return;

            if (unit == _selectedUnit)
                return;

            HandleUnitSelection(unit);
        }

        if (InputManager.Instance.IsRightMouseButtonDownThisFrame())
        {
            if (_selectedUnit == null)
                return;
        }
    }

    private void HandleUnitSelection(Unit unit) => _selectedUnit = unit;
}
