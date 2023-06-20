using System;
using UnityEngine;

public class UnitOccupation : MonoBehaviour
{
    public event EventHandler OnUnitOccupationSet;

    private string _occupation;

    public void SetUnitOccupation(string occupation)
    {
        _occupation = occupation;
        OnUnitOccupationSet?.Invoke(this, EventArgs.Empty);
    }

    public string GetUnitOccupation() => _occupation;
}
