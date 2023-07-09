using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplayInterviewSingleUI : MonoBehaviour
{
    [SerializeField] private Image _unitDisplayInterviewImage;
    [SerializeField] private TextMeshProUGUI _unitDisplayInterviewNameText;
    [SerializeField] private TextMeshProUGUI _unitDisplayInterviewLevelText;

    public void Setup(Sprite unitInterviewDisplayImage, string unitDisplayInterviewNameText, string unitDisplayInterviewLevelText)
    {
        _unitDisplayInterviewImage.sprite = unitInterviewDisplayImage;
        _unitDisplayInterviewNameText.text = unitDisplayInterviewNameText;
        _unitDisplayInterviewLevelText.text = $"Lvl. {unitDisplayInterviewLevelText}";
    }
}
