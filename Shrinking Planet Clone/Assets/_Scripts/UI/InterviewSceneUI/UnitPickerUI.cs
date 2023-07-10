using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitPickerUI : MonoBehaviour
{
    public static event EventHandler OnUnitsPicked;

    [SerializeField] private GameObject _unitPickerUI;
    [SerializeField] private GameObject _unitDisplayInterviewSinglePrefab;
    [SerializeField] private Transform _unitInterviewDisplayGroup;
    [SerializeField] private Button _proceedButton;

    private void Awake()
    {
        Show();
        HideProceedButton();

        _proceedButton.onClick.AddListener(() =>
        {
            Hide();
            OnUnitsPicked?.Invoke(this, EventArgs.Empty);
        });
    }

    private void Start()
    {
        ShowUnitsInterviewDisplaySingleUI();
        UnitUIPickerManager.Instance.OnInterviewUnitSelected += UnitUIPickerManager_OnInterviewUnitSelected;
    }

    private void OnDestroy()
    {
        UnitUIPickerManager.Instance.OnInterviewUnitSelected -= UnitUIPickerManager_OnInterviewUnitSelected;
    }

    private void UnitUIPickerManager_OnInterviewUnitSelected(object sender, System.EventArgs e)
    {
        if (UnitUIPickerManager.Instance.AreAllUnitsSelected())
        {
            ShowProceedButton();
            return;
        }

        HideProceedButton();
    }

    private void Show() => _unitPickerUI.SetActive(true);

    private void Hide() => _unitPickerUI.SetActive(false);

    private void ShowProceedButton() => _proceedButton.gameObject.SetActive(true);

    private void HideProceedButton() => _proceedButton.gameObject.SetActive(false);

    private void ShowUnitsInterviewDisplaySingleUI()
    {
        List<UnitSO> unitSOList = InterviewUnitManager.Instance.GetInterviewUnitSOList();

        foreach (UnitSO unitSO in unitSOList)
        {
            GameObject unitInterviewDisplaySingle = Instantiate(_unitDisplayInterviewSinglePrefab, _unitInterviewDisplayGroup);

            UnitDisplayInterviewSingleUI unitDisplayInterviewSingleUI = unitInterviewDisplaySingle.GetComponent<UnitDisplayInterviewSingleUI>();
            Sprite unitInterviewDisplayImage = unitSO.UnitDisplayImage;
            string unitInterviewDisplayName = unitSO.UnitName;
            string unitInterviewDisplayLvl = "1";

            unitDisplayInterviewSingleUI.Setup(
                unitInterviewDisplayImage,
                unitInterviewDisplayName,
                unitInterviewDisplayLvl,
                unitSO
            );
        }
    }
}
