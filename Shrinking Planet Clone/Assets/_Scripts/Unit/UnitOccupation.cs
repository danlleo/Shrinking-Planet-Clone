using System;
using UnityEngine;

public class UnitOccupation : MonoBehaviour
{
    public event EventHandler OnUnitOccupationSet;

    private UnitSO _unitSO;

    private UnitOccupationType _occupation;

    public void Initialize(UnitSO unitSO)
    {
        _unitSO = unitSO;
    }

    public void SetUnitOccupation(UnitOccupationType occupation)
    {
        _occupation = occupation;
        OnUnitOccupationSet?.Invoke(this, EventArgs.Empty);
    }

    public UnitOccupationType GetUnitOccupation() => _occupation;

    public UnitOccupationType GetDefaultUnitOccupation() => _unitSO.DefaultOccupation;
}
