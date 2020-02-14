using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SalaryCalculator.Data;
using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Web.Models;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace SalaryCalculator.Controllers
{
    public class ExportController : Controller
    {
        private readonly SalaryCalculatorDbContext context;
        public ExportController(SalaryCalculatorDbContext context)
        {
            this.context = context;
        }

        [Authorize]
        public void ExportToExcel()
        {
            var salaryList = context
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

            ExcelPackage pack = new ExcelPackage();

            ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "Email";
            ws.Cells["B1"].Value = "GrossSalary";
            ws.Cells["C1"].Value = "NetSalary";
            ws.Cells["D1"].Value = "Date";
            ws.Cells["E1"].Value = "Country";

            int rowStart = 2;
            foreach (var salary in salaryList)
            {
                ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[string.Format("A{0}", rowStart)].Value = salary.PersonEmail;
                ws.Cells[string.Format("B{0}", rowStart)].Value = salary.GrossSalary;
                ws.Cells[string.Format("C{0}", rowStart)].Value = salary.NetSalary;
                ws.Cells[string.Format("D{0}", rowStart)].Value = salary.DateCheck.ToString();
                ws.Cells[string.Format("E{0}", rowStart)].Value = salary.Country;
                ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("yellow")));

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
