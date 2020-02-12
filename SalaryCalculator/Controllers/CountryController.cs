﻿using System;
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
        private readonly ISalaryService salaryService;

        public CountryController(ISalaryService salaryService)
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(SalaryViewModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(model);
        //        }
        //        await this.salaryService.CreateSalaryAsync(model.PersonEmail, model.GrossSalary);
        //        Log.Information($"User with email: {model.PersonEmail} convert gross salary: {model.GrossSalary}");
        //        return View(model);
        //    }
        //    catch
        //    {
        //        Log.Error($"User with email: {model.PersonEmail} wasn't converted!");
        //        return RedirectToAction("Index", "Home");
        //    }
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<decimal> CreateAsync(SalaryViewModel model)
        {

            var salary = await this.salaryService.CreateSalaryAsync(model.PersonEmail, model.GrossSalary);
            Log.Information($"User with email: {model.PersonEmail} convert gross salary: {model.GrossSalary}");
            return Math.Round(salary.NetSalary, 2);
        }

    }
}