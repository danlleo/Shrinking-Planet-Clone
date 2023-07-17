using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewCameraManager : Singleton<InterviewCameraManager>
{
    private const float DEFAULT_CAMERA_MOVE_DELAY_TIME = 1f;

    [Header("Main pointing cameras transform")]
    [SerializeField] private InterviewCameraTransform _defaultCamera;
    [SerializeField] private InterviewCameraTransform _judgeLockCamera;
    [SerializeField] private InterviewCameraTransform _unitsLockCamera;

    [Header("Interview Units pointing cameras transform")]
    [SerializeField] private InterviewCameraTransform _interviewUnitACamera;
    [SerializeField] private InterviewCameraTransform _interviewUnitBCamera;
    [SerializeField] private InterviewCameraTransform _interviewUnitCCamera;

    private InterviewCameraTransform _previousInterviewCameraTransform;
    private Camera _camera;

    private bool _isAnswerCorrect;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
        _previousInterviewCameraTransform = _defaultCamera;
    }

    private void Start()
    {
        JudgeIdleState.OnJudgeEnteredIdleState += JudgeIdleState_OnJudgeEnteredIdleState;
        Judge.OnJudgeAsking += Judge_OnJudgeAsking;
        Judge.OnJudgeReviewingAnswer += Judge_OnJudgeReviewingAnswer;
        Judge.OnJudgeCameraFocus += Judge_OnJudgeCameraFocus;
        Judge.OnJudgeFinishedJob += Judge_OnJudgeFinishedJob;
        InterviewUnit.OnInterviewUnitAnswered += InterviewUnit_OnInterviewUnitAnswered;
    }

    private void OnDestroy()
    {
        JudgeIdleState.OnJudgeEnteredIdleState -= JudgeIdleState_OnJudgeEnteredIdleState;
        Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
        Judge.OnJudgeReviewingAnswer -= Judge_OnJudgeReviewingAnswer;
        Judge.OnJudgeCameraFocus -= Judge_OnJudgeCameraFocus;
        Judge.OnJudgeFinishedJob -= Judge_OnJudgeFinishedJob;
        InterviewUnit.OnInterviewUnitAnswered += InterviewUnit_OnInterviewUnitAnswered;
    }

    private void Judge_OnJudgeCameraFocus(object sender, EventArgs e)
    {
        Judge judge = (Judge)sender;

        Action extraLogic = () =>
        {
            judge.InvokeJudgeReviewedAnswerEvent(_isAnswerCorrect);
        };

        StartCoroutine(MoveCameraInSecondsRoutine(_judgeLockCamera, 1f, 0f, extraLogic));
    }

    private void Judge_OnJudgeReviewingAnswer(object sender, EventArgs e)
    {
        StartCoroutine(MoveCameraInSecondsRoutine(_judgeLockCamera, 1f, 0f));
    }

    private void InterviewUnit_OnInterviewUnitAnswered(object sender, InterviewUnit.InterviewUnitAnsweredEventArgs e)
    {
        _isAnswerCorrect = e.IsAnswerCorrect;
        StartCoroutine(MoveCameraInSecondsRoutine(e.UnitInterviewCameraTransform, 1f, 0f));
    }

    private void Judge_OnJudgeFinishedJob(object sender, EventArgs e)
    {
        StartCoroutine(MoveCameraInSecondsRoutine(_defaultCamera, 1f));
    }

    private void Judge_OnJudgeAsking(object sender, EventArgs e)
    {
        StartCoroutine(MoveCameraInSecondsRoutine(_unitsLockCamera, 1f));
    }

    private void JudgeIdleState_OnJudgeEnteredIdleState(object sender, EventArgs e)
    {
        StartCoroutine(MoveCameraInSecondsRoutine(_judgeLockCamera, 1f, 0f));
    }

    private IEnumerator MoveCameraInSecondsRoutine(
            InterviewCameraTransform interviewCameraTransform, 
            float maxTimeInSeconds, 
            float delayTime = DEFAULT_CAMERA_MOVE_DELAY_TIME, 
            Action action = null
        )
    {
        Vector3 startPosition = _previousInterviewCameraTransform.CameraPosition;
        Vector3 endPosition = interviewCameraTransform.CameraPosition;

        Quaternion startRotation = _previousInterviewCameraTransform.CameraRotation;
        Quaternion endRotation = interviewCameraTransform.CameraRotation;

        float elapsedTime = 0f;
        float normalizedTime = 0f;

        yield return new WaitForSeconds(delayTime);

        SoundManager.Instance.PlayCameraWhooshSound();

        while (elapsedTime <= maxTimeInSeconds)
        {
            elapsedTime += Time.deltaTime;
            normalizedTime = elapsedTime / maxTimeInSeconds;
            _camera.transform.position = Vector3.Lerp(startPosition, endPosition, InterpolateUtils.EaseInOutQuart(normalizedTime));
            _camera.transform.rotation = Quaternion.Lerp(startRotation, endRotation, InterpolateUtils.EaseInOutQuart(elapsedTime));
            yield return null;
        }

        _previousInterviewCameraTransform = interviewCameraTransform;
        action?.Invoke();
    }

    public List<InterviewCameraTransform> GetUnitCameraTransformList()
    {
        List<InterviewCameraTransform> interviewCameraTransformsList = new List<InterviewCameraTransform>
        {
            _interviewUnitACamera,
            _interviewUnitBCamera,
            _interviewUnitCCamera
        };

        return interviewCameraTransformsList;
    }
}
