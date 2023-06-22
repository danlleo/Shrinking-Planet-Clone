using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static event EventHandler OnUnitSelectingJob;

    public event EventHandler OnUnitReachedDesk;
    public event EventHandler OnUnitSpawned;
    public event EventHandler OnUnitMoved;
    public event EventHandler OnUnitBeganWork;
    public event EventHandler OnUnitPerformedWorkPiece;

    [SerializeField] private UnitSO _unitSO;

    private void Start()
    {
        OnUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    public void InvokeUnitSelectingJobEvent() => OnUnitSelectingJob?.Invoke(this, EventArgs.Empty);
    
    public void InvokeUnitReachedDeskEvent() => OnUnitReachedDesk?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitMovedEvent() => OnUnitMoved?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitBeganWorkEvent() => OnUnitBeganWork?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitPerformedWorkPiece() => OnUnitPerformedWorkPiece?.Invoke(this, EventArgs.Empty);

    public string GetUnitGreetingsText() => _unitSO.Greetings;

    public Vector3 GetUnitDeskPosition() => _unitSO.UnitTargetDeskPosition;
}
