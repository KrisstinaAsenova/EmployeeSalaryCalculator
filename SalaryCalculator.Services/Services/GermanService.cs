using SalaryCalculator.Data;
using SalaryCalculator.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Services.Services
{
    public class GermanService : IGermanyService
    {
        private readonly SalaryCalculatorDbContext salaryContext;
        private readonly IUserService userService;

        public GermanService(SalaryCalculatorDbContext salaryContext, IUserService userService)
        {
            this.salaryContext = salaryContext;
            this.userService = userService;
        }

    }
}
