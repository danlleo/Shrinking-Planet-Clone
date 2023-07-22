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
        _unit.OnUnitNeedFulfilled += Unit_OnUnitNeedFulfilled;
        UnitWorkingState.OnUnitPickedObject += UnitWorkingState_OnUnitPickedObject;
    }

    private void OnDestroy()
    {
        _unit.OnUnitNeedRequested -= Unit_OnUnitNeedRequested;
        _unit.OnUnitNeedFulfilled -= Unit_OnUnitNeedFulfilled;
        UnitWorkingState.OnUnitPickedObject -= UnitWorkingState_OnUnitPickedObject;
    }

    private void UnitWorkingState_OnUnitPickedObject(object sender, System.EventArgs e)
    {
        Unit senderUnit = (Unit)sender;

        if (ReferenceEquals(senderUnit, _unit))
        {
            HideUI();
        }
    }

    private void Unit_OnUnitNeedFulfilled(object sender, System.EventArgs e)
    {
        HideUI();
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
