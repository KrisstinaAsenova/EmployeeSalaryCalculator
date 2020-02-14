using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Data;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Services.Contracts;
using Serilog;
using System.Threading.Tasks;

namespace SalaryCalculator.Services.Services
{
    public class UserService : IUserService
    {
        private readonly SalaryCalculatorDbContext salaryContext;
        public UserService(SalaryCalculatorDbContext salaryContext)
        {
            this.salaryContext = salaryContext;
        }

        public async Task<User> CreateUserAsync(string email)
        {
            Log.Verbose($"Call was made to CreateUser with email: {email}");

            var user = await this.FindUserAsync(email);
            if( user == null )
            {
                var userToAdd = new User { Email = email };
                this.salaryContext.Users.Add(userToAdd);
                await this.salaryContext.SaveChangesAsync();

                return userToAdd;
            }

            return user;
        }

        public async Task<User> FindUserAsync(string email)
        {
            return await this.salaryContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
