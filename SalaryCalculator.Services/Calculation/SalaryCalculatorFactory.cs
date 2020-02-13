using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Services.Calculation
{
    public class SalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        public SalaryCalculator GetCalculatorFor(string country)
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