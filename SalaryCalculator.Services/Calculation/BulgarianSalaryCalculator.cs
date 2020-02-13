using SalaryCalculator.Services.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Services.Calculation
{
    class BulgarianSalaryCalculator : SalaryCalculator
    {
        protected override decimal CalculateCommonTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.CommonDiseasesAndMaternityInBulgaria;
        }

        protected override decimal CalculateFederalIncomeTax(decimal grossSalary)
        {
            return 0;
        }

        protected override decimal CalculateHealthTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.HealthSecurityInBulgaria;
        }

        protected override decimal CalculateNursingCareTax(decimal grossSalary)
        {
            return 0;
        }

        protected override decimal CalculatePensionsTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.PensionsInBulgaria;
        }

        protected override decimal CalculatePersonalIncomeTax(decimal netSalary)
        {
            return netSalary * ServicesConstants.PersonalIncomeTaxInBulgaria;
        }

        protected override decimal CalculateSupplementaryTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.SupplementaryPensionInBulgaria;
        }

        protected override decimal CalculateUnemploymentTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.UnemploymentInBulgaria;
        }
    }
}