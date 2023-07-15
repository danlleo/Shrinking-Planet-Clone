using UnityEngine;
using UnityEngine.EventSystems;

public class InterviewUnitActionSystem : Singleton<InterviewUnitActionSystem>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public bool TryGetSelectedInterviewUnit(out InterviewUnit selectedInterviewUnit)
    {
        Vector3 cameraPosition = Camera.main.transform.position;

        if (!Physics.Raycast(cameraPosition, MouseWorld.GetPosition() - cameraPosition, out RaycastHit hitInfo, float.MaxValue))
        {
            selectedInterviewUnit = null;
            return false;
        }

        if (!hitInfo.collider.TryGetComponent(out InterviewUnit interviewUnit))
        {
            selectedInterviewUnit = null;
            return false;
        }

        // If mouse pointer is over UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            selectedInterviewUnit = null;
            return false;
        }

        selectedInterviewUnit = interviewUnit;
        return true;
    }
}
