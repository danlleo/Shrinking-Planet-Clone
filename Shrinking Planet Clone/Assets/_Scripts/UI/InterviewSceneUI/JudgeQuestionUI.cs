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
        Judge.OnJudgeAsking += Judge_OnJudgeAsking;

        HideUI();
    }

    private void OnDestroy()
    {
        Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
    }

    private void Judge_OnJudgeAsking(object sender, EventArgs e)
    {
        ShowUI();
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        Question question = JudgeQuestionsManager.Instance.GetCurrentQuestion();

        _judgeQuestionImage.sprite = question.QuestionIcon;

        StartCoroutine(DisplayQuestionTimer());
    }

    private IEnumerator DisplayQuestionTimer()
    {
        yield return new WaitForSeconds(DISPLAY_QUESTION_TIME_IN_SECONDS);

        HideUI();
    }

    private void ShowUI() => _judgeQuestionUI.SetActive(true);

    private void HideUI() => _judgeQuestionUI.SetActive(false);
}
