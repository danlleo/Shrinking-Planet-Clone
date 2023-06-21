using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public static event EventHandler OnUnitSelectingJob;

    public event EventHandler OnUnitReachedDesk;
    public event EventHandler OnUnitSpawned;
    public event EventHandler OnUnitMoved;
    public event EventHandler OnUnitBeganWork;

    [SerializeField] private UnitSO _unitSO;

    private void Start()
    {
        OnUnitSpawned?.Invoke(this, EventArgs.Empty);
    }

    public void InvokeUnitSelectingJob() => OnUnitSelectingJob?.Invoke(this, EventArgs.Empty);
    
    public void InvokeUnitReachedDeskEvent() => OnUnitReachedDesk?.Invoke(this, EventArgs.Empty);

    public string GetUnitGreetingsText() => _unitSO.Greetings;

    public Vector3 GetUnitDeskPosition() => _unitSO.UnitTargetDeskPosition;
}
