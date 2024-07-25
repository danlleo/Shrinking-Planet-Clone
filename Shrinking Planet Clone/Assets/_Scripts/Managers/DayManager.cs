using System;
using Managers;

public class DayManager : Singleton<DayManager>
{
    public event EventHandler<EventArgs> OnDayEnded;

    private int _currentDay = 1;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _currentDay = SaveGameManager.Instance.GetDayCount();
    }

    public void InvokeOnDayEndedEvent() => OnDayEnded?.Invoke(this, EventArgs.Empty);

    public int GetCurrentDay() => _currentDay;

    public void ProceedToAnotherDay()
    {
        _currentDay++;

        int companyRankPosition = SaveGameManager.Instance.GetCompanyRankPosition();

        SaveGameManager.Instance.SaveGame(companyRankPosition, _currentDay, EconomyManager.Instance.GetTotalCurrentMoneyAmount());
    }
}
