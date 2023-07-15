using System;
using UnityEngine;

public class Judge : MonoBehaviour
{
    public static event EventHandler OnJudgeReviewingAnswer;
    public static event EventHandler OnJudgeCameraFocus;
    public static event EventHandler<ReceivedAnswerArgs> OnJudgeReviewedAnswer;

    public class ReceivedAnswerArgs : EventArgs
    {
        public bool IsAnswerCorrect;

        public ReceivedAnswerArgs(bool isAnswerCorrect)
        {
            IsAnswerCorrect = isAnswerCorrect;
        }
    }

    public static event EventHandler OnJudgeThinking;
    public static event EventHandler OnJudgeAsking;
    public static event EventHandler OnJudgeFinishedJob;

    private JudgeData _judgeData;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _judgeData = new JudgeData(new Vector3(0f, 0f, -2.5f), Quaternion.Euler(0f, 180f, 0f));
        transform.SetPositionAndRotation(_judgeData.SpawnPosition, _judgeData.SpawnRotation);
    }

    public void InvokeJudgeThinkingEvent() => OnJudgeThinking?.Invoke(this, EventArgs.Empty);

    public void InvokeJudgeAskingEvent() => OnJudgeAsking?.Invoke(this, EventArgs.Empty);

    public void InvokeJudgeReviewingEvent() => OnJudgeReviewingAnswer?.Invoke(this, EventArgs.Empty);

    public void InvokeJudgeCameraFocus() => OnJudgeCameraFocus?.Invoke(this, EventArgs.Empty);

    public void InvokeJudgeReviewedAnswerEvent(bool isAnswerCorrect) => OnJudgeReviewedAnswer?.Invoke(this, new ReceivedAnswerArgs(isAnswerCorrect));

    public void InvokeJudgeFinishedJobEvent() => OnJudgeFinishedJob?.Invoke(this, EventArgs.Empty);
}
