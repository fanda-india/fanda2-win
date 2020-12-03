namespace Fanda2.Backend.Database
{
    public class Bank
    {
        public int LedgerId { get; set; }
        public string AccountNumber { get; set; }
        public BankAccountType AccountType { get; set; }
        public string IfscCode { get; set; }
        public string MicrCode { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public int AddressId { get; set; }   // nullable
        public int ContactId { get; set; }   // nullable
        public bool IsDefault { get; set; }

        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(AccountNumber) &&
                string.IsNullOrWhiteSpace(IfscCode) &&
                string.IsNullOrWhiteSpace(MicrCode) &&
                string.IsNullOrWhiteSpace(BranchCode) &&
                string.IsNullOrWhiteSpace(BranchName);
        }
    }
}