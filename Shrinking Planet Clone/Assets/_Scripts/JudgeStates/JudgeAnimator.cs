using UnityEngine;

public class JudgeAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        Judge.OnJudgeThinking += Judge_OnJudgeThinking;
        Judge.OnJudgeAsking += Judge_OnJudgeAsking;
        Judge.OnJudgeReceivedAnswer += Judge_OnJudgeReceivedAnswer;
    }

    private void Judge_OnJudgeReceivedAnswer(object sender, Judge.ReceivedAnswerArgs e)
    {
        if (e.IsAnswerCorrect)
        {
            _animator.SetTrigger(JudgeAnimationParams.HasLost);
            return;
        }

        _animator.SetTrigger(JudgeAnimationParams.HasWon);
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
