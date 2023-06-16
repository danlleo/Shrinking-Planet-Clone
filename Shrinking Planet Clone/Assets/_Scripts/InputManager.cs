using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public bool IsMouseButtonDownThisFrame() => Input.GetMouseButtonDown(0);

    public Vector2 GetMouseScreenPosition() => Input.mousePosition;
}
