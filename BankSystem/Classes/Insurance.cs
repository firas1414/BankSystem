using System.Collections.Generic;

namespace BankSystem
{
    public class Insurance
    {
        public string Provider { get; set; }
        public double CoverageLimits { get; set; }
        public double MonthlyPayment { get; set; }

        public static List<Insurance> Insurances { get; set; } = new List<Insurance>();

        public Insurance(string provider, double coverageLimits, double monthlyPayment)
        {
            Provider = provider;
            CoverageLimits = coverageLimits;
            MonthlyPayment = monthlyPayment;
            Insurances.Add(this);
        }

        public Insurance() { }
    }
}
