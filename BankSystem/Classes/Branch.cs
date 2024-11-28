using System;
using System.Collections.Generic;

namespace BankSystem
{
    public class Branch
    {
        private int _branchCode;
        private string _city;

        public int BranchCode
        {
            get => _branchCode;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("BranchCode must be positive.");
                _branchCode = value;
            }
        }

        public string City
        {
            get => _city;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("City cannot be empty.");
                _city = value;
            }
        }

        public static List<Branch> Branches { get; set; } = new List<Branch>();

        public Branch(int branchCode, string city)
        {
            BranchCode = branchCode;
            City = city;
            Branches.Add(this);
        }

        public Branch() { }
    }
}
