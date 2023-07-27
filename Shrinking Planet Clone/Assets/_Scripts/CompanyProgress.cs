public class CompanyProgress
{
    private const int COMPANY_RANK_100_INTERVIEW_PRICE = 1100;
    private const int COMPANY_RANK_90_INTERVIEW_PRICE = 2100;
    private const int COMPANY_RANK_80_INTERVIEW_PRICE = 3100;
    private const int COMPANY_RANK_70_INTERVIEW_PRICE = 4100;
    private const int COMPANY_RANK_60_INTERVIEW_PRICE = 5100;
    private const int COMPANY_RANK_50_INTERVIEW_PRICE = 5700;
    private const int COMPANY_RANK_40_INTERVIEW_PRICE = 6400;
    private const int COMPANY_RANK_30_INTERVIEW_PRICE = 7000;
    private const int COMPANY_RANK_20_INTERVIEW_PRICE = 8000;
    private const int COMPANY_RANK_10_INTERVIEW_PRICE = 9000;
    private const int COMPANY_RANK_2_INTERVIEW_PRICE = 10000;

    public static int GetInterviewPrice(int companyRankPosition)
    {
        return companyRankPosition switch
        {
            100 => COMPANY_RANK_100_INTERVIEW_PRICE,
            90 => COMPANY_RANK_90_INTERVIEW_PRICE,
            80 => COMPANY_RANK_80_INTERVIEW_PRICE,
            70 => COMPANY_RANK_70_INTERVIEW_PRICE,
            60 => COMPANY_RANK_60_INTERVIEW_PRICE,
            50 => COMPANY_RANK_50_INTERVIEW_PRICE,
            40 => COMPANY_RANK_40_INTERVIEW_PRICE,
            30 => COMPANY_RANK_30_INTERVIEW_PRICE,
            20 => COMPANY_RANK_20_INTERVIEW_PRICE,
            10 => COMPANY_RANK_10_INTERVIEW_PRICE,
            2 => COMPANY_RANK_2_INTERVIEW_PRICE,
            _ => COMPANY_RANK_100_INTERVIEW_PRICE,
        };
    }

    // ... 
}
