using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Repositories;

using System;
using System.Diagnostics;

namespace Fanda2.Tests
{
    internal class Program
    {
        private static void Main()
        {
            CreateOrgTest();
        }

        private static void CreateOrgTest()
        {
            var orgRepo = new OrganizationRepository();

            var org = new Organization
            {
                Code = "TESTING",
                OrgName = "Testing Company",
                OrgDesc = "This is a testing company",
                RegdNum = "REGNO-TEST",
                PAN = "PAN-TEST",
                TAN = "TAN-TEST",
                GSTIN = "GSTIN-TEST",
                IsEnabled = true,
                Address = new Address
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
                Contact = new Contact
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
            //orgRepo.UpdateYear(org);
            orgRepo.Create(org);
        }

        private static void GetByIdOrgTest()
        {
            var orgRepo = new OrganizationRepository();
            var orgFetched = orgRepo.GetById(1);
            Console.WriteLine(orgFetched.Code);
        }

        private static void CreateAccountYearTest()
        {
            var yearRepo = new AccountYearRepository();
            var year = new AccountYear
            {
                //YearCode = "2020-21",
                YearBegin = new DateTime(2020, 4, 1),
                YearEnd = new DateTime(2021, 3, 31),
                IsEnabled = true
            };
            yearRepo.Create(1, year);
        }

        private static void SerialNumberTest()
        {
            var serialRepo = new SerialNumberRepository();
            Console.WriteLine(
                serialRepo.NextNumber(1, SerialNumberModule.Receipts, new DateTime(2019, 3, 31))
            );
        }

        private static void IncrementAlphaTest()
        {
            var snRepo = new SerialNumberRepository();
            //Debug.WriteLine("{0} -> {1}", "A", snRepo.IncrementAlpha("A"));
            //Debug.WriteLine("{0} -> {1}", "J", snRepo.IncrementAlpha("J"));
            //Debug.WriteLine("{0} -> {1}", "Z", snRepo.IncrementAlpha("Z"));
            //Debug.WriteLine("{0} -> {1}", "A-A-", snRepo.IncrementAlpha("A-A-"));
            //Debug.WriteLine("{0} -> {1}", "A-J-", snRepo.IncrementAlpha("A-J-"));
            //Debug.WriteLine("{0} -> {1}", "A-Z-", snRepo.IncrementAlpha("A-Z-"));
            Debug.WriteLine("{0} -> {1}", "Z#Z-", snRepo.IncrementAlpha("Z#Z-"));
            //Debug.WriteLine("{0} -> {1}", "BXN-AN-O", snRepo.IncrementAlpha("BXN-AN-O"));
            //Debug.WriteLine("{0} -> {1}", "BXN-999", snRepo.NextNumber("BXN-", "NNN", "", 999));
            Debug.WriteLine("{0} -> {1}", "AB-999", snRepo.NextNumber("AB-", "NNN", "", 999));
        }
    }
}
