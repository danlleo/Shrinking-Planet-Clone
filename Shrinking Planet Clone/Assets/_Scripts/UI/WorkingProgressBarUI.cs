using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WorkingProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject _workingProgressBarUI;
    [SerializeField] private Unit _unit;
    [SerializeField] private Image _progressBarForeground;

    private float _maxTimeInSeconds = 15f;
    private float _normalizedTime = 0f;

    private void Start()
    {
        _unit.OnUnitPerformedWorkPiece += Unit_OnUnitPerformedWorkPiece;
        Hide();
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
    }

    private void Show() => _workingProgressBarUI.SetActive(true);

    private void Hide() => _workingProgressBarUI.SetActive(false);
}
