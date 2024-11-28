using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BankSystem
{
    public static class PersistenceManager
    {
        private const string FileName = "extentData.xml";

        public static void SaveAll()
        {
            try
            {
                // Validate data before serialization
                ValidateData();

                using (StreamWriter file = new StreamWriter(FileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<object>), new Type[]
                    {
                        typeof(List<Bank>),
                        typeof(List<Branch>),
                        typeof(List<Customer>),
                        typeof(List<Account>),
                        typeof(List<SavingAccount>),
                        typeof(List<CheckingAccount>),
                        typeof(List<Insurance>),
                        typeof(List<Loan>)
                    });

                    List<object> allExtents = new List<object>
                    {
                        Bank.Banks,
                        Branch.Branches,
                        Customer.Customers,
                        Account.Accounts,
                        Insurance.Insurances,
                        Loan.Loans
                    };

                    serializer.Serialize(file, allExtents);
                }

                Console.WriteLine("Data saved successfully.");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Serialization error: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public static void LoadAll()
        {
            if (!File.Exists(FileName))
            {
                Console.WriteLine("No data file found. Starting fresh.");
                return;
            }

            try
            {
                using (StreamReader file = new StreamReader(FileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<object>), new Type[]
                    {
                        typeof(List<Bank>),
                        typeof(List<Branch>),
                        typeof(List<Customer>),
                        typeof(List<Account>),
                        typeof(List<SavingAccount>),
                        typeof(List<CheckingAccount>),
                        typeof(List<Insurance>),
                        typeof(List<Loan>)
                    });

                    List<object> allExtents = (List<object>)serializer.Deserialize(file);

                    Bank.Banks = allExtents[0] as List<Bank> ?? new List<Bank>();
                    Branch.Branches = allExtents[1] as List<Branch> ?? new List<Branch>();
                    Customer.Customers = allExtents[2] as List<Customer> ?? new List<Customer>();
                    Account.Accounts = allExtents[3] as List<Account> ?? new List<Account>();
                    Insurance.Insurances = allExtents[4] as List<Insurance> ?? new List<Insurance>();
                    Loan.Loans = allExtents[5] as List<Loan> ?? new List<Loan>();

                    Console.WriteLine("Data loaded successfully.");
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                if (ex.InnerException != null)
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }

        private static void ValidateData()
        {
            // Validate Banks
            foreach (var bank in Bank.Banks)
            {
                if (string.IsNullOrEmpty(bank.Name) || string.IsNullOrEmpty(bank.Location))
                {
                    throw new InvalidOperationException("Invalid bank data: Name or Location is missing.");
                }
            }

            // Validate Branches
            foreach (var branch in Branch.Branches)
            {
                if (string.IsNullOrEmpty(branch.City) || branch.BranchCode <= 0)
                {
                    throw new InvalidOperationException("Invalid branch data: City or BranchCode is missing or invalid.");
                }
            }

            // Validate Customers
            foreach (var customer in Customer.Customers)
            {
                if (string.IsNullOrEmpty(customer.Name) || string.IsNullOrEmpty(customer.Address))
                {
                    throw new InvalidOperationException($"Invalid customer data: Name or Address is missing for customer.");
                }

                if (customer.Accounts == null)
                {
                    customer.Accounts = new List<Account>();
                    Console.WriteLine($"Warning: Customer {customer.Name} had a null Accounts list. Initialized to an empty list.");
                }

                foreach (var account in customer.Accounts)
                {
                    if (account == null)
                        throw new InvalidOperationException($"Customer {customer.Name} has a null account.");
                }
            }

            // Validate Accounts
            foreach (var account in Account.Accounts)
            {
                if (account.AccountNumber <= 0)
                {
                    throw new InvalidOperationException($"Invalid account data: AccountNumber {account.AccountNumber} is invalid.");
                }
            }

            // Validate Insurances
            foreach (var insurance in Insurance.Insurances)
            {
                if (string.IsNullOrEmpty(insurance.Provider) || insurance.CoverageLimits <= 0)
                {
                    throw new InvalidOperationException("Invalid insurance data: Provider or CoverageLimits is missing or invalid.");
                }
            }

            // Validate Loans
            foreach (var loan in Loan.Loans)
            {
                if (string.IsNullOrEmpty(loan.LoanType) || loan.Amount <= 0 || loan.LoanNumber <= 0)
                {
                    throw new InvalidOperationException("Invalid loan data: LoanType, Amount, or LoanNumber is missing or invalid.");
                }
            }
        }
    }
}
