using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace SalaryCalculator.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<BulgarianSalary> Salaries { get; set; } = new HashSet<BulgarianSalary>();

    }
}
