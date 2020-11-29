using System;

namespace Fanda2.Backend.Database
{
    public class Stock
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }

        // public string PartyTagNumber { get; set; }
        public string TagNumber { get; set; }

        public DateTime? MfgDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public Guid UnitId { get; set; }
        public decimal QtyOnHand { get; set; }
    }
}