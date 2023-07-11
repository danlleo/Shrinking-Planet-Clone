using UnityEngine;

public class JudgeAnimationParams : MonoBehaviour
{
    public static readonly int IsThinking = Animator.StringToHash("IsThinking");
    public static readonly int IsAsking = Animator.StringToHash("IsAsking");
    public static readonly int HasWon = Animator.StringToHash("HasWon");
    public static readonly int HasLost = Animator.StringToHash("HasLost");
}
