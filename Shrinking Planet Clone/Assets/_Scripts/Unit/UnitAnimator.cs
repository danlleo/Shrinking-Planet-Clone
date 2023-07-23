using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Unit _unit;

    private void Start()
    {
        if (TryGetComponent<Unit>(out Unit unit))
        {
            _unit = unit;

            _unit.OnUnitMoved += Unit_OnUnitMoved;
            _unit.OnUnitBeganWork += Unit_OnUnitBeganWork;
            _unit.OnUnitReachedDesk += Unit_OnUnitReachedDesk;
        }

        UnitIdleState.OnUnitSpawned += UnitIdleState_OnUnitSpawned;
    }

    private void OnDestroy()
    {
        UnitIdleState.OnUnitSpawned -= UnitIdleState_OnUnitSpawned;
    }

    private void UnitIdleState_OnUnitSpawned(object sender, System.EventArgs e)
    {
        Unit senderUnit = (Unit)sender;

        if (ReferenceEquals(senderUnit, _unit))
        {
            _animator.SetTrigger(UnitAnimationParams.OnUnitSpawn);
        }
    }

    private void Unit_OnUnitReachedDesk(object sender, System.EventArgs e)
    {
        _animator.SetBool(UnitAnimationParams.IsWalking, false);
    }

    private void Unit_OnUnitBeganWork(object sender, System.EventArgs e)
    {
        _animator.SetBool(UnitAnimationParams.IsWalking, false);
        _animator.SetBool(UnitAnimationParams.IsTyping, true);
    }

    private void Unit_OnUnitMoved(object sender, System.EventArgs e)
    {
        _animator.SetBool(UnitAnimationParams.IsWalking, true);
    }
}
