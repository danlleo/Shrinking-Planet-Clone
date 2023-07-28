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

    private float _maxTimeInSeconds = .5f;

    private bool _leveledUp;

    private string _unitSOName;

    private void OnDestroy()
    {
        _unitLevel.OnLevelUp -= UnitLevel_OnLevelUp;
    }

    public void Initialize(Sprite unitDisplayImage, string unitDisplayNameText, string unitDisplayLevelText, UnitLevel unitLevel, UnitEconomy unitEconomy, string unitSOName)
    {
        _unitLevel = unitLevel;

        if (_unitLevel.HasReachedMaxLevel(_unitLevel.GetCurrentLevel()))
        {
            _unitDisplayLevelText.text = $"Lvl. MAX";
            return;        
        }

        _unitSOName = unitSOName;
        _unitDisplayImage.sprite = unitDisplayImage;
        _unitDisplayNameText.text = unitDisplayNameText;
        _unitDisplayLevelText.text = $"Lvl. {unitDisplayLevelText}";

        _unitLevel.SetCurrentXP(unitEconomy.GetCurrentUnitMoneyAmount() / 5);
        
        StartCoroutine(StartLevelProgressMoveBarInSeconds());

        _unitLevel.OnLevelUp += UnitLevel_OnLevelUp;
    }

    private void UnitLevel_OnLevelUp(object sender, System.EventArgs e)
    {
        if (_unitLevel.HasReachedMaxLevel(_unitLevel.GetCurrentLevel()))
        {
            _unitDisplayLevelText.text = $"Lvl. MAX";
            print("true");
            return;
        }

        StartCoroutine(StartLevelProgressMoveBarInSeconds());
    }

    private IEnumerator StartLevelProgressMoveBarInSeconds()
    {
        int currentXP = _unitLevel.GetCurrentXP();
        int xpToNextLevel = _unitLevel.GetXPToLevelUP();
        int xpLeftOvers = !_leveledUp ? _unitLevel.GetXPLeftOvers() : 0;

        float timer = 0f;

        while (timer <= _maxTimeInSeconds)
        {
            timer += Time.deltaTime;

            float normalizedTime = timer / _maxTimeInSeconds;
            float currentXPnormalizedValue = MathUtils.NormalizeValue(currentXP, 0, xpToNextLevel);
            float xpLeftOversNormalizedValue = MathUtils.NormalizeValue(xpLeftOvers, 0, xpToNextLevel);

            _progressBarForeground.fillAmount = Mathf.Lerp(xpLeftOversNormalizedValue, currentXPnormalizedValue, InterpolateUtils.EaseInCubic(normalizedTime));
            
            yield return null;
        }

        if (currentXP >= xpToNextLevel)
        {
            _unitLevel.IncreaseLevel();
            UpdateLevelText(_unitLevel.GetCurrentLevel());
            _unitLevel.InvokeLevelUPEvent();
            _leveledUp = true;
        }
        else
        {
            // Save left over XPs and level
            _unitLevel.SetXPLeftOver(currentXP);


            SaveGameManager.Instance.TrySaveUnitLevel(_unitSOName, _unitLevel.GetCurrentLevel());
            SaveGameManager.Instance.TrySaveUnitLeftOverXPs(_unitSOName, _unitLevel.GetXPLeftOvers());
        }
    }

    private void UpdateLevelText(int newLevel) => _unitDisplayLevelText.text = $"Lvl. {newLevel}";
}
