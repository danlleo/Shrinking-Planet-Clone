using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplaySingleUI : MonoBehaviour
{
    [SerializeField] private Image _unitDisplayImage;
    [SerializeField] private TextMeshProUGUI _unitDisplayNameText;
    [SerializeField] private TextMeshProUGUI _unitDisplayLevelText;

    public void Setup(Sprite unitDisplayImage, string unitDisplayNameText, string unitDisplayLevelText)
    {
        _unitDisplayImage.sprite = unitDisplayImage;

        _unitDisplayNameText.text = unitDisplayNameText;
        _unitDisplayLevelText.text = "Lvl. " + unitDisplayLevelText;
    }
}
