using System;

namespace BankSystem
{
    public class SavingAccount : Account
    {
        public double InterestRate { get; set; }
        public static readonly double MinimumBalance = 1000;

        public SavingAccount(int accountNumber, DateTime openingDate, double interestRate)
            : base(accountNumber, openingDate)
        {
            InterestRate = interestRate;
        }

        public SavingAccount() { }
    }
}
