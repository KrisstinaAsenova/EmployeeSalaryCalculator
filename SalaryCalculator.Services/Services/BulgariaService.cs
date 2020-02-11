using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Services.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalaryCalculator.Services.Utils;
using SalaryCalculator.Data;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Services.Services
{
    public class BulgariaService : IBulgariaSalaryService
    {
        private readonly SalaryCalculatorDbContext salaryContext;
        private readonly IUserService userService;
        private readonly IValidator validator;

        public BulgariaService(SalaryCalculatorDbContext salaryContext, IUserService userService, IValidator validator)
        {
            this.salaryContext = salaryContext;
            this.userService = userService;
            this.validator = validator;
        }

        public async Task<BulgarianSalary> CreateBulgariaSalaryAsync(string email, decimal grossSalary)
        {
            //if (!RegexUtilities.IsValidEmail(email))
            //    throw new ArgumentException("Invalid email");

            var user = await this.userService.CreateUser(email);

            var pensionTax = await this.GetPensionTax(grossSalary);
            var healthTax = await this.GetHealthTax(grossSalary);
            var unemploymentTax = await this.GetUnemploymentTax(grossSalary);
            var commonTax = await this.GetCommonTax(grossSalary);
            var supplementaryTax = await this.GetSupplementaryTax(grossSalary);

            var tax = pensionTax + healthTax + unemploymentTax + commonTax + supplementaryTax;
            var personalTax = await this.GetPersonalIncomeTax(grossSalary, tax);
            var summary = grossSalary - tax + personalTax;

            var salary = new BulgarianSalary { 
                PersonEmail = email,
                GrossSalary= grossSalary,
                Pensions =pensionTax,
                Tax = tax,
                HealthSecurity =healthTax,
                Unemployment= unemploymentTax,
                Common = commonTax,
                Supplementary= supplementaryTax,
                PersonalIncomeTax =personalTax,
                NetSalary = summary,
                UserId = user.Id
            };

            this.salaryContext.Salaries.Add(salary);
            await this.salaryContext.SaveChangesAsync();

            return salary;
        }
        public async Task<Decimal> GetPensionTax(decimal grossSalary)
        {
            this.validator.IsGrossSalaryInRange(grossSalary);
            return grossSalary * ServicesConstants.PensionInsuranceInBulgaria;
        }

        public async Task<Decimal> GetHealthTax(decimal grossSalary)
        {
            this.validator.IsGrossSalaryInRange(grossSalary);
            return grossSalary * ServicesConstants.HealthInsuranceInBulgaria;
        }

        public async Task<Decimal> GetUnemploymentTax(decimal grossSalary)
        {
            this.validator.IsGrossSalaryInRange(grossSalary);
            return grossSalary * ServicesConstants.UnemploymentInsuranceInBulgaria;
        }

        public async Task<Decimal> GetSupplementaryTax(decimal grossSalary)
        {
            this.validator.IsGrossSalaryInRange(grossSalary);
            return grossSalary * ServicesConstants.SupplementaryInsuranceInBulgaria;
        }

        public async Task<Decimal> GetCommonTax(decimal grossSalary)
        {
            this.validator.IsGrossSalaryInRange(grossSalary);
            return grossSalary * ServicesConstants.CommonTaxInBulgaria;
        }

        public async Task<Decimal> GetPersonalIncomeTax(decimal grossSalary, decimal tax)
        {
            this.validator.IsGrossSalaryInRange(grossSalary);
            return (grossSalary - tax)* ServicesConstants.PersonalIncomeTaxInBulgaria;
        }
    }
}
