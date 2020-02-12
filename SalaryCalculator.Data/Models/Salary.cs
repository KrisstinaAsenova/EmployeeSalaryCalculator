﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SalaryCalculator.Data.Models
{
    public class Salary
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid SalaryId { get; set; }

        [EmailAddress]
        public string PersonEmail { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal GrossSalary { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Tax { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetSalary { get; set; }
        public DateTime DateCheck { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }
    }
}