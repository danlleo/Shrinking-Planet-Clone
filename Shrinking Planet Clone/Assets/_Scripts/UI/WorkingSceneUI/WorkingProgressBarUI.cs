using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WorkingProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject _workingProgressBarUI;
    [SerializeField] private Unit _unit;
    [SerializeField] private UnitEconomy _unitEconomy;
    [SerializeField] private Image _progressBarForeground;

    private float _maxTimeInSeconds = 5f;
    private float _normalizedTime = 0f;

    private Coroutine _countDownCoroutine;

    private void Start()
    {
        _unit.OnUnitPerformedWorkPiece += Unit_OnUnitPerformedWorkPiece;
        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitRecievedMoney;
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        Hide();
    }

    private void OnDestroy()
    {
        _unit.OnUnitPerformedWorkPiece -= Unit_OnUnitPerformedWorkPiece;
        _unitEconomy.OnUnitReceivedMoney -= UnitEconomy_OnUnitRecievedMoney;
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, EventArgs e)
    {
        if (_countDownCoroutine != null)
        {
            StopCoroutine(_countDownCoroutine);
            _countDownCoroutine = null;
        }

        Hide();
    }

    private void UnitEconomy_OnUnitRecievedMoney(object sender, EventArgs e)
    {
        Show();
        InvokeTimer();
    }

    private void Unit_OnUnitPerformedWorkPiece(object sender, EventArgs e)
    {
        Show();
        InvokeTimer();
    }

    public void InvokeTimer() => _countDownCoroutine = StartCoroutine(TimerCountDownInSecondsRoutine());

    private IEnumerator TimerCountDownInSecondsRoutine()
    {
        float timer = 0f;

        while (timer <= _maxTimeInSeconds)
        {
            timer += Time.deltaTime;
            _normalizedTime = timer / _maxTimeInSeconds;
            _progressBarForeground.fillAmount = _normalizedTime;
            yield return null;
        }

        // Calculate if unit successfully finished work, for now 50% chance
        bool HasUnitSuccessfullyFinishedWork = UnityEngine.Random.Range(0, 2) == 0;

        _unitEconomy.InvokeOnUnitReadyToReceiveMoney(HasUnitSuccessfullyFinishedWork);
        Hide();
    }

    private void Show() => _workingProgressBarUI.SetActive(true);

    private void Hide() => _workingProgressBarUI.SetActive(false);
}
