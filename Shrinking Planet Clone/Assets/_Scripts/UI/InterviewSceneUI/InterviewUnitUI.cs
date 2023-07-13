using UnityEngine;
using UnityEngine.UI;

public class InterviewUnitUI : MonoBehaviour
{
    [SerializeField] private GameObject _interviewUnitUI;
    [SerializeField] private Image _interviewUnitOccupationImage;
    [SerializeField] private InterviewUnit _interviewUnit;

    private void Start()
    {
        Judge.OnJudgeAsking += Judge_OnJudgeAsking;

        Hide();
    }

    private void OnDestroy()
    {
        Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
    }

    private void Judge_OnJudgeAsking(object sender, System.EventArgs e)
    {
        Show();
        SetInterviewUnitOccupationImage();
    }

    private void Show() => _interviewUnitUI.SetActive(true);

    private void Hide() => _interviewUnitUI.SetActive(false);

    private void SetInterviewUnitOccupationImage()
    {
        Sprite occupationImage = _interviewUnit.GetInterviewUnitSprite();

        _interviewUnitOccupationImage.sprite = occupationImage;
    }
}
