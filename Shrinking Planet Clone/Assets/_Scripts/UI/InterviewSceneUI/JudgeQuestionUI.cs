using UnityEngine;
using UnityEngine.UI;

public class JudgeQuestionUI : MonoBehaviour
{
    [SerializeField] private Judge _judge;
    [SerializeField] private GameObject _judgeQuestionUI;
    [SerializeField] private Image _judgeQuestionImage;

    private void Start()
    {
        _judge.OnJudgeAsking += Judge_OnJudgeAsking;

        Hide();
    }

    private void Judge_OnJudgeAsking(object sender, System.EventArgs e)
    {
        Show();
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {
        Question question = JudgeQuestionsManager.Instance.GetCurrenQuestion();

        _judgeQuestionImage.sprite = question.QuestionIcon;
    }

    private void Show() => _judgeQuestionUI.SetActive(true);

    private void Hide() => _judgeQuestionUI.SetActive(false);
}
