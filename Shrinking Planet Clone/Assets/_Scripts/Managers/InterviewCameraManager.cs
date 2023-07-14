using System;
using System.Collections;
using UnityEngine;

public class InterviewCameraManager : Singleton<InterviewCameraManager>
{
    private const float DEFAULT_CAMERA_MOVE_DELAY_TIME = 1f;

    [SerializeField] private InterviewCameraTransform _defaultCamera;
    [SerializeField] private InterviewCameraTransform _judgeLockCamera;
    [SerializeField] private InterviewCameraTransform _unitsLockCamera;

    private InterviewCameraTransform _previousInterviewCameraTransform;
    private Camera _camera;

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
        Judge.OnJudgeReceivedAnswer += Judge_OnJudgeReceivedAnswer;
        Judge.OnJudgeFinishedJob += Judge_OnJudgeFinishedJob;
    }

    private void OnDestroy()
    {
        JudgeIdleState.OnJudgeEnteredIdleState -= JudgeIdleState_OnJudgeEnteredIdleState;
        Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
        Judge.OnJudgeReceivedAnswer -= Judge_OnJudgeReceivedAnswer;
        Judge.OnJudgeFinishedJob -= Judge_OnJudgeFinishedJob;
    }

    private void Judge_OnJudgeFinishedJob(object sender, EventArgs e)
    {
        StartCoroutine(MoveCameraInSecondsRoutine(_defaultCamera, 1f));
    }

    private void Judge_OnJudgeReceivedAnswer(object sender, EventArgs e)
    {
        StartCoroutine(MoveCameraInSecondsRoutine(_judgeLockCamera, 1f));
    }

    private void Judge_OnJudgeAsking(object sender, EventArgs e)
    {
        StartCoroutine(MoveCameraInSecondsRoutine(_unitsLockCamera, 1f));
    }

    private void JudgeIdleState_OnJudgeEnteredIdleState(object sender, System.EventArgs e)
    {
        StartCoroutine(MoveCameraInSecondsRoutine(_judgeLockCamera, 1f));
    }

    private IEnumerator MoveCameraInSecondsRoutine(InterviewCameraTransform interviewCameraTransform, float maxTimeInSeconds, float delayTime = DEFAULT_CAMERA_MOVE_DELAY_TIME)
    {
        Vector3 startPosition = _previousInterviewCameraTransform.CameraPosition;
        Vector3 endPosition = interviewCameraTransform.CameraPosition;

        Quaternion startRotation = _previousInterviewCameraTransform.CameraRotation;
        Quaternion endRotation = interviewCameraTransform.CameraRotation;

        float elapsedTime = 0f;
        float normalizedTime = 0f;

        yield return new WaitForSeconds(delayTime);

        while (elapsedTime <= maxTimeInSeconds)
        {
            elapsedTime += Time.deltaTime;
            normalizedTime = elapsedTime / maxTimeInSeconds;
            _camera.transform.position = Vector3.Lerp(startPosition, endPosition, InterpolateUtils.EaseInOutQuart(normalizedTime));
            _camera.transform.rotation = Quaternion.Lerp(startRotation, endRotation, InterpolateUtils.EaseInOutQuart(elapsedTime));
            yield return null;
        }

        _previousInterviewCameraTransform = interviewCameraTransform;
    }
}
