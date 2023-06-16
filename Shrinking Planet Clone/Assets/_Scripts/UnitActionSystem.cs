using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    private Unit _selectedUnit;

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
            {
                print("Idi v zhopu");
                return;
            }

            HandleUnitSelection(unit);
        }
    }

    private void HandleUnitSelection(Unit unit)
    {
        unit.Fart();
        _selectedUnit = unit;
    }
}
