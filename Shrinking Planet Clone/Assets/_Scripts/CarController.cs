using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 60f;

    private float _rotationAngle;

    private Vector3 _moveDirection;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        SetDirectionAndRotation();
    }

    private void FixedUpdate()
    {
        Move();   
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

        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position + _moveSpeed * Time.deltaTime * transform.TransformDirection(_moveDirection));
    }
}
