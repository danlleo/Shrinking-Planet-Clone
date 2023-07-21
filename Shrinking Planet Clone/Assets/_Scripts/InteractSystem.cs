using UnityEngine;

public class InteractSystem : MonoBehaviour
{
    private Camera _camera;

    private bool _areHandsBusy;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!InputManager.Instance.IsMouseButtonDownThisFrame())
            return;

        if (_areHandsBusy)
            return;

        Vector3 cameraPosition = _camera.transform.position;

        if (Physics.Raycast(_camera.transform.position, MouseWorld.GetPosition() - cameraPosition, out RaycastHit hitInfo, float.MaxValue))
        {
            if (hitInfo.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}
