using SalaryCalculator.Services.Utils;

namespace SalaryCalculator.Services.Calculation
{
    class BulgarianSalaryCalculator : SalaryCalculator
    {
        protected override decimal CalculateCommonTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.CommonDiseasesAndMaternityInBulgaria;
        }

        protected override decimal CalculatePensionsTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.PensionsInBulgaria;
        }

        protected override decimal CalculatePersonalIncomeTax(decimal netSalary)
        {
            return netSalary * TaxConstants.PersonalIncomeTaxInBulgaria;
        }

        protected override decimal CalculateSupplementaryTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.SupplementaryPensionInBulgaria;
        }

        protected override decimal CalculateUnemploymentTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.UnemploymentInBulgaria;
        }

        protected override decimal CalculateHealthTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.HealthSecurityInBulgaria;
        }


        protected override decimal CalculateFederalIncomeTax(decimal grossSalary)
        {
            return 0;
        }

        protected override decimal CalculateNursingCareTax(decimal grossSalary)
        {
            return 0;
        }
    }
}