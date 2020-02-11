using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalaryCalculator.Services.Contracts;

namespace SalaryCalculator.Web.Controllers
{
    public class ExportController : Controller
    {
        private readonly IBulgariaSalaryService salaryService;

        public ExportController(IBulgariaSalaryService salaryService)
        {
            this.salaryService = salaryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> CreateDocument()
        //{
        //	//Create an instance of ExcelEngine
        //	using (ExcelEngine excelEngine = new ExcelEngine())
        //	{
        //		IApplication application = excelEngine.Excel;

        //		application.DefaultVersion = ExcelVersion.Excel2016;

        //		//Create a workbook
        //		IWorkbook workbook = application.Workbooks.Create(1);
        //		IWorksheet worksheet = workbook.Worksheets[0];

        //		//Adding a picture
        //		//FileStream imageStream = new FileStream("AdventureCycles-Logo.png", FileMode.Open, FileAccess.Read);
        //		//IPictureShape shape = worksheet.Pictures.AddPicture(1, 1, imageStream);

        //		//Disable gridlines in the worksheet
        //		worksheet.IsGridLinesVisible = false;

        //		//Saving the Excel to the MemoryStream 
        //		MemoryStream stream = new MemoryStream();

        //		workbook.SaveAs(stream);

        //		//Set the position as '0'.
        //		stream.Position = 0;

        //		//Download the Excel file in the browser
        //		FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/excel");

        //		fileStreamResult.FileDownloadName = "Output.xlsx";

        //		return fileStreamResult;
        //	}
    }
}
