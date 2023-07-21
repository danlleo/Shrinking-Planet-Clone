using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaterDrinkerUI : MonoBehaviour
{
    [SerializeField] private WaterDrinker _waterDrinker;
    [SerializeField] private GameObject _progressBarUI;
    [SerializeField] private Image _waterStateIcon;
    [SerializeField] private Sprite _readyToFillSprite;
    [SerializeField] private Sprite _readyToDrinkSprite;
    [SerializeField] private Image _progressBarBackground;

    private bool _isFilling;

    private float _fillingTimeInSeconds = 3.5f;

    private void Start()
    {
        HideProgressBar();
        ShowWaterStateIcon();

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
            HideWaterStateIcon();
            StartCoroutine(FillWaterDrinkerProgressBarRoutine());
        }
    }

    private void ShowProgressBar() => _progressBarUI.SetActive(true);

    private void HideProgressBar() => _progressBarUI.SetActive(false);

    private void ShowWaterStateIcon() => _waterStateIcon.gameObject.SetActive(true);

    private void HideWaterStateIcon() => _waterStateIcon.gameObject.SetActive(false);

    private void SetWaterIconStateSprite(Sprite sprite) => _waterStateIcon.sprite = sprite;

    private IEnumerator FillWaterDrinkerProgressBarRoutine()
    {
        float timer = 0f;
        while (timer <  _fillingTimeInSeconds)
        {
            timer += Time.deltaTime;
            float normalizedTime = timer / _fillingTimeInSeconds;
            _progressBarBackground.fillAmount = normalizedTime;
            yield return null;
        }

        HideProgressBar();
        ShowWaterStateIcon();
        SetWaterIconStateSprite(_readyToDrinkSprite);
    }
}
