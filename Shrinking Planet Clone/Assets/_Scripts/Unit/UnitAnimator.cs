using UnityEngine;

public class UnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        if (TryGetComponent<Unit>(out Unit unit))
        {
            unit.OnUnitSpawned += Unit_OnUnitSpawned;
            unit.OnUnitMoved += Unit_OnUnitMoved;
            unit.OnUnitBeganWork += Unit_OnUnitBeganWork;
            unit.OnUnitReachedDesk += Unit_OnUnitReachedDesk;
        }
    }

    private void OnDestroy()
    {
        // Think about it here later
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

    private void Unit_OnUnitSpawned(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(UnitAnimationParams.OnUnitSpawn);
    }
}
