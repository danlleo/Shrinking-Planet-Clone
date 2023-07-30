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

    private const int COMPANY_RANK_100_NEXT_POSITION = 90;
    private const int COMPANY_RANK_90_NEXT_POSITION = 80;
    private const int COMPANY_RANK_80_NEXT_POSITION = 70;
    private const int COMPANY_RANK_70_NEXT_POSITION = 60;
    private const int COMPANY_RANK_60_NEXT_POSITION = 50;
    private const int COMPANY_RANK_50_NEXT_POSITION = 40;
    private const int COMPANY_RANK_40_NEXT_POSITION = 30;
    private const int COMPANY_RANK_30_NEXT_POSITION = 20;
    private const int COMPANY_RANK_20_NEXT_POSITION = 10;
    private const int COMPANY_RANK_10_NEXT_POSITION = 2;
    private const int COMPANY_RANK_2_NEXT_POSITION = 1;

    private static int FINAL_COMPANY_RANK_POSITION = 1;

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

    public static int GetNextCompanyRankPosition(int currentCompanyRankPosition)
    {
        return currentCompanyRankPosition switch
        {
            100 => COMPANY_RANK_100_NEXT_POSITION,
            90 => COMPANY_RANK_90_NEXT_POSITION,
            80 => COMPANY_RANK_80_NEXT_POSITION,
            70 => COMPANY_RANK_70_NEXT_POSITION,
            60 => COMPANY_RANK_60_NEXT_POSITION,
            50 => COMPANY_RANK_50_NEXT_POSITION,
            40 => COMPANY_RANK_40_NEXT_POSITION,
            30 => COMPANY_RANK_30_NEXT_POSITION,
            20 => COMPANY_RANK_20_NEXT_POSITION,
            10 => COMPANY_RANK_10_NEXT_POSITION,
            2 => COMPANY_RANK_2_NEXT_POSITION,
            _ => COMPANY_RANK_100_NEXT_POSITION,
        };
    }

    public static int GetFinalCompanyRankPosition() => FINAL_COMPANY_RANK_POSITION;
}
