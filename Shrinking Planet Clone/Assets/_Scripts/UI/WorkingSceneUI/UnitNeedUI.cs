using Managers;
using Unit.UnitStates;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WorkingSceneUI
{
    public class UnitNeedUI : MonoBehaviour
    {
        [SerializeField] private GameObject _unitNeedUI;
        [SerializeField] private Image _unitNeedImage;
        [SerializeField] private Unit.Unit _unit;

        private void Start()
        {
            HideUI();

            _unit.OnUnitNeedRequested += Unit_OnUnitNeedRequested;
            _unit.OnUnitNeedFulfilled += Unit_OnUnitNeedFulfilled;
            _unit.OnUnitObjectDrop += Unit_OnUnitObjectDrop;
            UnitWorkingState.OnUnitPickedObject += UnitWorkingState_OnUnitPickedObject;
            DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        }

        private void OnDestroy()
        {
            _unit.OnUnitNeedRequested -= Unit_OnUnitNeedRequested;
            _unit.OnUnitNeedFulfilled -= Unit_OnUnitNeedFulfilled;
            _unit.OnUnitObjectDrop -= Unit_OnUnitObjectDrop;
            UnitWorkingState.OnUnitPickedObject -= UnitWorkingState_OnUnitPickedObject;
            DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
        }

        private void DayManager_OnDayEnded(object sender, System.EventArgs e)
        {
            HideUI();
        }

        private void Unit_OnUnitObjectDrop(object sender, System.EventArgs e)
        {
            ShowUI();
        }

        private void UnitWorkingState_OnUnitPickedObject(object sender, System.EventArgs e)
        {
            Unit.Unit senderUnit = (Unit.Unit)sender;

            if (ReferenceEquals(senderUnit, _unit))
            {
                HideUI();
            }
        }

        private void Unit_OnUnitNeedFulfilled(object sender, System.EventArgs e)
        {
            HideUI();
        }

        private void Unit_OnUnitNeedRequested(object sender, Unit.Unit.UnitNeedRequestedArgs e)
        {
            ShowUI();
            SetUnitNeedSprite(e.RequestedNeed.Icon);
        }

        private void ShowUI() => _unitNeedUI.SetActive(true);

        private void HideUI() => _unitNeedUI.SetActive(false);

        private void SetUnitNeedSprite(Sprite sprite) => _unitNeedImage.sprite = sprite;
    }
}
