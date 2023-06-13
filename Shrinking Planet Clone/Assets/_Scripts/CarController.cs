using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Transform _planetTransform;

    [SerializeField] private float _speed = 1f;

    private float _radius = 5f;
    private float _azimuth = 0f;
    private float _elevation = 0f;

    private void Start()
    {
        _radius = _planetTransform.localScale.y / 2;
    }

    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        _azimuth += Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        _elevation += Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        float x = _radius * Mathf.Cos(_azimuth) * Mathf.Sin(_elevation);
        float y = _radius * Mathf.Cos(_elevation);
        float z = _radius * Mathf.Sin(_azimuth) * Mathf.Sin(_elevation);

        Vector3 direction = new Vector3(x, y, z);

        transform.position = direction;
    }

    private void Rotation()
    {
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, (transform.position - _planetTransform.position).normalized) * transform.rotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50f * Time.deltaTime);
    }
}
