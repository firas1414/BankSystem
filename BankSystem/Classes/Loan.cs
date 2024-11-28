using System;
using System.Collections.Generic;

namespace BankSystem
{
    public class Loan
    {
        private int _loanNumber;

        public int LoanNumber
        {
            get => _loanNumber;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("LoanNumber must be positive.");
                _loanNumber = value;
            }
        }

        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string LoanType { get; set; }
        public double InterestLoanRate { get; set; }

        public static List<Loan> Loans { get; set; } = new List<Loan>();

        public Loan(int loanNumber, double amount, DateTime date, string loanType, double interestLoanRate)
        {
            LoanNumber = loanNumber;
            Amount = amount;
            Date = date;
            LoanType = loanType;
            InterestLoanRate = interestLoanRate;
            Loans.Add(this);
        }

        public Loan() { }
    }
}
