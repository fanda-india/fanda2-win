using System;

namespace Fanda2.Backend.Database
{
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        // public string PartyTagNumber { get; set; }
        public string TagNumber { get; set; }

        public DateTime? MfgDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int UnitId { get; set; }
        public decimal QtyOnHand { get; set; }

        public Inventory Clone()
        {
            return (Inventory)MemberwiseClone();
        }
    }
}
