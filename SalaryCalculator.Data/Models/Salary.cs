﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalaryCalculator.Data.Models
{
    public class Salary
    {
        public Guid SalaryId { get; set; }

        [Required]
        [EmailAddress]
        public string PersonEmail { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GrossSalary { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSalary { get; set; }

        [Required]
        public DateTime DateCheck { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
