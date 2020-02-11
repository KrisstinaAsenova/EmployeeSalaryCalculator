using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalaryCalculator.Data.Models
{
    public class BulgarianSalary
    {
        public Guid SalaryId { get; set; }

        [EmailAddress]
        public string PersonEmail { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GrossSalary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSalary { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Pensions { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal HealthSecurity { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Unemployment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Supplementary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Common { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PersonalIncomeTax { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        public User User { get; set; }


    }
}
