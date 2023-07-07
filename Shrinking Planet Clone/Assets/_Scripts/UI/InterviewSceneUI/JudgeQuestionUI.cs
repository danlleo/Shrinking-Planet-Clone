using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class JudgeQuestionUI : MonoBehaviour
{
    [SerializeField] private Judge _judge;
    [SerializeField] private GameObject _judgeQuestionUI;
    [SerializeField] private Image _judgeQuestionImage;

    private const float DISPLAY_QUESTION_TIME_IN_SECONDS = 1f;

    private void Start()
    {
        _judge.OnJudgeAsking += Judge_OnJudgeAsking;

        Hide();
    }

    private void Judge_OnJudgeAsking(object sender, EventArgs e)
    {
        Show();
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        Question question = JudgeQuestionsManager.Instance.GetCurrenQuestion();

        _judgeQuestionImage.sprite = question.QuestionIcon;

        StartCoroutine(DisplayQuestionTimer());
    }

    private IEnumerator DisplayQuestionTimer()
    {
        yield return new WaitForSeconds(DISPLAY_QUESTION_TIME_IN_SECONDS);

        Hide();
    }

    private void Show() => _judgeQuestionUI.SetActive(true);

    private void Hide() => _judgeQuestionUI.SetActive(false);
}
