using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplaySingleUI : MonoBehaviour
{
    [SerializeField] private Image _unitDisplayImage;
    [SerializeField] private Image _progressBarForeground;
    [SerializeField] private TextMeshProUGUI _unitDisplayNameText;
    [SerializeField] private TextMeshProUGUI _unitDisplayLevelText;

    private UnitLevel _unitLevel;

    private float _maxTimeInSeconds = 1f;
    private float _normalizedTime = 0f;

    public void Setup(Sprite unitDisplayImage, string unitDisplayNameText, string unitDisplayLevelText, UnitLevel unitLevel)
    {
        _unitDisplayImage.sprite = unitDisplayImage;

        _unitDisplayNameText.text = unitDisplayNameText;
        _unitDisplayLevelText.text = "Lvl. " + unitDisplayLevelText;
        _unitLevel = unitLevel;

        StartCoroutine(StartLevelProgressMoveBarInSeconds());
    }

    private IEnumerator StartLevelProgressMoveBarInSeconds()
    {
        int previousXP = _unitLevel.GetPreviousXPValue();
        int currentXP = _unitLevel.GetUnitCurrentXPValue();
        int xpToNextLevel = UnitLevelUpSystem.Instance.GetXPToNextLevel();

        int XPsum = previousXP + currentXP;

        float timer = 0f;

        while (timer <= _maxTimeInSeconds)
        {
            timer += Time.deltaTime;
            _normalizedTime = timer / _maxTimeInSeconds;
            _progressBarForeground.fillAmount = Mathf.Lerp((float)previousXP / XPsum, (float)currentXP / XPsum, _normalizedTime);
            
            yield return null;
        }

        print("Does it stop");

        if (currentXP > xpToNextLevel)
            yield return StartCoroutine(StartLevelProgressMoveBarInSeconds());
    }
}
