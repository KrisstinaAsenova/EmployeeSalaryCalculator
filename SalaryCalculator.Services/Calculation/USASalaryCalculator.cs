using SalaryCalculator.Services.Utils;

namespace SalaryCalculator.Services.Calculation
{
    internal class USASalaryCalculator : SalaryCalculator
    {
        protected override decimal CalculateCommonTax(decimal grossSalary)
        {
            return ServicesConstants.CommonDiseasesAndMaternityInUSA;
        }

        protected override decimal CalculateFederalIncomeTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.FederalIncomeTaxInUSA;   
        }

        protected override decimal CalculateHealthTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.HealthInsuranceInUSA;
        }

        protected override decimal CalculateNursingCareTax(decimal grossSalary)
        {
            return 0;
        }

        protected override decimal CalculatePensionsTax(decimal grossSalary)
        {
            return grossSalary * ServicesConstants.SocialSecurityInUSA;
        }

        protected override decimal CalculatePersonalIncomeTax(decimal salary)
        {
            return 0;
        }

        protected override decimal CalculateSupplementaryTax(decimal grossSalary)
        {
            return 0;
        }

        protected override decimal CalculateUnemploymentTax(decimal grossSalary)
        {
            return 0;
        }
    }
}