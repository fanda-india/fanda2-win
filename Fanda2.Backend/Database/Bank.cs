using System;

namespace Fanda2.Backend.Database
{
    public class Bank
    {
        public string LedgerId { get; set; }
        public string AccountNumber { get; set; }
        public BankAccountType AccountType { get; set; }
        public string IfscCode { get; set; }
        public string MicrCode { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string AddressId { get; set; }   // nullable
        public string ContactId { get; set; }   // nullable
        public bool IsDefault { get; set; }
    }
}
