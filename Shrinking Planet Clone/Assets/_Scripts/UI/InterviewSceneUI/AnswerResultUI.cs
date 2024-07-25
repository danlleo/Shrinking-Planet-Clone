using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InterviewSceneUI
{
    public class AnswerResultUI : MonoBehaviour
    {
        [SerializeField] private GameObject _answerResultUI;
        [SerializeField] private Image _answerResultImage;
        [SerializeField] private Sprite _correctAnswerSprite;
        [SerializeField] private Sprite _wrongAnswerSprite;

        private void Start()
        {
            HideUI();

            Judge.Judge.OnJudgeReviewedAnswer += Judge_OnJudgeReviewedAnswer;
        }

        private void OnDestroy()
        {
            Judge.Judge.OnJudgeReviewedAnswer -= Judge_OnJudgeReviewedAnswer;
        }

        private void Judge_OnJudgeReviewedAnswer(object sender, Judge.Judge.ReceivedAnswerArgs e)
        {
            StartCoroutine(DisplayResultImageRoutineInSeconds(1f));

            if (e.IsAnswerCorrect)
            {
                _answerResultImage.sprite = _correctAnswerSprite;
                return;
            }

            _answerResultImage.sprite = _wrongAnswerSprite;
        }

        private void ShowUI() => _answerResultUI.SetActive(true);

        private void HideUI() => _answerResultUI.SetActive(false);

        private IEnumerator DisplayResultImageRoutineInSeconds(float displayTime)
        {
            ShowUI();
            yield return new WaitForSeconds(displayTime);
            HideUI();
        }
    }
}
