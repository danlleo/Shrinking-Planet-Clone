using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image _timerForeground;

    private float _maxTimeInSeconds = 10f;
    private float _normalizedTime = 0f;

    public void InvokeTimer(Action onDayEnd) => StartCoroutine(StartTimerCountDownInSeconds(onDayEnd));

    private void Start()
    {
        ResetTimer();
        DayManager.Instance.OnNewDayStart += DayManager_OnNewDayStart;
    }

    private void DayManager_OnNewDayStart(object sender, Action e)
    {
        InvokeTimer(e);
    }

    private IEnumerator StartTimerCountDownInSeconds(Action onDayEnd)
    {
        float timer = _maxTimeInSeconds;

        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            _normalizedTime = timer / _maxTimeInSeconds;
            _timerForeground.fillAmount = _normalizedTime;
            yield return null;
        }

        onDayEnd?.Invoke();
    }

    private void ResetTimer() => _timerForeground.fillAmount = 1f;
}
