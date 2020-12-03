namespace Fanda2.Backend.Database
{
    public class Buyer
    {
        public int Id { get; set; }
        public int? ContactId { get; set; }   // nullable
        public int? AddressId { get; set; }   // nullable
    }
}