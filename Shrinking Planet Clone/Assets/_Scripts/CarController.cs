using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
    }

    private void Move()
    {
        _rb.MovePosition(_rb.position + _moveSpeed * Time.deltaTime * transform.TransformDirection(_moveDirection));
    }
}
