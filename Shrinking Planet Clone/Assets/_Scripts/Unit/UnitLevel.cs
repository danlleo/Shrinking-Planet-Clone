using System;
using UnityEngine;

public class UnitLevel : MonoBehaviour
{
    private const int LEVEL_1_XP_TO_LEVEL_UP = 110;
    private const int LEVEL_2_XP_TO_LEVEL_UP = 130;
    private const int LEVEL_3_XP_TO_LEVEL_UP = 150;
    private const int LEVEL_4_XP_TO_LEVEL_UP = 170;
    private const int LEVEL_5_XP_TO_LEVEL_UP = 190;

    private const int MAX_LEVEL = 5;

    public event EventHandler OnLevelUp;

    [SerializeField] private UnitEconomy _unitEconomy; 

    private int _currentLevel = 1;
    private int _currentXP = 0;
    private int _xpToLevelUP = 100;
    private int _xpLeftOvers = 0;

    public int GetCurrentXP() => _currentXP;

    public int GetCurrentLevel() => _currentLevel;

    public int GetXPToLevelUP()
    {
        return _currentLevel switch
        {
            1 => LEVEL_1_XP_TO_LEVEL_UP,
            2 => LEVEL_2_XP_TO_LEVEL_UP,
            3 => LEVEL_3_XP_TO_LEVEL_UP,
            4 => LEVEL_4_XP_TO_LEVEL_UP,
            5 => LEVEL_5_XP_TO_LEVEL_UP,
            _ => LEVEL_1_XP_TO_LEVEL_UP,
        };
    }

    public int GetXPLevtOvers() => _xpLeftOvers;

    public bool HasReachedMaxLevel(int level) => level == MAX_LEVEL;

    public void IncreaseLevel()
    {
        _currentXP -= _xpToLevelUP;
        _currentLevel++;
    }

    public void SetCurrentLevel(int level)
    {
        if (level < 0)
            throw new ArgumentException("Cannot add negative level value!");

        if (level > MAX_LEVEL)
            throw new ArgumentException("Cannot add level higher than maximum level!");

        _currentLevel = level;
    }

    public void SetCurrentXP(int xpAmount)
    {
        if (xpAmount < 0)
            throw new ArgumentException("Cannot add negative XP value!");

        _currentXP = xpAmount;
    }

    public void SetXPLeftOver(int xpAmount)
    {
        if (xpAmount < 0)
            throw new ArgumentException("XP left over value cannot be less than zero!");

        if (xpAmount >= _xpToLevelUP)
            throw new ArgumentException("XP left over value cannot be greater than or equal to XP_TO_LEVEL_UP!");

        _xpLeftOvers = xpAmount;
    } 

    public void InvokeLevelUPEvent() => OnLevelUp?.Invoke(this, EventArgs.Empty);
}
