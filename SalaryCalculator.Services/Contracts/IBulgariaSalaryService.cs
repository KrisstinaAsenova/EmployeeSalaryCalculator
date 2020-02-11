using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Services.Contracts
{
    public interface IBulgariaSalaryService
    {
        Task<BulgarianSalary> CreateBulgariaSalaryAsync(string email, decimal grossSalary);
    }
}
