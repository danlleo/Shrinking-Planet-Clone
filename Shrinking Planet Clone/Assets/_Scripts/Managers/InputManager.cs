using UnityEngine;

namespace Managers
{
    public class InputManager : Singleton<InputManager>
    {
        public bool IsMouseButtonDownThisFrame() => Input.GetMouseButtonDown(0);

        public bool IsRightMouseButtonDownThisFrame() => Input.GetMouseButtonDown(1);

        public bool IsPauseButtonDownThisFrame() => Input.GetKeyDown(KeyCode.Escape);

        public Vector2 GetMouseScreenPosition() => Input.mousePosition;
    }
}
