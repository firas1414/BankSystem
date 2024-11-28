using System;

namespace BankSystem
{
    public class CheckingAccount : Account
    {
        public double MonthlyFee { get; set; } = 10;

        public CheckingAccount(int accountNumber, DateTime openingDate)
            : base(accountNumber, openingDate)
        {
        }

        public CheckingAccount() { }
    }
}
