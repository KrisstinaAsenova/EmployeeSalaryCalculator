using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalaryCalculator.Web.Models
{
    public class SalaryViewModel
    {
        public DateTime DateCheck { get; set; }
        public string PersonEmail { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal NetSalary { get; set; }
    }
}
