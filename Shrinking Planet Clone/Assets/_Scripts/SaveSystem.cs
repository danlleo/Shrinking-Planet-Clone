using UnityEngine;

public class SaveSystem : Singleton<SaveSystem>
{
    private const int DEFAULT_COMPANY_RANK_POSITION = 100;
    private const int DEFAULT_TOTAL_MONEY_AMOUNT = 999;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
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
}
