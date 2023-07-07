using System;
using UnityEngine;

public class UnitOccupation : MonoBehaviour
{
    public event EventHandler OnUnitOccupationSet;

    [SerializeField] private UnitSO _unitSO;

    private UnitOccupationTypes _occupation;

    public void SetUnitOccupation(UnitOccupationTypes occupation)
    {
        _occupation = occupation;
        OnUnitOccupationSet?.Invoke(this, EventArgs.Empty);
    }

    public UnitOccupationTypes GetUnitOccupation() => _occupation;

    public UnitOccupationTypes GetDefaultUnitOccupation() => _unitSO.DefaultOccupation;
}
