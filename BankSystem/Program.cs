using System;
using BankSystem;

class Program
{
    static void Main(string[] args)
    {
        PersistenceManager.LoadAll();

        if (Bank.Banks.Count == 0)
        {
            Bank bank1 = new Bank("Warsaw", "Central Bank");
            Bank bank2 = new Bank("Krakow", "YYY Bank");

            Branch branch1 = new Branch(101, "Downtown");
            Branch branch2 = new Branch(102, "Uptown");

            Customer customer1 = new Customer("Firas", "123 XXXX");
            Customer customer2 = new Customer("Serkan", "456 YYYY");
            Customer customer3 = new Customer("Ivan", "43 YY");

            SavingAccount savingAccount1 = new SavingAccount(1, DateTime.Now, 2.5)
            {
                Income = 10000
            };
            savingAccount1.Expenses.Add(2000);

            CheckingAccount checkingAccount1 = new CheckingAccount(2, DateTime.Now)
            {
                Income = 5000
            };
            checkingAccount1.Expenses.Add(1000);

            customer1.Accounts.Add(savingAccount1);
            customer2.Accounts.Add(checkingAccount1);

            Customer.Customers.Add(customer1);
            Customer.Customers.Add(customer2);
            Customer.Customers.Add(customer3);

            Insurance insurance1 = new Insurance("ABC Insurance", 50000, 300);
            Insurance insurance2 = new Insurance("XYZ Insurance", 100000, 500);

            Loan loan1 = new Loan(1, 50000, DateTime.Now, "Home Loan", 3.5);
            Loan loan2 = new Loan(2, 20000, DateTime.Now, "Car Loan", 4.0);
        }

        DisplayData();
        PersistenceManager.SaveAll();

        Console.WriteLine("\nProgram execution complete. Press any key to exit.");
        Console.ReadKey();
    }

    static void DisplayData()
    {
        Console.WriteLine("\nBanks:");
        foreach (var bank in Bank.Banks)
        {
            Console.WriteLine($" - {bank.Name}, Location: {bank.Location}");
        }

        Console.WriteLine("\nBranches:");
        foreach (var branch in Branch.Branches)
        {
            Console.WriteLine($" - Branch Code: {branch.BranchCode}, City: {branch.City}");
        }

        Console.WriteLine("\nCustomers:");
        foreach (var customer in Customer.Customers)
        {
            Console.WriteLine($" - {customer.Name}, Address: {customer.Address}");
            foreach (var account in customer.Accounts)
            {
                if (account is SavingAccount savingAccount)
                {
                    Console.WriteLine($"   * Saving Account: {savingAccount.AccountNumber}, Balance: {savingAccount.Balance}, Interest Rate: {savingAccount.InterestRate}%");
                }
                else if (account is CheckingAccount checkingAccount)
                {
                    Console.WriteLine($"   * Checking Account: {checkingAccount.AccountNumber}, Balance: {checkingAccount.Balance}, Monthly Fee: {checkingAccount.MonthlyFee}");
                }
            }
        }

        Console.WriteLine("\nInsurances:");
        foreach (var insurance in Insurance.Insurances)
        {
            Console.WriteLine($" - Provider: {insurance.Provider}, Coverage: {insurance.CoverageLimits}, Monthly Payment: {insurance.MonthlyPayment}");
        }

        Console.WriteLine("\nLoans:");
        foreach (var loan in Loan.Loans)
        {
            Console.WriteLine($" - Loan Type: {loan.LoanType}, Amount: {loan.Amount}, Interest Rate: {loan.InterestLoanRate}%, Loan Number: {loan.LoanNumber}");
        }
    }
}
