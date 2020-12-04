﻿using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Repositories;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fanda2.Tests
{
    internal class Program
    {
        private static void Main()
        {
            IncrementAlphaTest();
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
                YearCode = "2020-21",
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
            Debug.WriteLine("{0} -> {1}", "A", snRepo.IncrementAlpha("A"));
            Debug.WriteLine("{0} -> {1}", "J", snRepo.IncrementAlpha("J"));
            Debug.WriteLine("{0} -> {1}", "Z", snRepo.IncrementAlpha("Z"));
            Debug.WriteLine("{0} -> {1}", "A-A-", snRepo.IncrementAlpha("AA"));
            Debug.WriteLine("{0} -> {1}", "A-J-", snRepo.IncrementAlpha("AJ"));
            Debug.WriteLine("{0} -> {1}", "A-Z-", snRepo.IncrementAlpha("AZ"));
            Debug.WriteLine("{0} -> {1}", "Z-Z-", snRepo.IncrementAlpha("ZZ"));
        }
    }
}
