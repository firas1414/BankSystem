using System;
using System.Collections.Generic;
using System.Linq;

namespace BankSystem
{
    public class Account
    {
        private int _accountNumber;

        public int AccountNumber
        {
            get => _accountNumber;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("AccountNumber must be positive.");
                _accountNumber = value;
            }
        }

        public double Income { get; set; }
        public List<double> Expenses { get; set; } = new List<double>(); // Ensure Expenses is initialized
        public DateTime OpeningDate { get; set; }
        public double Balance => Income - Expenses.Sum();

        public static List<Account> Accounts { get; set; } = new List<Account>();

        public Account(int accountNumber, DateTime openingDate)
        {
            AccountNumber = accountNumber;
            OpeningDate = openingDate;
            Accounts.Add(this);
        }

        public Account() { }
    }
}
