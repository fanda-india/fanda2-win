using System;

namespace Fanda2.Backend.Database
{
    public class Stock
    {
        public string Id { get; set; }
        public string ProductId { get; set; }

        // public string PartyTagNumber { get; set; }
        public string TagNumber { get; set; }

        public DateTime? MfgDate { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public string UnitId { get; set; }
        public decimal QtyOnHand { get; set; }
    }
}
