namespace cw3APBD.Services;

public class DailyPenaltyCalculator : IPenaltyCalculator
{
    private const decimal DailyRate = 10.5m;
    public decimal Calculate(DateTime DueDate, DateTime ReturnDate)
    {
        if (ReturnDate <= DueDate)
        {
            return 0;
        }

        int overdueDays = (ReturnDate - DueDate).Days;
        return overdueDays * DailyRate;
    }
}