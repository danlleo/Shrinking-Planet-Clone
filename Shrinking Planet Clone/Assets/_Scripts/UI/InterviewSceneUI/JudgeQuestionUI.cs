using System;
using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InterviewSceneUI
{
    public class JudgeQuestionUI : MonoBehaviour
    {
        [SerializeField] private Judge.Judge _judge;
        [SerializeField] private GameObject _judgeQuestionUI;
        [SerializeField] private Image _judgeQuestionImage;

        private const float DisplayQuestionTimeInSeconds = 1f;

        private void Start()
        {
            Judge.Judge.OnJudgeAsking += Judge_OnJudgeAsking;

            HideUI();
        }

        private void OnDestroy()
        {
            Judge.Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
        }

        private void Judge_OnJudgeAsking(object sender, EventArgs e)
        {
            ShowUI();
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            InterviewQuestion question = JudgeQuestionsManager.Instance.GetCurrentQuestion();

            _judgeQuestionImage.sprite = question.QuestionIcon;

            StartCoroutine(DisplayQuestionTimer());
        }

        private IEnumerator DisplayQuestionTimer()
        {
            yield return new WaitForSeconds(DisplayQuestionTimeInSeconds);

            HideUI();
        }

        private void ShowUI() => _judgeQuestionUI.SetActive(true);

        private void HideUI() => _judgeQuestionUI.SetActive(false);
    }
}
