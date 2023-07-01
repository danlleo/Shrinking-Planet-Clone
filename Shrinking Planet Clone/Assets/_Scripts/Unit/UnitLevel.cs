using System;
using UnityEngine;

public class UnitLevel : MonoBehaviour
{
    public event EventHandler OnLevelUp;

    private int _currentLevel = 1;
    private int _currentXP = 0;
    private int _previousXPValue = 0;

    public int GetUnitCurrentXPValue() => _currentXP;

    public int GetUnitCurrentLevel() => _currentLevel;

    public int GetPreviousXPValue() => _previousXPValue;

    public void IncreaseUnitLevel() => _currentLevel++;

    public void SetUnitCurrentXP(int XPAmount) => _currentXP = XPAmount;

    public void SetUnitPreviousXP(int XPAmount) => _previousXPValue = XPAmount;

    public void InvokeLevelUPEvent() => OnLevelUp?.Invoke(this, EventArgs.Empty);
}
