using System;

public class DayManager : Singleton<DayManager>
{
    public event EventHandler<EventArgs> OnDayChanged;
    public event EventHandler<EventArgs> OnDayEnded;

    private int _currentDay = 1;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        InvokeOnDayChangedEvent();
    }

    protected void InvokeOnDayChangedEvent() => OnDayChanged?.Invoke(this, EventArgs.Empty);

    protected void InvokeOnDayEndedEvent() => OnDayEnded?.Invoke(this, EventArgs.Empty);

    public int GetCurrentDay() => _currentDay;
}
