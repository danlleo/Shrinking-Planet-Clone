using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitUIPickerManager : Singleton<UnitUIPickerManager>
{
    public event EventHandler OnInterviewUnitSelected;

    private const int MAX_SELECTED_UNITS = 3;

    private List<UnitSO> _unitSOList = new List<UnitSO>();

    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _hoveredColor;
    [SerializeField] private Color _defaultColor;

    protected override void Awake()
    {
        base.Awake();
    }

    public Color GetDefaultColor() => _defaultColor;

    public Color GetSelectedColor() => _selectedColor;

    public Color GetHoveredColor() => _hoveredColor;

    public void AddUnit(UnitSO unitSO) => _unitSOList.Add(unitSO);

    public void RemoveUnit(UnitSO unitSO) => _unitSOList.Remove(unitSO);

    public bool AreAllUnitsSelected() => _unitSOList.Count == MAX_SELECTED_UNITS;

    public void InvokeInterviewUnitSelectedIvent() => OnInterviewUnitSelected?.Invoke(this, EventArgs.Empty);

    public List<UnitSO> GetUnitSOList() => _unitSOList;
}
