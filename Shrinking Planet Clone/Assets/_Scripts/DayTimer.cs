using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : DayManager
{
    [SerializeField] private Image _timerForeground;

    private float _maxTimeInSeconds = 100f;
    private float _normalizedTime = 0f;

    protected override void Awake()
    {
        // Logic here later
    }

    private void Start()
    {
        OnDayChanged += DayTimer_OnDayChanged;
    }

    private void DayTimer_OnDayChanged(object sender, System.EventArgs e)
    {
        InvokeTimer();
    }

    protected void InvokeTimer() => StartCoroutine(StartTimerCountDownInSeconds());

    private IEnumerator StartTimerCountDownInSeconds()
    {
        float timer = _maxTimeInSeconds;

        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            _normalizedTime = timer / _maxTimeInSeconds;
            _timerForeground.fillAmount = _normalizedTime;
            yield return null;
        }

        InvokeOnDayEndedEvent();
    }
}
