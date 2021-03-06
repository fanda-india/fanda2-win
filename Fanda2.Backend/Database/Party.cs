using Fanda2.Backend.Enums;

namespace Fanda2.Backend.Database
{
    public class Party : ISubLedger
    {
        public int Id { get; set; }
        public int LedgerId { get; set; }
        public string RegdNum { get; set; }
        public string PAN { get; set; }
        public string TAN { get; set; }
        public string GSTIN { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
        public decimal CreditLimit { get; set; }
        public int? AddressId { get; set; }    // nullable
        public int? ContactId { get; set; }    // nullable

        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }

        public Party Clone()
        {
            return (Party)MemberwiseClone();
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(RegdNum) &&
                string.IsNullOrWhiteSpace(PAN) &&
                string.IsNullOrWhiteSpace(TAN) &&
                string.IsNullOrWhiteSpace(GSTIN) &&
                CreditLimit == 0.0m;
        }
    }

    //public class PartyAddress
    //{
    //    public Guid PartyId { get; set; }
    //    public Guid AddressId { get; set; }
    //}

    //public class PartyContact
    //{
    //    public Guid PartyId { get; set; }
    //    public Guid ContactId { get; set; }
    //}
}
