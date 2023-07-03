using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
    private const int DEFAULT_COMPANY_RANK_POSITION = 100;
    private const int DEFAULT_TOTAL_MONEY_AMOUNT = 999;
    private const int CURRENT_DAY = 1;

    protected override void Awake()
    {
        base.Awake();
    }

    public void SaveMoneyAmount(int moneyAmount) => PlayerPrefs.SetInt(SaveSystemParams.TOTAL_MONEY_KEY, moneyAmount);

    public int LoadMoneyAmount()
    {
        if (PlayerPrefs.HasKey(SaveSystemParams.TOTAL_MONEY_KEY))
        {
            return PlayerPrefs.GetInt(SaveSystemParams.TOTAL_MONEY_KEY);
        }

        return DEFAULT_TOTAL_MONEY_AMOUNT;
    }

    public void SaveCompanyRankPosition(int companyRankPosition) => PlayerPrefs.SetInt(SaveSystemParams.COMPANY_RANK_POSITION_KEY, companyRankPosition);

    public int LoadCompanyRankPosition()
    {
        if (PlayerPrefs.HasKey(SaveSystemParams.COMPANY_RANK_POSITION_KEY))
        {
            return PlayerPrefs.GetInt(SaveSystemParams.COMPANY_RANK_POSITION_KEY);
        }

        return DEFAULT_COMPANY_RANK_POSITION;
    }

    public void SaveCurrentDay(int currentDay) => PlayerPrefs.SetInt(SaveSystemParams.CURRENT_DAY_KEY, currentDay);

    public int LoadCurrentDay()
    {
        if (PlayerPrefs.HasKey(SaveSystemParams.CURRENT_DAY_KEY))
        {
            return PlayerPrefs.GetInt(SaveSystemParams.CURRENT_DAY_KEY);
        }

        return CURRENT_DAY;
    }
}
