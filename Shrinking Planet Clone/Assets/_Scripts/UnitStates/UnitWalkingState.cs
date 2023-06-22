using UnityEngine;

public class UnitWalkingState : UnitBaseState
{
    private Unit _unit;

    private float _moveSpeed = 4f;
    private float _rotateSpeed = 10f;
    private float _stoppingDistance = .1f;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _unit = unitStateManager.GetComponent<Unit>();
        _unit.InvokeUnitMovedEvent();
    }

    public override void UpdateState(UnitStateManager unitStateManager)
    {
        Vector3 moveDirection = (_unit.GetUnitDeskPosition() - _unit.transform.position).normalized;

        // Set rotation in which Unit is looking
        _unit.transform.forward = Vector3.Slerp(_unit.transform.forward, moveDirection, Time.deltaTime * _rotateSpeed);

        if (Vector3.Distance(_unit.transform.position, _unit.GetUnitDeskPosition()) > _stoppingDistance)
        {
            // If can move -> move
            _unit.transform.position += _moveSpeed * Time.deltaTime * moveDirection;
        }
        else
        {
            unitStateManager.SwitchState(unitStateManager._reachedDeskState);
        }
    }
}
