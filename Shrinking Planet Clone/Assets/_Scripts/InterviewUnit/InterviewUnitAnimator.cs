using UnityEngine;

public class InterviewUnitAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private InterviewUnit _interviewUnit;

    private void Start()
    {
        InterviewUnit.OnInterviewUnitAnswered += InterviewUnit_OnInterviewUnitAnswered;
    }

    private void OnDestroy()
    {
        InterviewUnit.OnInterviewUnitAnswered -= InterviewUnit_OnInterviewUnitAnswered;
    }

    private void InterviewUnit_OnInterviewUnitAnswered(object sender, InterviewUnit.InterviewUnitAnsweredEventArgs e)
    {
        _animator.SetTrigger(InterviewUnitAnimationParams.IsTalking);
    }
}
