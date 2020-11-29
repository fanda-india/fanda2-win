using System;

namespace Fanda2.Backend.Database
{
    public class Bank
    {
        public Guid LedgerId { get; set; }
        public string AccountNumber { get; set; }
        public BankAccountType AccountType { get; set; }
        public string IfscCode { get; set; }
        public string MicrCode { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? ContactId { get; set; }
        public bool IsDefault { get; set; }
    }
}