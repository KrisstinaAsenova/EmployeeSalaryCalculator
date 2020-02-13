using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Services.Calculation
{
    public interface ISalaryCalculator
    {
        decimal GetNetSalary(decimal grossSalary);
    }
}
