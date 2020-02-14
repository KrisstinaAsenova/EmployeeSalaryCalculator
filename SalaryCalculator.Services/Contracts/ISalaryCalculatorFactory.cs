namespace SalaryCalculator.Services.Contracts
{
    public interface ISalaryCalculatorFactory
    {
        ISalaryCalculator GetCalculatorFor(string country);
    }
}
