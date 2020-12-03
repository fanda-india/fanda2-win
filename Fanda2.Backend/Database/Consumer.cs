namespace Fanda2.Backend.Database
{
    public class Consumer
    {
        public int Id { get; set; }
        public int? ContactId { get; set; }   // nullable
        public int? AddressId { get; set; }   // nullable

        public virtual Contact Contact { get; set; }
        public virtual Address Address { get; set; }
    }
}
