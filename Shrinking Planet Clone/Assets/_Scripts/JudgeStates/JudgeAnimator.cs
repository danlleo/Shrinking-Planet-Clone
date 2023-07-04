using UnityEngine;

public class JudgeAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        if (TryGetComponent<Judge>(out Judge judge))
        {
            judge.OnJudgeThinking += Judge_OnJudgeThinking;
        }
    }

    private void Judge_OnJudgeThinking(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(JudgeAnimationParams.IS_THINKING);
    }
}
