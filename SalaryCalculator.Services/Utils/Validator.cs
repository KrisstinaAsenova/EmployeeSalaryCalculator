using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Services.Providers;
using System;
namespace SalaryCalculator.Services.Utils
{
    public class Validator : IValidator
    {
        public void IsGrossSalaryInRange(decimal grossSalary)
        {
            if (grossSalary <= 0)
            {
                throw new ArgumentException("Gross salary can not be 0 or negative!");
            }
        }

        public void IsValidEmail(string email)
        {
            if (!RegexUtilities.IsValidEmail(email))
                throw new ArgumentException("Invalid email");
        }
    }
}
