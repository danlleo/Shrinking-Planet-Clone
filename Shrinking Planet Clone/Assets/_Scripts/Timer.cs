using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image _timerForeground;

    private float _maxTimeInSeconds = 180f;
    private float _normalizedTime = 0f;

    private void Start()
    {
        ResetTimer();
        DayManager.Instance.OnNewDayStart += DayManager_OnNewDayStart;
    }

    private void OnDestroy()
    {
        DayManager.Instance.OnNewDayStart -= DayManager_OnNewDayStart;
    }

    public void InvokeTimer(Action onDayEnded) => StartCoroutine(StartTimerCountDownInSeconds(onDayEnded));

    private void DayManager_OnNewDayStart(object sender, Action e)
    {
        InvokeTimer(e);
    }

    private IEnumerator StartTimerCountDownInSeconds(Action onDayEnded)
    {
        float timer = _maxTimeInSeconds;

        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            _normalizedTime = timer / _maxTimeInSeconds;
            _timerForeground.fillAmount = _normalizedTime;
            yield return null;
        }

        onDayEnded?.Invoke();
    }

    private void ResetTimer() => _timerForeground.fillAmount = 1f;
}
