using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SalaryCalculator.Data;
using SalaryCalculator.Models;
using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Web.Models;

namespace SalaryCalculator.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBulgariaSalaryService salaryService;
        private readonly SalaryCalculatorDbContext context;


        public HomeController(IBulgariaSalaryService salaryService, SalaryCalculatorDbContext context)
        {
            this.salaryService = salaryService;
            this.context = context;
        }
        public IActionResult Index()
        {
            var salaryList = this.context
                .Salaries
                .Select(x => new SalaryViewModel
                {
                    PersonEmail = x.PersonEmail,
                    GrossSalary = x.GrossSalary,
                    NetSalary = x.NetSalary
                }).ToList();

            return View(salaryList);
        }

        public void ExportToExcel()
        {
            var salaryList = this.context
                .Salaries
                .Select(x => new SalaryViewModel
                {
                    PersonEmail = x.PersonEmail,
                    GrossSalary = x.GrossSalary,
                    NetSalary = x.NetSalary
                }).ToList();

            ExcelPackage pack = new ExcelPackage();

            ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Email";
            ws.Cells["B1"].Value = "GrossSalary";
            ws.Cells["C1"].Value = "NetSalary";

            int rowStart = 2;
            foreach (var salary in salaryList)
            {
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[string.Format("A{0}", rowStart)].Value = salary.PersonEmail;
                ws.Cells[string.Format("B{0}", rowStart)].Value = salary.GrossSalary;
                ws.Cells[string.Format("C{0}", rowStart)].Value = salary.NetSalary;
                rowStart++;
            }

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            //Response.BinaryWrite(pack.GetAsByteArray());
            //Response.End();


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
