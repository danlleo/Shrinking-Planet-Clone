public abstract class CompanyProgress
{
    private const int Rank100InterviewPrice = 1100;
    private const int Rank90InterviewPrice = 2100;
    private const int Rank80InterviewPrice = 3100;
    private const int Rank70InterviewPrice = 4100;
    private const int Rank60InterviewPrice = 5100;
    private const int Rank50InterviewPrice = 5700;
    private const int Rank40InterviewPrice = 6400;
    private const int Rank30InterviewPrice = 7000;
    private const int Rank20InterviewPrice = 8000;
    private const int Rank10InterviewPrice = 9000;
    private const int Rank2InterviewPrice = 10000;

    private const int Rank100NextPosition = 90;
    private const int Rank90NextPosition = 80;
    private const int Rank80NextPosition = 70;
    private const int Rank70NextPosition = 60;
    private const int Rank60NextPosition = 50;
    private const int Rank50NextPosition = 40;
    private const int Rank40NextPosition = 30;
    private const int Rank30NextPosition = 20;
    private const int Rank20NextPosition = 10;
    private const int Rank10NextPosition = 2;
    private const int Rank2NextPosition = 1;

    private const int FinalCompanyRankPosition = 1;

    public static int GetInterviewPrice(int companyRankPosition)
    {
        return companyRankPosition switch
        {
            100 => Rank100InterviewPrice,
            90 => Rank90InterviewPrice,
            80 => Rank80InterviewPrice,
            70 => Rank70InterviewPrice,
            60 => Rank60InterviewPrice,
            50 => Rank50InterviewPrice,
            40 => Rank40InterviewPrice,
            30 => Rank30InterviewPrice,
            20 => Rank20InterviewPrice,
            10 => Rank10InterviewPrice,
            2 => Rank2InterviewPrice,
            _ => Rank100InterviewPrice,
        };
    }

    public static int GetNextCompanyRankPosition(int currentCompanyRankPosition)
    {
        return currentCompanyRankPosition switch
        {
            100 => Rank100NextPosition,
            90 => Rank90NextPosition,
            80 => Rank80NextPosition,
            70 => Rank70NextPosition,
            60 => Rank60NextPosition,
            50 => Rank50NextPosition,
            40 => Rank40NextPosition,
            30 => Rank30NextPosition,
            20 => Rank20NextPosition,
            10 => Rank10NextPosition,
            2 => Rank2NextPosition,
            _ => Rank100NextPosition,
        };
    }

    public static int GetFinalCompanyRankPosition() => FinalCompanyRankPosition;
}
