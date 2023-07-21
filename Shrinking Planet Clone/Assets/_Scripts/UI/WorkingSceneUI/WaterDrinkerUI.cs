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
    [SerializeField] private UnitNeed _unitNeed;
    [SerializeField] private UnitNeedType _unitNeedType;

    private bool _isFilling;
    private bool _isFilled;

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
            // Start filling it...

            ShowProgressBar();
            HideWaterStateIcon();
            StartCoroutine(FillWaterDrinkerProgressBarRoutine());
        }

        if (_isFilled)
        {
            InteractSystem.Instance.SetHandsBusyBy(_unitNeedType);
            UnitNeedManager.Instance.SetCurrentNeed(_unitNeed);

            _isFilled = false;
            _isFilling = false;

            SetWaterIconStateSprite(_readyToFillSprite);
        }
    }

    private void ShowProgressBar() => _progressBarUI.SetActive(true);

    private void HideProgressBar() => _progressBarUI.SetActive(false);

    private void ShowWaterStateIcon() => _waterStateIcon.gameObject.SetActive(true);

    private void HideWaterStateIcon() => _waterStateIcon.gameObject.SetActive(false);

    private void SetWaterIconStateSprite(Sprite sprite) => _waterStateIcon.sprite = sprite;

    private IEnumerator FillWaterDrinkerProgressBarRoutine()
    {
        _isFilling = true;

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

        _isFilled = true;
    }
}
