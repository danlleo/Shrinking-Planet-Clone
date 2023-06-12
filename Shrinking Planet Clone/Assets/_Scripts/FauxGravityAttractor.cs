using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour
{
    [SerializeField] private float _gravity = -30f;

    public void Attract(Transform bodyToAttract)
    {
        Vector3 gravityUp = (bodyToAttract.position - transform.position).normalized;
        Vector3 bodyToActtractUp = bodyToAttract.up;

        bodyToAttract.GetComponent<Rigidbody>().AddForce(gravityUp * _gravity);

        Quaternion targetRotation = Quaternion.FromToRotation(bodyToActtractUp, gravityUp) * bodyToAttract.rotation;

        bodyToAttract.rotation = Quaternion.Slerp(bodyToAttract.rotation, targetRotation, 50 * Time.deltaTime);
    }
}
