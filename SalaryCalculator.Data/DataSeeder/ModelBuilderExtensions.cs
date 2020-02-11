using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Data.DataSeeder
{
    public static class ModelBuilderExtensions
    {
        public static void UserRoleSeeder(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
              new IdentityRole { Id = "93ad4deb-b9f7-4a98-9585-8b79963aee55", Name = "Admin", NormalizedName = "ADMIN" }
              );

            var hasher = new PasswordHasher<User>();

            User adminUser = new User { Id = "e05be19e-09ef-428c-9bcc-cf5ebdf7c56e", UserName = "admin", NormalizedUserName = "ADMIN", Email = "admin@admin.com", NormalizedEmail = "ADMIN@ADMIN.COM", LockoutEnabled = true, SecurityStamp = "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN" };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin123");

            builder.Entity<User>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(
               new IdentityUserRole<string>
               {
                   RoleId = "93ad4deb-b9f7-4a98-9585-8b79963aee55",
                   UserId = adminUser.Id
               });
        }
    }
}

