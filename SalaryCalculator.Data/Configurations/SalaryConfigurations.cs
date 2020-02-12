using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Data.Configurations
{
    internal class SalaryConfigurations : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder
                 .HasKey(s => s.SalaryId);

            builder
                .HasOne<User>(s => s.User)
                .WithMany(user => user.Salaries)
                .HasForeignKey(s => s.UserId);

            //builder
            //   .HasMany<SalaryCategory>(user => user.Categories)
            //   .WithOne(s => s.Salary);
        }
    }
}