using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        IEnumerable<Unit> unitList = UnitManager.Instance.GetAllUnits();

        foreach (var unit in unitList)
        {
            Transform unitDisplaySingle = Instantiate(_unitDispalySinglePrefab, _unitDisplayGroup);
            UnitDisplaySingleUI unitDisplaySingleUI = unitDisplaySingle.GetComponent<UnitDisplaySingleUI>();
            UnitLevel unitLevel = unit.GetComponent<UnitLevel>();
            Sprite unitDisplayImage = unit.GetUnitImage();
            string unitDisplayName = unit.GetUnitName();
            string unitDisplayLevel = unitLevel.GetUnitCurrentLevel().ToString();

            unitDisplaySingleUI.Setup(
                unitDisplayImage, 
                unitDisplayName, 
                unitDisplayLevel, 
                unitLevel
            );
        }
    }
}
