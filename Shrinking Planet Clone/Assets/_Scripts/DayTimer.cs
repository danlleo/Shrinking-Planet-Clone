using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private Image _timerForeground;

    private float _maxTimeInSeconds = 60f;
    private float _normalizedTime = 0f;

    private void Start()
    {
        DayManager.Instance.OnDayChanged += DayManager_OnDayChanged;
        InvokeTimer();
    }

    private void DayManager_OnDayChanged(object sender, System.EventArgs e)
    {
        //InvokeTimer();
    }

    protected void InvokeTimer() => StartCoroutine(TimerCountDownInSecondsRoutine());

    private IEnumerator TimerCountDownInSecondsRoutine()
    {
        float timer = _maxTimeInSeconds;

        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            _normalizedTime = timer / _maxTimeInSeconds;
            _timerForeground.fillAmount = _normalizedTime;
            yield return null;
        }

        DayManager.Instance.InvokeOnDayEndedEvent();
    }
}
