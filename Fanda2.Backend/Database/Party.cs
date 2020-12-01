using System;

namespace Fanda2.Backend.Database
{
    public class Party
    {
        public string LedgerId { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
        public decimal CreditLimit { get; set; }
        public string AddressId { get; set; }    // nullable
        public string ContactId { get; set; }    // nullable

        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
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