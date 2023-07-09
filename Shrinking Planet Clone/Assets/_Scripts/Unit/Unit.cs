using System;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public static event EventHandler OnUnitSelectingJob;

    public event EventHandler OnUnitReachedDesk;
    public event EventHandler OnUnitSpawned;
    public event EventHandler OnUnitMoved;
    public event EventHandler OnUnitBeganWork;
    public event EventHandler OnUnitPerformedWorkPiece;

    private UnitSO _unitSO;

    private void Start()
    {
        UnitManager.Instance.AddUnit(this);
        OnUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    public void InvokeUnitSelectingJobEvent() => OnUnitSelectingJob?.Invoke(this, EventArgs.Empty);
    
    public void InvokeUnitReachedDeskEvent() => OnUnitReachedDesk?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitMovedEvent() => OnUnitMoved?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitBeganWorkEvent() => OnUnitBeganWork?.Invoke(this, EventArgs.Empty);

    public void InvokeUnitPerformedWorkPiece() => OnUnitPerformedWorkPiece?.Invoke(this, EventArgs.Empty);

    public string GetUnitSOName() => _unitSO.name;

    public string GetUnitGreetingsText() => _unitSO.Greetings;

    public string GetUnitName() => _unitSO.UnitName;

    public Sprite GetUnitImage() => _unitSO.UnitDisplayImage;

    public Vector3 GetUnitSpawnPosition() => _unitSO.UnitSpawnPosition;

    public Vector3 GetUnitDeskPosition() => _unitSO.UnitTargetDeskPosition;
}
