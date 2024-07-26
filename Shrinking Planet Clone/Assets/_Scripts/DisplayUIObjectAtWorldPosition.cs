using UnityEngine;

[DisallowMultipleComponent]
public class DisplayUIObjectAtWorldPosition : MonoBehaviour
{
    [Header("External References")]
    [SerializeField] private Transform _followObject;
    
    [Header("Settings")]
    [SerializeField] private Vector2 _offset;

    private void Update()
    {
        KeepAtWorldPosition();
    }

    private void KeepAtWorldPosition()
    {
        transform.position =
            RectTransformUtility.WorldToScreenPoint(Camera.main, _followObject.transform.TransformPoint(Vector3.zero)) +
            _offset;
    }
}
