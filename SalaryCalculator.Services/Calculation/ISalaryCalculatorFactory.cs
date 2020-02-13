using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Services.Calculation
{
    public interface ISalaryCalculatorFactory
    {
        SalaryCalculator GetCalculatorFor(string country);
    }
}
