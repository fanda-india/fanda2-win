using System;

namespace Fanda2.Backend.Database
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string WorkPhone { get; set; }
        public string MobileNumber { get; set; }
        //public bool IsPrimary { get; set; }
    }
}