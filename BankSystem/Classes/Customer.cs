using System;
using System.Collections.Generic;

namespace BankSystem
{
    public class Customer
    {
        private string _name;
        private string _address;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value;
            }
        }

        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Address cannot be empty.");
                _address = value;
            }
        }

        public List<Account> Accounts { get; set; } = new List<Account>();

        public static List<Customer> Customers { get; set; } = new List<Customer>();

        public Customer(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public Customer() { }
    }
}
