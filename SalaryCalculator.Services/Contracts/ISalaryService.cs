using SalaryCalculator.Data.Models;
using System.Threading.Tasks;

namespace SalaryCalculator.Services.Contracts
{
    public interface ISalaryService
    {
        Task<Salary> CalculateSalaryAsync(string email, decimal grossSalary, string country);
    }
}
