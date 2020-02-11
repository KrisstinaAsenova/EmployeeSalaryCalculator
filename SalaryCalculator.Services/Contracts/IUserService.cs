using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Services.Contracts
{
    public interface IUserService
    {
        Task<User> CreateUser(string email);
        Task<User> FindUser(string email);
    }
}
