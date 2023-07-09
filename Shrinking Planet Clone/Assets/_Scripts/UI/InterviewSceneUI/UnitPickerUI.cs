using System.Collections.Generic;
using UnityEngine;

public class UnitPickerUI : MonoBehaviour
{
    [SerializeField] private GameObject _unitPickerUI;
    [SerializeField] private GameObject _unitDisplayInterviewSinglePrefab;
    [SerializeField] private Transform _unitInterviewDisplayGroup;

    private void Start()
    {
        Show();
        ShowUnitsInterviewDisplaySingleUI();
    }

    private void Show() => _unitPickerUI.SetActive(true);

    private void Hide() => _unitPickerUI.SetActive(false);

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
                unitInterviewDisplayLvl
            );
        }
    }
}
