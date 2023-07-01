using System;
using UnityEngine;

public class UnitOccupation : MonoBehaviour
{
    public event EventHandler OnUnitOccupationSet;

    [SerializeField] private UnitSO _unitSO;

    private string _occupation;

    public void SetUnitOccupation(string occupation)
    {
        _occupation = occupation;
        OnUnitOccupationSet?.Invoke(this, EventArgs.Empty);
    }

    public string GetUnitOccupation() => _occupation;

    public string GetDefaultUnitOccupation() => _unitSO.DefaultOccupation;
}
