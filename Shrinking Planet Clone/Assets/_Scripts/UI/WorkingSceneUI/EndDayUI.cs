using System;
using System.Collections.Generic;
using Managers;
using Unit;
using UnityEngine;
using UnityEngine.UI;

namespace UI.WorkingSceneUI
{
    public class EndDayUI : MonoBehaviour
    {
        [SerializeField] private GameObject _endDayUI;
        [SerializeField] private Button _endDayButton;
        [SerializeField] private Transform _unitDisplayGroup;
        [SerializeField] private Transform _unitDispalySinglePrefab;

        private void Awake()
        {
            _endDayButton.onClick.AddListener(() =>
            {
                DayManager.Instance.ProceedToAnotherDay();
                Loader.Load(Loader.Scene.ManagingScene);
            });
        }

        private void Start()
        {
            HideUI();
            DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
        }

        private void OnDestroy()
        {
            DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
        }

        private void DayManager_OnDayEnded(object sender, EventArgs e)
        {
            ShowUI();
            ShowUnitsDisplaySingleUI();
        }

        private void ShowUI() => _endDayUI.SetActive(true);

        private void HideUI() => _endDayUI.SetActive(false);

        private void ShowUnitsDisplaySingleUI()
        {
            IEnumerable<Unit.Unit> unitList = UnitManager.Instance.GetAllUnits();

            foreach (Unit.Unit unit in unitList)
            {
                Transform unitDisplaySingle = Instantiate(_unitDispalySinglePrefab, _unitDisplayGroup);
                UnitDisplaySingleUI unitDisplaySingleUI = unitDisplaySingle.GetComponent<UnitDisplaySingleUI>();
                UnitLevel unitLevel = unit.GetComponent<UnitLevel>();
                UnitEconomy unitEconomy = unit.GetComponent<UnitEconomy>();
                Sprite unitDisplayImage = unit.GetUnitImage();
            
                string unitDisplayName = unit.GetUnitName();
                string unitDisplayLevel = unitLevel.GetCurrentLevel().ToString();
                string unitSOName = unit.GetUnitSOName();

                unitDisplaySingleUI.Initialize(
                    unitDisplayImage, 
                    unitDisplayName, 
                    unitDisplayLevel, 
                    unitLevel, 
                    unitEconomy,
                    unitSOName
                );
            }
        }
    }
}
