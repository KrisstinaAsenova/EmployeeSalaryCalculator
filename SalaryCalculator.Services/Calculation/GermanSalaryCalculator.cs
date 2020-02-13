using SalaryCalculator.Services.Utils;

namespace SalaryCalculator.Services.Calculation
{
    internal class GermanSalaryCalculator : SalaryCalculator
    {
        protected override decimal CalculateCommonTax(decimal grossSalary)
        {
            return 0;
        }

        protected override decimal CalculateFederalIncomeTax(decimal grossSalary)
        {
            return 0;
        }

        protected override decimal CalculateHealthTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.HealthInsuranceInGerman;
        }

        protected override decimal CalculateNursingCareTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.NursingCareInGerman;
        }

        protected override decimal CalculatePensionsTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.PensionsInGerman;
        }

        protected override decimal CalculatePersonalIncomeTax(decimal netSalary)
        {
            return 0;

        }

        protected override decimal CalculateSupplementaryTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.SupplementaryContibutionInGerman;
        }

        protected override decimal CalculateUnemploymentTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.UnemploymentInGerman;
        }
    }
}