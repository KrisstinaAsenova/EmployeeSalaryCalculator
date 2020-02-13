using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Services.Contracts
{
    public interface ISalaryService
    {
        Task<Salary> CreateSalaryAsync(string email, decimal grossSalary, string country);
    }
}
