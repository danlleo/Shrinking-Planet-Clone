using UnityEngine;

namespace Unit
{
    public static class UnitAnimationParams
    {
        public static readonly int IsWalking = Animator.StringToHash("IsWalking");
        public static readonly int IsTyping = Animator.StringToHash("IsTyping");
        public static readonly int OnUnitSpawn = Animator.StringToHash("OnUnitSpawn");
    }
}
