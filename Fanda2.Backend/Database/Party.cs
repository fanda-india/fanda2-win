using System;

namespace Fanda2.Backend.Database
{
    public class Party
    {
        public Guid LedgerId { get; set; }
        public PaymentTerm PaymentTerm { get; set; }
        public decimal CreditLimit { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? ContactId { get; set; }
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