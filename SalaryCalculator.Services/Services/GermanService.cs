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
    //public class GermanService : IGermanyService
    //{
    //    private readonly SalaryCalculatorDbContext salaryContext;
    //    private readonly IUserService userService;
    //    private readonly IValidator validator;

    //    public GermanService(SalaryCalculatorDbContext salaryContext, IUserService userService, IValidator validator)
    //    {
    //        this.salaryContext = salaryContext;
    //        this.userService = userService;
    //        this.validator = validator;
    //    }

        //public async Task<GermanySalary> CreateGermanySalaryAsync(string email, decimal grossSalary)
        //{
        //    //if (!RegexUtilities.IsValidEmail(email))
        //    //    throw new ArgumentException("Invalid email");

        //    var user = await this.userService.CreateUser(email);

        //    var salary = new GermanySalary
        //    {
        //        PersonEmail = email,
        //        GrossSalary = grossSalary,
        //        UserId = user.Id
        //    };

        //    //this.salaryContext.GermanySalaries.Add(salary);
        //    await this.salaryContext.SaveChangesAsync();

        //    return salary;
        //}
        //private decimal GetPensionTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.PensionsInGerman;
        //}

        //private decimal GetHealthTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.HealthInsuranceInGerman;
        //}

        //private decimal GetUnemploymentTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.UnemploymentInGerman;
        //}

        //private decimal GetNursingCareTax(decimal grossSalary)
        //{
        //    this.validator.IsGrossSalaryInRange(grossSalary);
        //    return grossSalary * ServicesConstants.NursingCareInGerman;
        //}

   // }
}
