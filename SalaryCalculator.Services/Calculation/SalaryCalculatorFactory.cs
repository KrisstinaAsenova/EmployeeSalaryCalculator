using SalaryCalculator.Services.Contracts;
using System;

namespace SalaryCalculator.Services.Calculation
{
    public class SalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        public ISalaryCalculator GetCalculatorFor(string country)
        {
            switch(country)
            {
                case "Bulgaria":
                    return new BulgarianSalaryCalculator();
                case "Germany":
                    return new GermanSalaryCalculator();
                case "USA":
                    return new USASalaryCalculator();
                default:
                    throw new NotSupportedException("Calculator for this country is not available!");
            }
        }
    }
}