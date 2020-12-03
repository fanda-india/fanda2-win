using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fanda2.Tests
{
    internal class Program
    {
        private static void Main()
        {
            Backend.Repositories.OrganizationRepository orgRepo = new Backend.Repositories.OrganizationRepository();

            Backend.Database.Organization org = new Backend.Database.Organization
            {
                Code = "TESTING",
                OrgName = "Testing Company",
                OrgDesc = "This is a testing company",
                RegdNum = "REGNO-TEST",
                PAN = "PAN-TEST",
                TAN = "TAN-TEST",
                GSTIN = "GSTIN-TEST",
                IsEnabled = true,
                Address = new Backend.Database.Address
                {
                    Attention = "Attn Test",
                    AddressLine1 = "Test address line 1",
                    AddressLine2 = "Test address line 2",
                    City = "Test City",
                    AddressState = "Test State",
                    Country = "Test Country",
                    PostalCode = "TEST-PIN",
                    Phone = "TEST-PHONE",
                    Fax = "TEST-FAX"
                },
                Contact = new Backend.Database.Contact
                {
                    Salutation = "Mr.",
                    FirstName = "TestFirst",
                    LastName = "TestLast",
                    Designation = "Test Designation",
                    Department = "Test Department",
                    Email = "test@email.com",
                    WorkPhone = "TEST-WORK-PHONE",
                    MobileNumber = "TEST-MOBILE-NUMBER"
                }
            };
            orgRepo.Create(org);

            var orgFetched = orgRepo.GetById(1);
        }
    }
}
