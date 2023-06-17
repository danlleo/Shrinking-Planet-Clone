using UnityEngine;

public class MoveAction : BaseAction
{
    private float _moveSpeed = 4f;
    private float _rotateSpeed = 10f;
    private float _stoppingDistance = .1f;

    private void Update()
    {
        if (!_isActive)
            return;

        Vector3 moveDirection = (_unit.GetUnitDeskPosition() - transform.position).normalized;

        // Set rotation in which Unit is looking
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * _rotateSpeed);

        if (Vector3.Distance(transform.position, _unit.GetUnitDeskPosition()) > _stoppingDistance)
        {
            // If can move -> move
            transform.position += _moveSpeed * Time.deltaTime * moveDirection;
        }
    }
}
