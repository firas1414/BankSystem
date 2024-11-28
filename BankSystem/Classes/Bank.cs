using System;
using System.Collections.Generic;

namespace BankSystem
{
    public class Bank
    {
        private string _location;
        private string _name;

        public string Location
        {
            get => _location;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Location cannot be empty.");
                _location = value;
            }
        }

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

        public static List<Bank> Banks { get; set; } = new List<Bank>();

        public Bank(string location, string name)
        {
            Location = location;
            Name = name;
            Banks.Add(this);
        }

        public Bank() { }
    }
}
