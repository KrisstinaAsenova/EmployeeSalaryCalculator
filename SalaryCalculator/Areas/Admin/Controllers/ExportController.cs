using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using SalaryCalculator.Data;
using SalaryCalculator.Services.Contracts;
using SalaryCalculator.Web.Models;
using System.Web;
using Microsoft.Azure.Amqp.Framing;

namespace SalaryCalculator.Areas.Admin.Controllers
{
    public class ExportController : Controller
    {
        private readonly ISalaryService salaryService;
        private readonly SalaryCalculatorDbContext context;


        public ExportController(ISalaryService salaryService, SalaryCalculatorDbContext context)
        {
            this.salaryService = salaryService;
            this.context = context;
        }

        //public IActionResult Index()
        //{
        //    var salaryList = this.context
        //        .Salaries
        //        .Select(x => new SalaryViewModel
        //        {
        //            PersonEmail = x.PersonEmail,
        //            GrossSalary = x.GrossSalary,
        //            NetSalary = x.NetSalary
        //        }).ToList();

        //    return View(salaryList);
        //}

        //public void ExportToExcel()
        //{
        //    var salaryList = this.context
        //        .Salaries
        //        .Select(x => new SalaryViewModel
        //        {
        //            PersonEmail = x.PersonEmail,
        //            GrossSalary = x.GrossSalary,
        //            NetSalary = x.NetSalary
        //        }).ToList();

        //    ExcelPackage pack = new ExcelPackage();

        //    ExcelWorksheet ws = pack.Workbook.Worksheets.Add("Report");

        //    ws.Cells["A1"].Value = "Email";
        //    ws.Cells["B1"].Value = "GrossSalary";
        //    ws.Cells["C1"].Value = "NetSalary";

        //    int rowStart = 2;
        //    foreach(var salary in salaryList)
        //    {
        //        ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        //        ws.Cells[string.Format("A{0}", rowStart)].Value = salary.PersonEmail;
        //        ws.Cells[string.Format("B{0}", rowStart)].Value = salary.GrossSalary;
        //        ws.Cells[string.Format("C{0}", rowStart)].Value = salary.NetSalary;
        //        rowStart++;
        //    }

        //    ws.Cells["A:AZ"].AutoFitColumns();
        //    Response.Clear();
        //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    Response.AppendTrailer("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
        //    //Response.BinaryWrite(pack.GetAsByteArray());
        //    //Response.End();
        //}
    }
}
