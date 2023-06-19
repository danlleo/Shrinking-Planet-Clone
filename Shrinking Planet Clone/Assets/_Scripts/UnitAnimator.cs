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
        }
    }

    private void Unit_OnUnitMoved(object sender, System.EventArgs e)
    {
        _animator.SetBool(UnitAnimationParams.IS_WALKING, true);
    }

    private void Unit_OnUnitSpawned(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(UnitAnimationParams.ON_UNIT_SPAWN);
    }
}
