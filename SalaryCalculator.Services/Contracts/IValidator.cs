namespace SalaryCalculator.Services.Contracts
{
    public interface IValidator
    {
        void IsGrossSalaryInRange(decimal grossSalary);
        void IsValidEmail(string email);
    }
}
