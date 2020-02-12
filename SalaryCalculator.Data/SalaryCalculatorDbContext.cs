using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Data.Configurations;
using SalaryCalculator.Data.DataSeeder;
using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Data
{
    public class SalaryCalculatorDbContext : IdentityDbContext<User>
    {
        public SalaryCalculatorDbContext(DbContextOptions<SalaryCalculatorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Salary> Salaries { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<User>(new UserConfigurations());
            builder.ApplyConfiguration<Salary>(new SalaryConfigurations());


            builder.UserRoleSeeder();
            base.OnModelCreating(builder);
        }
    }
}
