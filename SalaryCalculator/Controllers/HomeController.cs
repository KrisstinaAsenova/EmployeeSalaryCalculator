using System.Drawing;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SalaryCalculator.Data;
using SalaryCalculator.Web.Models;

namespace SalaryCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly SalaryCalculatorDbContext context;

        public HomeController(SalaryCalculatorDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var salaryList = this.context
                .Salaries
                .Select(x => new SalaryViewModel
                {
                    Country = x.Country,
                    DateCheck = x.DateCheck,
                    PersonEmail = x.PersonEmail,
                    GrossSalary = x.GrossSalary,
                    Tax = x.Tax,
                    NetSalary = x.NetSalary
                }).ToList();

            return View(salaryList);
        }
    }
}
