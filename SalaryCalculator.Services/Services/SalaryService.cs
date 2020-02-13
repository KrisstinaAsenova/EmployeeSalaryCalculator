using SalaryCalculator.Data;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Services.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly SalaryCalculatorDbContext salaryContext;
        private readonly IUserService userService;
        private readonly IValidator validator;

        public SalaryService(SalaryCalculatorDbContext salaryContext, IUserService userService, IValidator validator)
        {
            this.salaryContext = salaryContext;
            this.userService = userService;
            this.validator = validator;
        }

        public async Task<Salary> CreateSalaryAsync(string email, decimal grossSalary, string country)
        {
            var user = await this.userService.CreateUser(email);
            decimal tax = 0;
            
            switch (country)
            {
                case "Bulgaria":
                    tax = GetNetInBulgaria(grossSalary);
                    break;
                case "USA":
                    tax = GetNetInUSA(grossSalary);
                    break;
                case "Germany":
                    tax = GetNetInGermany(grossSalary);
                    break;
            }

            var salary = new Salary
            {
                UserId = user.Id,
                DateCheck = DateTime.UtcNow,
                PersonEmail = email,
                GrossSalary = grossSalary,
                Tax = tax,
                NetSalary = grossSalary-tax
            };

            this.salaryContext.Salaries.Add(salary);
            await this.salaryContext.SaveChangesAsync();

            return salary;
        }

        private decimal GetNetInBulgaria(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.TotalInBulgaria;
        }
        private decimal GetNetInUSA(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.TotalInUSA;
        }
        private decimal GetNetInGermany(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.TotalInGerman;
        }
        //private decimal GetPensionTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.PensionsInBulgaria;
        //}

        //private decimal GetHealthTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.HealthSecurityInBulgaria;
        //}

        //private decimal GetUnemploymentTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.UnemploymentInBulgaria;
        //}

        //private decimal GetSupplementaryTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.SupplementaryPensionInBulgaria;
        //}

        //private decimal GetCommonTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.CommonDiseasesAndMaternityInBulgaria;
        //}

        //private decimal GetPersonalIncomeTax(decimal grossSalary, decimal tax)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return (grossSalary - tax) * ServicesConstants.PersonalIncomeTaxInBulgaria;
        //}

        //private decimal GetNursingCareTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.NursingCareInGerman;
        //}
    }
}
