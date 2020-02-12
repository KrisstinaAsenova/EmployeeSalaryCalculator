using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryCalculator.Services.Utils
{
    public static class ServicesConstants
    {
        public const decimal PensionsInBulgaria = 0.0658M;
        public const decimal HealthSecurityInBulgaria = 0.032M;
        public const decimal UnemploymentInBulgaria = 0.004M;
        public const decimal SupplementaryPensionInBulgaria = 0.022M;
        public const decimal CommonDiseasesAndMaternityInBulgaria = 0.014M;
        public const decimal PersonalIncomeTaxInBulgaria = 0.1M;

        public const decimal PensionsInGerman = 0.0935M;
        public const decimal HealthInsuranceInGerman = 0.073M;
        public const decimal UnemploymentInGerman = 0.015M;
        public const decimal NursingCareInGerman = 0.01175M;
        public const decimal SupplementaryContibutionInGerman = 0.011M;

        public const decimal SocialSecurityInUSA = 0.062M; // PENSION
        public const decimal HealthInsuranceInUSA = 0.0145M;
    }
}
