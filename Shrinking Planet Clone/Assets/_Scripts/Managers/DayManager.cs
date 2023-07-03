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
        _currentDay = SaveSystem.Instance.LoadCurrentDay();
        InvokeOnDayChangedEvent();
    }

    public void InvokeOnDayChangedEvent() => OnDayChanged?.Invoke(this, EventArgs.Empty);

    public void InvokeOnDayEndedEvent() => OnDayEnded?.Invoke(this, EventArgs.Empty);

    public int GetCurrentDay() => _currentDay;

    public void ProceedToAnotherDay()
    {
        _currentDay++;
        SaveSystem.Instance.SaveCurrentDay(_currentDay);
    }
}
