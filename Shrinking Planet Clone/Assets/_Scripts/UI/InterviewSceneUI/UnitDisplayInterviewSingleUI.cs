using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnitDisplayInterviewSingleUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Image _unitDisplayInterviewImage;
    [SerializeField] private Image _unitDisplayInterviewBackground;
    [SerializeField] private TextMeshProUGUI _unitDisplayInterviewNameText;
    [SerializeField] private TextMeshProUGUI _unitDisplayInterviewLevelText;

    private bool _isSelected;

    private UnitSO _unitSO;

    private void Start()
    {
        _unitDisplayInterviewBackground.color = UnitUIPickerManager.Instance.GetDefaultColor();
    }

    public void Setup(Sprite unitInterviewDisplayImage, string unitDisplayInterviewNameText, string unitDisplayInterviewLevelText, UnitSO unitSO)
    {
        _unitDisplayInterviewImage.sprite = unitInterviewDisplayImage;
        _unitDisplayInterviewNameText.text = unitDisplayInterviewNameText;
        _unitDisplayInterviewLevelText.text = $"{unitDisplayInterviewLevelText}";
        _unitSO = unitSO;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_isSelected)
            return;

        SetBackgroundColor(UnitUIPickerManager.Instance.GetHoveredColor());
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isSelected)
        {
            DeselectInterviewUnit();
            SetBackgroundColor(UnitUIPickerManager.Instance.GetDefaultColor());
            return;
        }
        
        if (UnitUIPickerManager.Instance.AreAllUnitsSelected())
            return;

        SelectInterviewUnit();
        SetBackgroundColor(UnitUIPickerManager.Instance.GetSelectedColor());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_isSelected)
            return;

        SetBackgroundColor(UnitUIPickerManager.Instance.GetDefaultColor());
    }

    private void SetBackgroundColor(Color color) => _unitDisplayInterviewBackground.color = color;

    private void SelectInterviewUnit()
    {
        _isSelected = true;
        UnitUIPickerManager.Instance.AddUnit(_unitSO);
        UnitUIPickerManager.Instance.InvokeInterviewUnitSelectedIvent();
    }

    private void DeselectInterviewUnit()
    {
        _isSelected = false;
        UnitUIPickerManager.Instance.RemoveUnit(_unitSO);
        UnitUIPickerManager.Instance.InvokeInterviewUnitSelectedIvent();
    }
}
