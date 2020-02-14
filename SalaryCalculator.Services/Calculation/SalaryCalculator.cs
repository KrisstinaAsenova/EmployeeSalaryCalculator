using SalaryCalculator.Services.Contracts;

namespace SalaryCalculator.Services.Calculation
{
    public abstract class SalaryCalculator : ISalaryCalculator
    {
        public decimal GetNetSalary(decimal grossSalary)
        {
            var totalTax = CalculatePensionsTax(grossSalary)
                + CalculateHealthTax(grossSalary)
                + CalculateUnemploymentTax(grossSalary)
                + CalculateSupplementaryTax(grossSalary)
                + CalculateCommonTax(grossSalary)
                + CalculateNursingCareTax(grossSalary)
                + CalculateFederalIncomeTax(grossSalary);

            var netSalaryBeforeIncomeTax = grossSalary - totalTax;
            var personalIncomeTax = CalculatePersonalIncomeTax(netSalaryBeforeIncomeTax);
            
            return netSalaryBeforeIncomeTax - personalIncomeTax;
        }

        protected abstract decimal CalculatePensionsTax(decimal grossSalary);
        protected abstract decimal CalculateHealthTax(decimal grossSalary);
        protected abstract decimal CalculateUnemploymentTax(decimal grossSalary);
        protected abstract decimal CalculateSupplementaryTax(decimal grossSalary);
        protected abstract decimal CalculateCommonTax(decimal grossSalary);
        protected abstract decimal CalculateNursingCareTax(decimal grossSalary);
        protected abstract decimal CalculatePersonalIncomeTax(decimal netSalary);
        protected abstract decimal CalculateFederalIncomeTax(decimal grossSalary);
    }
}
