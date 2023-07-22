using System;
using UnityEngine;

public class InteractSystem : Singleton<InteractSystem>
{
    public event EventHandler<ObjectPickUpArgs> OnObjectPickUp;

    public class ObjectPickUpArgs : EventArgs
    {
        public Sprite ObjectSprite;

        public ObjectPickUpArgs (Sprite objectSprite)
        {
            ObjectSprite = objectSprite;
        }
    }

    public event EventHandler OnObjectDrop;

    private Camera _camera;

    private bool _areHandsBusy;

    private UnitNeedType _unitNeedType;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (!InputManager.Instance.IsMouseButtonDownThisFrame())
            return;

        Vector3 cameraPosition = _camera.transform.position;

        if (Physics.Raycast(_camera.transform.position, MouseWorld.GetPosition() - cameraPosition, out RaycastHit hitInfo, float.MaxValue))
        {
            if (hitInfo.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
                return;
            }
            else
            {
                SetHandsFree();
                InvokeObjectDrop();
            }
        }
    }

    public void SetHandsBusyBy(UnitNeedType unitNeedType)
    {
        _areHandsBusy = true;
        _unitNeedType = unitNeedType;
    }

    public void SetHandsFree() => _areHandsBusy = false;

    public bool AreHandsBusy() => _areHandsBusy;

    public void InvokeObjectPickUp(Sprite sprite) => OnObjectPickUp?.Invoke(this, new ObjectPickUpArgs(sprite));

    public void InvokeObjectDrop() => OnObjectDrop?.Invoke(this, EventArgs.Empty);
}
