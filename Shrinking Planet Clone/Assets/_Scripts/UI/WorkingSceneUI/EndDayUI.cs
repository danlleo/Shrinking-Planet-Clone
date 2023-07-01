using System.Collections.Generic;
using UnityEngine;

public class EndDayUI : MonoBehaviour
{
    [SerializeField] private GameObject _endDayUI;
    [SerializeField] private Transform _unitDisplayGroup;
    [SerializeField] private Transform _unitDispalySinglePrefab;

    private void Start()
    {
        Hide();
        DayManager.Instance.OnDayEnded += DayManager_OnDayEnded;
    }

    private void OnDestroy()
    {
        DayManager.Instance.OnDayEnded -= DayManager_OnDayEnded;
    }

    private void DayManager_OnDayEnded(object sender, System.EventArgs e)
    {
        Show();
        AddUnitDisplaySingleUI();
    }

    private void Show() => _endDayUI.SetActive(true);

    private void Hide() => _endDayUI.SetActive(false);

    private void AddUnitDisplaySingleUI()
    {
        List<Unit> unitList = UnitManager.Instance.GetAllUnits();

        foreach (var unit in unitList)
        {
            Transform unitDisplaySingle = Instantiate(_unitDispalySinglePrefab, _unitDisplayGroup);
            UnitDisplaySingleUI unitDisplaySingleUI = unitDisplaySingle.GetComponent<UnitDisplaySingleUI>();
            UnitLevel unitLevel = unit.GetComponent<UnitLevel>();
            Sprite unitDisplayImage = unit.GetUnitImage();
            string unitDisplayName = unit.GetUnitName();
            string unitDisplayLevel = unitLevel.GetUnitCurrentLevel().ToString();

            unitDisplaySingleUI.Setup(unitDisplayImage, unitDisplayName, unitDisplayLevel, unitLevel);
        }
    }
}
