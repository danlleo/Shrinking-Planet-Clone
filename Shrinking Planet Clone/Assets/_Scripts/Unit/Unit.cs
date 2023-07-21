using System;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, ISelectable
{
    private const int DEFAULT_LAYER = 0;
    private const int OUTLINE_LAYER = 31;

    public static event EventHandler OnUnitSelectingJob;

    public event EventHandler OnUnitReachedDesk;
    public event EventHandler OnUnitSpawned;
    public event EventHandler OnUnitMoved;
    public event EventHandler OnUnitBeganWork;
    public event EventHandler OnUnitPerformedWorkPiece;
    public event EventHandler<UnitNeedRequestedArgs> OnUnitNeedRequested;

    public class UnitNeedRequestedArgs : EventArgs
    {
        public UnitNeed RequestedNeed;

        public UnitNeedRequestedArgs (UnitNeed requestedNeed)
        {
            RequestedNeed = requestedNeed;
        }
    }

    public event EventHandler OnUnitNeedFulfilled;

    [SerializeField] private GameObject _unitVisual;
    [SerializeField] private NavMeshAgent _navmeshAgent;

    private UnitSO _unitSO;

    private void Start()
    {
        UnitManager.Instance.AddUnit(this);
        OnUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    public void Initialize(UnitSO unitSO)
    {
        _unitSO = unitSO;
        transform.position = _unitSO.UnitSpawnPosition;
        transform.rotation = Quaternion.Euler(_unitSO.UnitSpawnRotation);
    }

    public void InvokeUnitSelectingJobEvent() => OnUnitSelectingJob?.Invoke(this, EventArgs.Empty);
    
    public void InvokeUnitReachedDeskEvent() => OnUnitReachedDesk?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitMovedEvent() => OnUnitMoved?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitBeganWorkEvent() => OnUnitBeganWork?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitPerformedWorkPiece() => OnUnitPerformedWorkPiece?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitNeedRequest(UnitNeed unitNeed) => OnUnitNeedRequested?.Invoke(this, new UnitNeedRequestedArgs(unitNeed));

    public void InvokeUnitNeedFulfilled() => OnUnitNeedFulfilled?.Invoke(this, EventArgs.Empty);

    public string GetUnitSOName() => _unitSO.name;

    public string GetUnitGreetingsText() => _unitSO.Greetings;

    public string GetUnitName() => _unitSO.UnitName;

    public Sprite GetUnitImage() => _unitSO.UnitDisplayImage;

    public Sprite GetUnitOccupationImage() => _unitSO.UnitOccupationImage;

    public Vector3 GetUnitSpawnPosition() => _unitSO.UnitSpawnPosition;

    public Vector3 GetUnitDeskPosition() => _unitSO.UnitTargetDeskPosition;

    public Vector3 GetUnitPlaceOnChairPosition() => _unitSO.UnitPlaceOnChairPosition;

    public Quaternion GetUnitReachedDeskRotaion() => Quaternion.Euler(_unitSO.UnitTargetReachedDeskRotation);

    public NavMeshAgent GetUnitNavmeshAgent() => _navmeshAgent;

    public void OnMouseEnter()
    {
        SoundManager.Instance.PlayUnitMouseHover();
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
}
