using UnityEngine;
using UnityEngine.UI;

public class UnitNeedUI : MonoBehaviour
{
    [SerializeField] private GameObject _unitNeedUI;
    [SerializeField] private Image _unitNeedImage;
    [SerializeField] private Unit _unit;

    private void Start()
    {
        HideUI();

        _unit.OnUnitNeedRequested += Unit_OnUnitNeedRequested;
    }

    private void Unit_OnUnitNeedRequested(object sender, Unit.UnitNeedRequestedArgs e)
    {
        ShowUI();
        SetUnitNeedSprite(e.RequestedNeed.Icon);
    }

    private void ShowUI() => _unitNeedUI.SetActive(true);

    private void HideUI() => _unitNeedUI.SetActive(false);

    private void SetUnitNeedSprite(Sprite sprite) => _unitNeedImage.sprite = sprite;
}
