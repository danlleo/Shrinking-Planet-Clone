using System;
using UnityEngine;

public abstract class BaseAction : MonoBehaviour
{
    public static event EventHandler OnAnyActionStarted;
    public static event EventHandler OnAnyActionCompleted;

    protected Unit _unit;

    protected bool _isActive;

    protected virtual void Awake()
    {
        _unit = GetComponent<Unit>();
    }

    protected void ActionStart()
    {
        _isActive = true;

        OnAnyActionStarted?.Invoke(this, EventArgs.Empty);
    }

    protected void ActionComplete()
    {
        _isActive = false;

        OnAnyActionCompleted?.Invoke(this, EventArgs.Empty);
    }
}
