using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InterviewSceneUI
{
    public class InterviewUnitUI : MonoBehaviour
    {
        [SerializeField] private GameObject _interviewUnitUI;
        [SerializeField] private Image _interviewUnitOccupationImage;
        [SerializeField] private InterviewUnit.InterviewUnit _interviewUnit;

        private Judge.Judge _judge;

        private void Start()
        {
            Judge.Judge.OnJudgeAsking += Judge_OnJudgeAsking;
            InterviewUnit.InterviewUnit.OnInterviewUnitAnswered += InterviewUnit_OnInterviewUnitAnswered;

            HideUI();
        }

        private void OnDestroy()
        {
            Judge.Judge.OnJudgeAsking -= Judge_OnJudgeAsking;
            InterviewUnit.InterviewUnit.OnInterviewUnitAnswered -= InterviewUnit_OnInterviewUnitAnswered;
        }

        private void InterviewUnit_OnInterviewUnitAnswered(object sender, System.EventArgs e)
        {
            InterviewUnit.InterviewUnit senderInterviewUnit = (InterviewUnit.InterviewUnit)sender;

            if (!ReferenceEquals(senderInterviewUnit, _interviewUnit))
            {
                HideUI();
                return;
            }

            StartCoroutine(FlickeringUIRoutine());
        }

        private void Judge_OnJudgeAsking(object sender, System.EventArgs e)
        {
            Judge.Judge judge = (Judge.Judge)sender;

            _judge = judge;

            ShowUI();
            SetInterviewUnitOccupationImage();
        }

        private void ShowUI() => _interviewUnitUI.SetActive(true);

        private void HideUI() => _interviewUnitUI.SetActive(false);

        private IEnumerator FlickeringUIRoutine()
        {
            const float flickingTimeInSeconds = .2f;
            const int maxFlickingCount = 4;
            
            int currentFlickingCount = 0;

            while (currentFlickingCount < maxFlickingCount)
            {
                yield return new WaitForSeconds(flickingTimeInSeconds);
                ShowUI();
                yield return new WaitForSeconds(flickingTimeInSeconds);
                HideUI();
                currentFlickingCount++;
                SoundManager.Instance.PlayInterviewUnitTalking();
            }

            _judge.InvokeJudgeCameraFocus();
        }

        private void SetInterviewUnitOccupationImage()
        {
            Sprite occupationImage = _interviewUnit.GetInterviewUnitSprite();

            _interviewUnitOccupationImage.sprite = occupationImage;
        }
    }
}
