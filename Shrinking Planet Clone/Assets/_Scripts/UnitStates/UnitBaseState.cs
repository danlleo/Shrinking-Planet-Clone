using UnityEngine;

public abstract class UnitBaseState
{
    public abstract void EnterState(UnitStateManager unitStateManager);

    public abstract void UpdateState(UnitStateManager unitStateManager);
}
