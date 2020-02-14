using SalaryCalculator.Services.Utils;

namespace SalaryCalculator.Services.Calculation
{
    internal class GermanSalaryCalculator : SalaryCalculator
    {
        protected override decimal CalculateHealthTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.HealthInsuranceInGerman;
        }

        protected override decimal CalculateNursingCareTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.NursingCareInGerman;
        }

        protected override decimal CalculatePensionsTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.PensionsInGerman;
        }

        protected override decimal CalculateSupplementaryTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.SupplementaryContibutionInGerman;
        }

        protected override decimal CalculateUnemploymentTax(decimal grossSalary)
        {
            return grossSalary * TaxConstants.UnemploymentInGerman;
        }

        protected override decimal CalculatePersonalIncomeTax(decimal netSalary)
        {
            return 0;
        }

        protected override decimal CalculateCommonTax(decimal grossSalary)
        {
            return 0;
        }

        protected override decimal CalculateFederalIncomeTax(decimal grossSalary)
        {
            return 0;
        }
    }
}