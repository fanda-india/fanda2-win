using System;

namespace Fanda2.Backend.Database
{
    public class Buyer
    {
        public Guid Id { get; set; }
        public Guid? ContactId { get; set; }
        public Guid? AddressId { get; set; }
    }
}