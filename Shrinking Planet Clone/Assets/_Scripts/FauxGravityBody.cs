using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    [SerializeField] private FauxGravityAttractor _attractor;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _rb.useGravity = false;
    }

    private void Update()
    {
        _attractor.Attract(transform);
    }
}
