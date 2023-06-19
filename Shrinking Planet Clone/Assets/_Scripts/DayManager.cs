using System;

public class DayManager : Singleton<DayManager>
{
    public event EventHandler<Action> OnNewDayStart;

    private int _currentDay = 0;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        OnNewDayStart?.Invoke(this, EndDay);
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
            // Corresponding logic below
        }
    }

    private bool IsManagerEventDay() => _currentDay % 3 == 0;
}
