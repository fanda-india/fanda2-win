using System;

namespace Fanda2.Backend.Database
{
    public class Organization
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RegdNum { get; set; }
        public string PAN { get; set; }
        public string TAN { get; set; }
        public string GSTIN { get; set; }
        public Guid? AddressId { get; set; }
        public Guid? ContactId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
    }

    //public class OrgAddress
    //{
    //    public Guid OrgId { get; set; }
    //    public Guid AddressId { get; set; }
    //}

    //public class OrgContact
    //{
    //    public Guid OrgId { get; set; }
    //    public Guid ContactId { get; set; }
    //}
}
