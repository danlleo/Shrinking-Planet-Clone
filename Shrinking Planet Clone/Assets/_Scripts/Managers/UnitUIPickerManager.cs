using System;
using System.Collections.Generic;
using Unit;
using UnityEngine;

namespace Managers
{
    public class UnitUIPickerManager : Singleton<UnitUIPickerManager>
    {
        public event EventHandler OnInterviewUnitSelected;

        private const int MaxSelectedUnits = 3;

        private readonly List<UnitSO> _unitSOList = new();

        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _hoveredColor;
        [SerializeField] private Color _defaultColor;

        public Color GetDefaultColor() => _defaultColor;

        public Color GetSelectedColor() => _selectedColor;

        public Color GetHoveredColor() => _hoveredColor;

        public void AddUnit(UnitSO unitSO) => _unitSOList.Add(unitSO);

        public void RemoveUnit(UnitSO unitSO) => _unitSOList.Remove(unitSO);

        public bool AreAllUnitsSelected() => _unitSOList.Count == MaxSelectedUnits;

        public void InvokeInterviewUnitSelectedEvent() => OnInterviewUnitSelected?.Invoke(this, EventArgs.Empty);

        public List<UnitSO> GetUnitSOList() => _unitSOList;
    }
}
