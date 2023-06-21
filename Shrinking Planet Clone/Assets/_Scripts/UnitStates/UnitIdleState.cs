using UnityEngine;

public class UnitIdleState : UnitBaseState
{
    private float _timer;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        _timer = 0f;
    }

    public override void UpdateState(UnitStateManager unitStateManager)
    {
        _timer += Time.deltaTime;

        if (_timer >= 5f)
            unitStateManager.SwitchState(unitStateManager._walkingState);
    }
}
