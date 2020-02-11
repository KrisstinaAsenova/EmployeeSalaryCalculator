using SalaryCalculator.Data;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalaryCalculator.Services.Services
{
	public class ExportService : IExportService
	{
		private readonly SalaryCalculatorDbContext salaryContext;
		public ExportService(SalaryCalculatorDbContext salaryContext)
		{
			this.salaryContext = salaryContext;
		}

		//public void ExportSheet()
		//{
		//	//Create an instance of ExcelEngine
		//	using (ExcelEngine excelEngine = new ExcelEngine())
		//	{
		//		IApplication application = excelEngine.Excel;

		//		application.DefaultVersion = ExcelVersion.Excel2016;

		//		//Create a workbook
		//		IWorkbook workbook = application.Workbooks.Create(1);
		//		IWorksheet worksheet = workbook.Worksheets[0];


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

		//		//return fileStreamResult;
		//	}
		//}

	}
}
