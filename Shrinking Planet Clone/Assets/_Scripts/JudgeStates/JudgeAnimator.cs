using UnityEngine;

public class JudgeAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        Judge.OnJudgeThinking += Judge_OnJudgeThinking;
        Judge.OnJudgeAsking += Judge_OnJudgeAsking;
    }

    private void Judge_OnJudgeAsking(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(JudgeAnimationParams.IsAsking);
    }

    private void Judge_OnJudgeThinking(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(JudgeAnimationParams.IsThinking);
    }
}
