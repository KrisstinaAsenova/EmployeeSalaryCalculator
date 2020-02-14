namespace SalaryCalculator.Services.Contracts
{
    public interface ISalaryCalculator
    {
        decimal GetNetSalary(decimal grossSalary);
    }
}
