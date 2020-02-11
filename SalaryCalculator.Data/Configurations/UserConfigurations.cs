using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Data.Configurations
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(user => user.Id);

            builder
                 .HasMany<BulgarianSalary>(user => user.Salaries)
                 .WithOne(s => s.User);
        }
    }
}
