using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SalaryCalculator.Data.Models
{
    public class User : IdentityUser
    {
        public ICollection<Salary> Salaries { get; set; } = new HashSet<Salary>();

    }
}
