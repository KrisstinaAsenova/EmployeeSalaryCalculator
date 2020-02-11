using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Data;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<User> CreateUser(string email)
        {
            var user = await this.FindUser(email);
            if( user == null )
            {
                var userToAdd = new User { Email = email };
                this.salaryContext.Users.Add(userToAdd);
                await this.salaryContext.SaveChangesAsync();

                return userToAdd;
            }

            return user;
        }

        public async Task<User> FindUser(string email)
        {
            return await this.salaryContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
