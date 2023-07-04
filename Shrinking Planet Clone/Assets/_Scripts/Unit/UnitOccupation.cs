using System;
using UnityEngine;

public class UnitOccupation : MonoBehaviour
{
    public event EventHandler OnUnitOccupationSet;

    [SerializeField] private UnitSO _unitSO;

    private UnitOccupationList _occupation;

    public void SetUnitOccupation(UnitOccupationList occupation)
    {
        _occupation = occupation;
        OnUnitOccupationSet?.Invoke(this, EventArgs.Empty);
    }

    public UnitOccupationList GetUnitOccupation() => _occupation;

    public UnitOccupationList GetDefaultUnitOccupation() => _unitSO.DefaultOccupation;
}
