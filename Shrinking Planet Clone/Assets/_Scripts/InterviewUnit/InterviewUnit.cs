using System;
using Unit;
using UnityEngine;

namespace InterviewUnit
{
    public class InterviewUnit : MonoBehaviour, ISelectable
    {
        public static event EventHandler<InterviewUnitAnsweredEventArgs> OnInterviewUnitAnswered;

        public class InterviewUnitAnsweredEventArgs : EventArgs
        {
            public InterviewCameraTransform UnitInterviewCameraTransform;
            public Judge.Judge JudgeComponent;
            public readonly bool IsAnswerCorrect;

            public InterviewUnitAnsweredEventArgs(InterviewCameraTransform unitInterviewCameraTransform,
                Judge.Judge judgeComponent, bool isAnswerCorrect)
            {
                UnitInterviewCameraTransform = unitInterviewCameraTransform;
                JudgeComponent = judgeComponent;
                IsAnswerCorrect = isAnswerCorrect;
            }
        }

        private const int DefaultLayer = 0;
        private const int OutlineLayer = 31;

        [SerializeField] private GameObject _unitVisual;

        private UnitSO _unitSO;
        private InterviewCameraTransform _interviewCameraTransform;

        public void Setup(Vector3 spawnPosition, UnitSO unitSO, InterviewCameraTransform interviewCameraTransform)
        {
            transform.position = spawnPosition;
            _unitSO = unitSO;
            _interviewCameraTransform = interviewCameraTransform;
        }

        public Sprite GetInterviewUnitSprite() => _unitSO.UnitOccupationImage;

        public UnitOccupationType GetInterviewUnitOccupationType() => _unitSO.DefaultOccupation;

        public void OnMouseEnter()
        {
            ChangeLayerInObject(_unitVisual, OutlineLayer);
        }

        public void OnMouseExit()
        {
            ChangeLayerInObject(_unitVisual, DefaultLayer);
        }

        public void ChangeLayerInObject(GameObject targetObject, int newLayer)
        {
            targetObject.layer = newLayer;
        }

        public void InvokeInterviewUnitAnsweredEvent(Judge.Judge judge, bool isAnswerCorrect) => OnInterviewUnitAnswered?.Invoke(this, 
            new InterviewUnitAnsweredEventArgs(
                _interviewCameraTransform, judge, isAnswerCorrect
            )
        );
    }
}
