using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    [SerializeField] private Image _timerForeground;

    private float _maxTimeInSeconds = 100f;
    private float _normalizedTime = 0f;

    private void Start()
    {
        ShowTimer();
        InvokeTimer();

        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void OnDestroy()
    {
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        HideTimer();
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

    private void ShowTimer() => gameObject.SetActive(true);

    private void HideTimer() => gameObject.SetActive(false);
}
