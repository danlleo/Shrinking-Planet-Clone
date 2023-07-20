using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaterDrinkerUI : MonoBehaviour
{
    [SerializeField] private WaterDrinker _waterDrinker;
    [SerializeField] private GameObject _progressBarUI;
    [SerializeField] private Image _progressBarBackground;

    private bool _isFilling;

    private float _fillingTimeInSeconds = 3.5f;

    private void Start()
    {
        HideProgressBar();

        _waterDrinker.OnWaterDrinkerInteract += WaterDrinker_OnWaterDrinkerInteract;
    }

    private void OnDestroy()
    {
        _waterDrinker.OnWaterDrinkerInteract -= WaterDrinker_OnWaterDrinkerInteract;
    }

    private void WaterDrinker_OnWaterDrinkerInteract(object sender, System.EventArgs e)
    {
        if (!_isFilling)
        {
            ShowProgressBar();
            StartCoroutine(FillWaterDrinkerProgressBarRoutine());
        }
    }

    private void ShowProgressBar() => _progressBarUI.SetActive(true);

    private void HideProgressBar() => _progressBarUI.SetActive(false);

    private IEnumerator FillWaterDrinkerProgressBarRoutine()
    {
        float timer = 0f;
        float normalizedTime = 0f;

        while (timer <  _fillingTimeInSeconds)
        {
            timer += Time.deltaTime;
            normalizedTime = timer / _fillingTimeInSeconds;
            _progressBarBackground.fillAmount = normalizedTime;
            yield return null;
        }

        HideProgressBar();
    }
}
