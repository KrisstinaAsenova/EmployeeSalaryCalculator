using SalaryCalculator.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
