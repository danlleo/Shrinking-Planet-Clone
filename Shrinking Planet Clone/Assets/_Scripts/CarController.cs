using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";

    [SerializeField] private Transform _raycastHitPoint;
    [SerializeField] private Transform _planetTransform;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 60f;

    private float _rotationAngle;
    private float _radius;

    private RaycastHit _hit;

    private void Start()
    {
        _radius = GetRadius();
    }

    private void Update()
    {
        SetDirectionAndRotation();
    }

    private void FixedUpdate()
    {
        CheckGroundPosition();
    }

    private void SetDirectionAndRotation()
    {
        float horizontal = Input.GetAxis(HORIZONTAL);

        _rotationAngle = Mathf.Clamp(_rotationAngle, -45f, 45f);

        Vector3 eulerRotation = transform.eulerAngles;

        eulerRotation.y = _rotationAngle;

        if (Mathf.Abs(horizontal) > 0f)
        {
            _rotationAngle += Time.deltaTime * _rotationSpeed * horizontal;
        }

        // transform.rotation = Quaternion.Euler(eulerRotation);

        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, (transform.position - _planetTransform.position).normalized) * transform.rotation;

        transform.position = new Vector3(transform.position.x, transform.position.y + _radius, transform.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50f * Time.deltaTime);
        transform.Translate(transform.forward * Time.deltaTime * _moveSpeed);
    }

    private float GetRadius() => (_planetTransform.position - transform.position).magnitude;

    private void CheckGroundPosition() => Physics.Raycast(_raycastHitPoint.position, -_raycastHitPoint.up, out _hit, 0.25f);
}
