using System;
using UnityEngine;

public class InterviewUnit : MonoBehaviour, ISelectable
{
    public static event EventHandler<InterviewUnitAnsweredEventArgs> OnInterviewUnitAnswered;

    public class InterviewUnitAnsweredEventArgs : EventArgs
    {
        public InterviewCameraTransform UnitInterviewCameraTransform;
        public Judge JudgeComponent;
        public bool IsAnswerCorrect;

        public InterviewUnitAnsweredEventArgs(InterviewCameraTransform unitInterviewCameraTransform, Judge judgeComponent, bool isAnswerCorrect)
        {
            UnitInterviewCameraTransform = unitInterviewCameraTransform;
            JudgeComponent = judgeComponent;
            IsAnswerCorrect = isAnswerCorrect;
        }
    }

    private const int DEFAULT_LAYER = 0;
    private const int OUTLINE_LAYER = 31;

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
        ChangeLayerInObject(_unitVisual, OUTLINE_LAYER);
    }

    public void OnMouseExit()
    {
        ChangeLayerInObject(_unitVisual, DEFAULT_LAYER);
    }

    public void ChangeLayerInObject(GameObject targetObject, int newLayer)
    {
        targetObject.layer = newLayer;
    }

    public void InvokeInterviewUnitAnsweredEvent(Judge judge, bool isAnswerCorrect) => OnInterviewUnitAnswered?.Invoke(this, 
        new InterviewUnitAnsweredEventArgs(
            _interviewCameraTransform, judge, isAnswerCorrect
        )
    );
}
