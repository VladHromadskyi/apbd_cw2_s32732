using System.Runtime.InteropServices.JavaScript;

namespace cw3APBD.Services;

public interface IPenaltyCalculator
{
    decimal Calculate(DateTime DueDate, DateTime ReturnDate);
}