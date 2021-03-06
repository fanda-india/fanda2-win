﻿using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Helpers;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Fanda2.Backend.Repositories
{
    public class OrganizationRepository : IRootRepository<Organization, OrganizationListModel>
    {
        private readonly SQLiteDB _db;
        private readonly AddressRepository _addressRepository;
        private readonly ContactRepository _contactRepository;
        private readonly AccountYearRepository _yearRepository;
        private readonly LedgerGroupRepository _ledgerGroupRepository;

        public OrganizationRepository()
        {
            _db = new SQLiteDB();
            _addressRepository = new AddressRepository();
            _contactRepository = new ContactRepository();
            _yearRepository = new AccountYearRepository();
            _ledgerGroupRepository = new LedgerGroupRepository();

            //DommelMapper.LogReceived = (qry) =>
            //{
            //    System.Diagnostics.Debug.WriteLine("LOG: " + qry);
            //};
        }

        public List<OrganizationListModel> GetAll(bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                Expression<Func<OrganizationListModel, bool>> filterDisabled;
                if (includeDisabled)
                {
                    filterDisabled = (o) => true;
                }
                else
                {
                    filterDisabled = (o) => o.IsEnabled == true;
                }

                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.Select(filterDisabled)
                        .ToList();
                }
                else
                {
                    Expression<Func<OrganizationListModel, bool>> filterSearchTerm = (o) =>
                        o.Code.Contains(searchTerm) ||
                        o.OrgName.Contains(searchTerm) ||
                        o.OrgDesc.Contains(searchTerm);

                    var expr = DbHelper.AndAlso(filterDisabled, filterSearchTerm);
                    return con.Select(expr)
                        .ToList();
                }
            }
        }

        public Organization GetById(int id)
        {
            using (var con = _db.GetConnection())
            {
                Organization org = con.Get<Organization, Address, Contact, Organization>(id);
                AccountYear year = _yearRepository.GetById(org.ActiveYearId);
                org.Year = year;
                return org;
            }
        }

        //private AccountYear GetYearById(int orgId, int yearId = 0)
        //{
        //    AccountYear year = null;
        //    if (yearId > 0)
        //        year = _yearRepository.GetById(yearId);

        //    if (year == null)
        //        year = new AccountYear { OrgId = org.Id };
        //    org.Year = year;
        //    return org;
        //}

        public int Add(Organization org)
        {
            org.CreatedAt = DateTime.Now;
            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    int? addressId = _addressRepository.Save(org.Address, con, tran);
                    int? contactId = _contactRepository.Save(org.Contact, con, tran);
                    org.AddressId = addressId;
                    org.ContactId = contactId;
                    int orgId = Convert.ToInt32(con.Insert(org, tran));
                    org.Id = orgId;

                    // Accounting Year
                    int yearId = _yearRepository.Add(orgId, org.Year, con, tran);
                    UpdateActiveYearId(orgId, yearId, con, tran);

                    // Seed: Org
                    SeedOrg(orgId, con, tran);
                    // Seed : Year
                    SeedYearSerialNumbers(yearId, con, tran);

                    tran.Commit();
                    return orgId;
                }
            }
        }

        public bool Update(int orgId, Organization org)
        {
            if (orgId <= 0 || orgId != org.Id)
            {
                return false;
            }

            org.UpdatedAt = DateTime.Now;
            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    int? addressId = _addressRepository.Save(org.Address, con, tran);
                    int? contactId = _contactRepository.Save(org.Contact, con, tran);
                    org.AddressId = addressId;
                    org.ContactId = contactId;
                    bool success = con.Update(org, tran);
                    // Accounting Year
                    _yearRepository.Update(orgId, org.Year, con, tran);
                    tran.Commit();
                    return success;
                }
            }
        }

        public bool Remove(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                Organization org = con.Get<Organization>(id);
                if (org == null)
                {
                    return false;
                }

                using (var tran = con.BeginTransaction())
                {
                    _addressRepository.Remove(org.AddressId, con, tran);
                    _contactRepository.Remove(org.ContactId, con, tran);
                    bool success = con.Delete(org, tran);
                    tran.Commit();
                    return success;
                }
            }
        }

        public bool Exists(KeyField keyField, string fieldValue, int id)
        {
            bool exists = true;
            using (var con = _db.GetConnection())
            {
                switch (keyField)
                {
                    case KeyField.Code:
                        exists = con.Any<Organization>(o => o.Id != id && o.Code == fieldValue);
                        //exists = con.ExecuteScalar<int>("select 1 from organizations where code like @code and id<>@id",
                        //    new { code = fieldValue, id }) == 1;
                        break;

                    case KeyField.Name:
                        exists = con.Any<Organization>(o => o.Id != id && o.OrgName == fieldValue);
                        //int res = con.ExecuteScalar<int>("select 1 from organizations where org_name like @name and id<>@id",
                        //    new { name = fieldValue, id });
                        //exists = res == 1;
                        break;
                }
            }
            return exists;
        }

        public bool UpdateActiveYearId(int orgId, int yearId, IDbConnection con, IDbTransaction tran)
        {
            if (orgId <= 0 || yearId <= 0)
            {
                return false;
            }

            //using (var con = _db.GetConnection())
            //{
            int rows = con.Execute("UPDATE organizations SET active_year_id=@yearId WHERE id=@orgId",
                new { orgId, yearId }, tran);

            return rows == 1;
            //}
        }

        #region Seed

        private void SeedOrg(int orgId, IDbConnection con, IDbTransaction tran)
        {
            SeedOrgLedgers(orgId, con, tran);
            SeedOrgUnits(orgId, con, tran);
            SeedOrgProductCategories(orgId, con, tran);
        }

        private void SeedOrgProductCategories(int orgId, IDbConnection con, IDbTransaction tran)
        {
            var productCategoryRepo = new ProductCategoryRepository();
            productCategoryRepo.Add(orgId, new ProductCategory
            {
                Code = "DEFAULT",
                CategoryName = "Default",
                CategoryDesc = "Default product category",
                ParentId = null,
                IsEnabled = true
            }, con, tran);
        }

        private void SeedOrgUnits(int orgId, IDbConnection con, IDbTransaction tran)
        {
            var unitRepo = new UnitRepository();
            unitRepo.Add(orgId, new Unit
            {
                Code = "EACH",
                UnitName = "Each",
                UnitDesc = "Default unit",
                IsEnabled = true
            }, con, tran);
        }

        private void SeedYearSerialNumbers(int yearId, IDbConnection con, IDbTransaction tran)
        {
            var serialRepo = new SerialNumberRepository();
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.Receipts,
                SerialPrefix = "R",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.Payments,
                SerialPrefix = "Y",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.Deposits,
                SerialPrefix = "D",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.Withdrawls,
                SerialPrefix = "W",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.Journals,
                SerialPrefix = "J",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.Purchase,
                SerialPrefix = "P",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.Sales,
                SerialPrefix = "S",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.DebitNote,
                SerialPrefix = "B",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.CreditNote,
                SerialPrefix = "C",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.Stock,
                SerialPrefix = "O",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.RawMaterial,
                SerialPrefix = "M",
                SerialFormat = "YY-9999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
            serialRepo.Add(yearId, new SerialNumber
            {
                SerialModule = Enums.SerialNumberModule.TagNumber,
                SerialPrefix = "AA-",
                SerialFormat = "99999",
                SerialSuffix = null,
                SerialReset = Enums.SerialNumberReset.Max
            }, con, tran);
        }

        private void SeedOrgLedgers(int orgId, IDbConnection con, IDbTransaction tran)
        {
            var ledgerRepo = new LedgerRepository();

            // Ledgers
            ledgerRepo.Add(orgId, new Ledger
            {
                Code = "CASH",
                LedgerName = "Cash on hand",
                LedgerDesc = "Default cash account",
                LedgerGroupId = GetGroupId("CASH"),
                LedgerType = Enums.LedgerType.Default,
                IsSystem = true,
                IsEnabled = true
            }, con, tran);
            ledgerRepo.Add(orgId, new Ledger
            {
                Code = "PURCHASE",
                LedgerName = "Purchase",
                LedgerDesc = "Default purchase account",
                LedgerGroupId = GetGroupId("PURCHASE"),
                LedgerType = Enums.LedgerType.Default,
                IsSystem = true,
                IsEnabled = true
            }, con, tran);
            ledgerRepo.Add(orgId, new Ledger
            {
                Code = "SALES",
                LedgerName = "Sales",
                LedgerDesc = "Default sales account",
                LedgerGroupId = GetGroupId("SALES"),
                LedgerType = Enums.LedgerType.Default,
                IsSystem = true,
                IsEnabled = true
            }, con, tran);
            ledgerRepo.Add(orgId, new Ledger
            {
                Code = "DEBITNOTE",
                LedgerName = "Debit Note",
                LedgerDesc = "Default debit note account",
                LedgerGroupId = GetGroupId("PURCHASE"),
                LedgerType = Enums.LedgerType.Default,
                IsSystem = true,
                IsEnabled = true
            }, con, tran);
            ledgerRepo.Add(orgId, new Ledger
            {
                Code = "CREDITNOTE",
                LedgerName = "Credit Note",
                LedgerDesc = "Default credit note account",
                LedgerGroupId = GetGroupId("SALES"),
                LedgerType = Enums.LedgerType.Default,
                IsSystem = true,
                IsEnabled = true
            }, con, tran);
            ledgerRepo.Add(orgId, new Ledger
            {
                Code = "STOCK",
                LedgerName = "Stock on hand",
                LedgerDesc = "Default stock account",
                LedgerGroupId = GetGroupId("STOCK"),
                LedgerType = Enums.LedgerType.Default,
                IsSystem = true,
                IsEnabled = true
            }, con, tran);
        }

        private int GetGroupId(string groupCode)
        {
            var group = _ledgerGroupRepository.GetByCode(groupCode);
            if (group == null)
            {
                return 0;
            }
            else
            {
                return group.Id;
            }
        }

        #endregion Seed
    }
}
