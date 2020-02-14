using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Web.Models;
using Serilog;

namespace SalaryCalculator.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ISalaryService salaryService;

        public CountryController(ISalaryService salaryService)
        {
            this.salaryService = salaryService;
        }

        public IActionResult Index(string country)
        {
            var model = new SalaryViewModel
            {
                Country = country
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Decimal> CalculateAsync(SalaryViewModel model)
        {
            try
            {
                var salary = await this.salaryService.CalculateSalaryAsync(model.PersonEmail, model.GrossSalary, model.Country);
                Log.Information($"User with email: {model.PersonEmail} convert gross salary: {model.GrossSalary} for country: {model.Country}");
                return Math.Round(salary.NetSalary, 2);
            }
            catch
            {
                Log.Error($"User with email: {model.PersonEmail} wasn't converted!");
                return 0;
            }
        }

    }
}