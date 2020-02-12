using System.Drawing;
using System.Linq;
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
                    DateCheck = x.DateCheck,
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
                    DateCheck = x.DateCheck,
                    PersonEmail = x.PersonEmail,
                    GrossSalary = x.GrossSalary,
                    NetSalary = x.NetSalary
                }).ToList();

            ExcelPackage pack = new ExcelPackage();

            ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Email";
            ws.Cells["B1"].Value = "GrossSalary";
            ws.Cells["C1"].Value = "NetSalary";
            ws.Cells["D1"].Value = "Date";
            
            int rowStart = 2;
            foreach (var salary in salaryList)
            {
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[string.Format("A{0}", rowStart)].Value = salary.PersonEmail;
                ws.Cells[string.Format("B{0}", rowStart)].Value = salary.GrossSalary;
                ws.Cells[string.Format("C{0}", rowStart)].Value = salary.NetSalary;
                ws.Cells[string.Format("D{0}", rowStart)].Value = salary.DateCheck.ToString();
                ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                rowStart++;
            }

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.Body.Write(pack.GetAsByteArray());
            Response.Body.Close();
        }

    }
}
