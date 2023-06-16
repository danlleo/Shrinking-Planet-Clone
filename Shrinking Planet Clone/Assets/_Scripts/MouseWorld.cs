using UnityEngine;

public class MouseWorld : Singleton<MouseWorld>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(InputManager.Instance.GetMouseScreenPosition());

        Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue);

        return hitInfo.point;
    }
}
