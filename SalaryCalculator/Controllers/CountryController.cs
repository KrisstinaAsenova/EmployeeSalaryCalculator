using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Web.Models;
using Serilog;

namespace SalaryCalculator.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly IBulgariaSalaryService salaryService;

        public CountryController(IBulgariaSalaryService salaryService)
        {
            this.salaryService = salaryService;
        }

        public IActionResult Bulgaria()
        {
            return View();
        }

        public IActionResult Germany()
        {
            return View();
        }

        public IActionResult USA()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalaryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            await this.salaryService.CreateBulgariaSalaryAsync(model.PersonEmail, model.GrossSalary);
            Log.Information("Entered gross salary");
            return RedirectToAction(nameof(Bulgaria));
        }

    }
}