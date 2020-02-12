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
    //public class BulgariaService : IBulgariaSalaryService
    //{
    //    private readonly SalaryCalculatorDbContext salaryContext;
    //    private readonly IUserService userService;
    //    private readonly IValidator validator;

    //    public BulgariaService(SalaryCalculatorDbContext salaryContext, IUserService userService, IValidator validator)
    //    {
    //        this.salaryContext = salaryContext;
    //        this.userService = userService;
    //        this.validator = validator;
    //    }

    //    public async Task<BulgarianSalary> CreateBulgariaSalaryAsync(string email, decimal grossSalary)
    //    {
    //        if (!RegexUtilities.IsValidEmail(email))
    //            throw new ArgumentException("Invalid email");

    //        var user = await this.userService.CreateUser(email);

    //        var pensionTax = this.GetPensionTax(grossSalary);
    //        var healthTax = this.GetHealthTax(grossSalary);
    //        var unemploymentTax = this.GetUnemploymentTax(grossSalary);
    //        var commonTax = this.GetCommonTax(grossSalary);
    //        var supplementaryTax = this.GetSupplementaryTax(grossSalary);

    //        var tax = this.GetPensionTax(grossSalary) + this.GetHealthTax(grossSalary) + this.GetUnemploymentTax(grossSalary) + this.GetCommonTax(grossSalary) + this.GetSupplementaryTax(grossSalary);
    //        var personalTax = this.GetPersonalIncomeTax(grossSalary, tax);
    //        var summary = grossSalary - tax + personalTax;

    //        var salary = new BulgarianSalary
    //        {
    //            PersonEmail = email,
    //            GrossSalary = grossSalary,
    //            Pensions = pensionTax,
    //            Tax = tax,
    //            HealthSecurity = healthTax,
    //            Unemployment = unemploymentTax,
    //            Common = commonTax,
    //            Supplementary = supplementaryTax,
    //            PersonalIncomeTax = personalTax,
    //            NetSalary = summary,
    //            UserId = user.Id
    //        };

    //        this.salaryContext.Salaries.Add(salary);
    //        await this.salaryContext.SaveChangesAsync();

    //        return salary;
    //    }
    //    private decimal GetPensionTax(decimal grossSalary)
    //    {
    //        this.validator.IsGrossSalaryInRange(grossSalary);
    //        return grossSalary * ServicesConstants.PensionsInBulgaria;
    //    }

    //    private decimal GetHealthTax(decimal grossSalary)
    //    {
    //        this.validator.IsGrossSalaryInRange(grossSalary);
    //        return grossSalary * ServicesConstants.HealthSecurityInBulgaria;
    //    }

    //    private decimal GetUnemploymentTax(decimal grossSalary)
    //    {
    //        this.validator.IsGrossSalaryInRange(grossSalary);
    //        return grossSalary * ServicesConstants.UnemploymentInBulgaria;
    //    }

    //    private decimal GetSupplementaryTax(decimal grossSalary)
    //    {
    //        this.validator.IsGrossSalaryInRange(grossSalary);
    //        return grossSalary * ServicesConstants.SupplementaryPensionInBulgaria;
    //    }

    //    private decimal GetCommonTax(decimal grossSalary)
    //    {
    //        this.validator.IsGrossSalaryInRange(grossSalary);
    //        return grossSalary * ServicesConstants.CommonDiseasesAndMaternityInBulgaria;
    //    }

    //    private decimal GetPersonalIncomeTax(decimal grossSalary, decimal tax)
    //    {
    //        this.validator.IsGrossSalaryInRange(grossSalary);
    //        return (grossSalary - tax) * ServicesConstants.PersonalIncomeTaxInBulgaria;
    //    }
    //}
}
