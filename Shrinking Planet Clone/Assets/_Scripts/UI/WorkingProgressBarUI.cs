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

    private void Start()
    {
        _unit.OnUnitPerformedWorkPiece += Unit_OnUnitPerformedWorkPiece;
        _unitEconomy.OnUnitReceivedMoney += UnitEconomy_OnUnitRecievedMoney;
        Hide();
    }

    private void UnitEconomy_OnUnitRecievedMoney(object sender, System.EventArgs e)
    {
        Show();
        InvokeTimer();
    }

    private void Unit_OnUnitPerformedWorkPiece(object sender, System.EventArgs e)
    {
        Show();
        InvokeTimer();
    }

    public void InvokeTimer() => StartCoroutine(StartTimerCountDownInSeconds());

    private IEnumerator StartTimerCountDownInSeconds()
    {
        float timer = 0f;

        while (timer <= _maxTimeInSeconds)
        {
            timer += Time.deltaTime;
            _normalizedTime = timer / _maxTimeInSeconds;
            _progressBarForeground.fillAmount = _normalizedTime;
            yield return null;
        }

        _unitEconomy.InvokeOnUnitReadyToReceiveMoney();
        Hide();
    }

    private void Show() => _workingProgressBarUI.SetActive(true);

    private void Hide() => _workingProgressBarUI.SetActive(false);
}
