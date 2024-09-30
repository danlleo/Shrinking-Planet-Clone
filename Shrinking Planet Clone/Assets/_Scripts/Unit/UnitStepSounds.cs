using Managers;
using Unit.UnitStates;
using UnityEngine;

namespace Unit
{
    [DisallowMultipleComponent]
    public class UnitStepSounds : MonoBehaviour
    {
        private Unit _unit;

        private float _footstepTimer;
        private readonly float _footstepTimerMax = .525f;

        private bool _isWalking;

        private void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        private void Start()
        {
            UnitWalkingState.OnUnitBeganWalking += UnitWalkingState_OnUnitBeganWalking;
            UnitWalkingState.OnUnitEndedWalking += UnitWalkingState_OnUnitEndedWalking;
        }

        private void OnDestroy()
        {
            UnitWalkingState.OnUnitBeganWalking -= UnitWalkingState_OnUnitBeganWalking;
            UnitWalkingState.OnUnitEndedWalking -= UnitWalkingState_OnUnitEndedWalking;
        }

        private void Update()
        {
            if (!_isWalking) return;
            _footstepTimer -= Time.deltaTime;

            if (!(_footstepTimer <= 0)) return;
            _footstepTimer = _footstepTimerMax;

            float volume = 1f;

            SoundManager.Instance.PlayFootStepsSound(transform.position, volume);
        }

        private void UnitWalkingState_OnUnitBeganWalking(object sender, System.EventArgs e)
        {
            Unit senderUnit = (Unit)sender;

            if (ReferenceEquals(senderUnit, _unit))
            {
                _isWalking = true;
            }
        }

        private void UnitWalkingState_OnUnitEndedWalking(object sender, System.EventArgs e)
        {
            Unit senderUnit = (Unit)sender;

            if (!ReferenceEquals(senderUnit, _unit)) return;
            _isWalking = false;
            Destroy(this);
        }
    }
}
