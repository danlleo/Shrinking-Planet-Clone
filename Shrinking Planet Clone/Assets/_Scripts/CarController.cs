using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Transform _raycastHitPoint;
    [SerializeField] private Transform _planetTransform;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 60f;

    private float _verticalCarPlaceOffset = .1f;

    private float _rotationAngle;

    private Vector3 _moveDirection;
    private RaycastHit _hit;

    private void Update()
    {
        SetDirectionAndRotation();
        PlaceCar();
    }

    private void SetDirectionAndRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _rotationAngle = Mathf.Clamp(_rotationAngle, -45f, 45f);
        _moveDirection = new Vector3(0f, 0f, vertical).normalized;

        Vector3 eulerRotation = transform.eulerAngles;

        eulerRotation.y = _rotationAngle;

        if (Mathf.Abs(horizontal) > 0f)
        {
            _rotationAngle += Time.deltaTime * _rotationSpeed * horizontal;
        }

        //transform.rotation = Quaternion.Euler(eulerRotation);

        transform.Translate(transform.forward * Time.deltaTime * 10f);

        Vector3 normalizedVectorRotation = GetNormalizedVerticalRotation();
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, (transform.position - _planetTransform.position).normalized) * transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50f * Time.deltaTime);
    }

    private Vector3 GetNormalizedVerticalRotation()
    {
        Vector3 verticalRotation = Vector3.zero;

        if (Physics.Raycast(_raycastHitPoint.position, -_raycastHitPoint.up, out _hit, 0.25f))
        {
            verticalRotation = (_hit.point - _raycastHitPoint.position).normalized;
        }

        return verticalRotation;
    }

    private void PlaceCar()
    {
        if (_hit.point.magnitude > 0f)
        {
            transform.position = _hit.point + transform.up * _verticalCarPlaceOffset;
        }
    }
}
