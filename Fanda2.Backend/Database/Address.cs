namespace Fanda2.Backend.Database
{
    public class Address
    {
        public int Id { get; set; }
        public string Attention { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string AddressState { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { set; get; }
        public string Fax { set; get; }
        //public AddressType AddressType { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Attention) &&
                string.IsNullOrWhiteSpace(AddressLine1) &&
                string.IsNullOrWhiteSpace(AddressLine2) &&
                string.IsNullOrWhiteSpace(City) &&
                string.IsNullOrWhiteSpace(AddressState) &&
                string.IsNullOrWhiteSpace(Country) &&
                string.IsNullOrWhiteSpace(PostalCode) &&
                string.IsNullOrWhiteSpace(Phone) &&
                string.IsNullOrWhiteSpace(Fax);
        }
    }
}