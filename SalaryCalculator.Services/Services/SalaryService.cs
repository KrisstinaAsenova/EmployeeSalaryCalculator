using SalaryCalculator.Data;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Services.Calculation;
using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Services.Providers;
using System;
using System.Threading.Tasks;

namespace SalaryCalculator.Services.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly SalaryCalculatorDbContext salaryContext;
        private readonly IUserService userService;
        private readonly IValidator validator;
        private readonly ISalaryCalculatorFactory salaryCalculatorFactory;

        public SalaryService(SalaryCalculatorDbContext salaryContext, IUserService userService,
            IValidator validator, ISalaryCalculatorFactory salaryCalculatorFactory)
        {
            this.salaryContext = salaryContext;
            this.userService = userService;
            this.validator = validator;
            this.salaryCalculatorFactory = salaryCalculatorFactory;
        }

        public async Task<Salary> CalculateSalaryAsync(string email, decimal grossSalary, string country)
        {
            if (!RegexUtilities.IsValidEmail(email))
                throw new ArgumentException("Invalid email");

            var user = await this.userService.CreateUser(email);

            var salaryCalculator = this.salaryCalculatorFactory.GetCalculatorFor(country);
            var netSalary = salaryCalculator.GetNetSalary(grossSalary);

            var salary = new Salary
            {
                Country = country,
                UserId = user.Id,
                DateCheck = DateTime.UtcNow,
                PersonEmail = email,
                GrossSalary = grossSalary,
                Tax = grossSalary - netSalary,
                NetSalary = netSalary
            };

            this.salaryContext.Salaries.Add(salary);
            await this.salaryContext.SaveChangesAsync();

            return salary;
        }
    }
}
