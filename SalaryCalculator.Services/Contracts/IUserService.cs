using SalaryCalculator.Data.Models;
using System.Threading.Tasks;

namespace SalaryCalculator.Services.Contracts
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(string email);
        Task<User> FindUserAsync(string email);
    }
}
