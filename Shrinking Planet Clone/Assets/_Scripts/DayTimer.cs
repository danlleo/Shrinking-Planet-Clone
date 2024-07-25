using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private Image _timerForeground;

    private readonly float _maxTimeInSeconds = 60f;
    private float _normalizedTime;
    private float _timer;

    private Coroutine _timerCoroutine;

    private bool _isRunningTimerCoroutine;

    private void Awake()
    {
        _timer = _maxTimeInSeconds;
    }

    private void Start()
    {
        InvokeTimer();
    }

    private void OnEnable()
    {
        if (_isRunningTimerCoroutine)
        {
            _timerCoroutine = StartCoroutine(TimerCountDownInSecondsRoutine());
        }
    }

    private void OnDisable()
    {
        if (_timerCoroutine == null) return;
        
        StopCoroutine(_timerCoroutine);
        _isRunningTimerCoroutine = true;
    }

    private void InvokeTimer()
    {
        _timerCoroutine = StartCoroutine(TimerCountDownInSecondsRoutine());
    }

    private IEnumerator TimerCountDownInSecondsRoutine()
    {
        while (_timer >= 0)
        {
            _timer -= Time.deltaTime;
            _normalizedTime = _timer / _maxTimeInSeconds;
            _timerForeground.fillAmount = _normalizedTime;
            yield return null;
        }

        DayManager.Instance.InvokeOnDayEndedEvent();
    }
}
