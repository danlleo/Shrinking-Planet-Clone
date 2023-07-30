using System;
using UnityEngine;

public class UnitIdleState : UnitBaseState
{
    public static event EventHandler OnUnitSpawned;

    private float _timer;

    public override void EnterState(UnitStateManager unitStateManager)
    {
        Unit unit = unitStateManager.GetComponent<Unit>();

        OnUnitSpawned?.Invoke(unit, EventArgs.Empty);
        _timer = 0f;
    }

    public override void UpdateState(UnitStateManager unitStateManager)
    {
        _timer += Time.deltaTime;

        if (_timer >= 3f)
            unitStateManager.SwitchState(unitStateManager._walkingState);
    }

    public override void ExitState()
    {
        // ...
    }
}
