using UnityEngine;

public class UnitLevel : MonoBehaviour
{
    private int _currentLevel = 1;
    private int _currentXP = 300;

    public int GetUnitCurrentXP() => _currentXP;

    public int GetUnitCurrentLevel() => _currentLevel;

    public void IncreaseUnitLevel() => _currentLevel++;

    public void SetUnitXP(int XPAmount) => _currentXP = XPAmount;
}
