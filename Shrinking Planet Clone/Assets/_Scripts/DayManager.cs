using System;

public class DayManager : Singleton<DayManager>
{
    public event EventHandler<Action> OnNewDayStart;
    public event EventHandler OnDayChanged;

    private int _currentDay = 0;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        OnNewDayStart?.Invoke(this, EndDay);
        OnDayChanged?.Invoke(this, EventArgs.Empty);
    }

    public void EndDay()
    {
        _currentDay++;

        if (IsManagerEventDay())
        {
            // Corresponding logic below
        }
        else
        {
            OnNewDayStart?.Invoke(this, EndDay);
            OnDayChanged?.Invoke(this, EventArgs.Empty);
            // Corresponding logic below
        }
    }

    public int GetCurrentDay() => _currentDay;

    private bool IsManagerEventDay() => _currentDay % 3 == 0;
}
