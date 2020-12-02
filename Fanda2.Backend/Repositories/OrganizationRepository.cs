using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class OrganizationRepository : IRepository<Organization, OrganizationListModel>
    {
        private readonly SQLiteDB _db;
        private readonly AddressRepository _addressRepository;
        private readonly ContactRepository _contactRepository;

        public OrganizationRepository()
        {
            _db = new SQLiteDB();
            _addressRepository = new AddressRepository();
            _contactRepository = new ContactRepository();
        }

        public List<OrganizationListModel> GetAll(string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.GetAll<OrganizationListModel>()
                        .ToList();
                }
                else
                {
                    return con.Select<OrganizationListModel>(o =>
                         o.Code.Contains(searchTerm) ||
                         o.OrgName.Contains(searchTerm) ||
                         o.OrgDesc.Contains(searchTerm)
                    ).ToList();
                }
            }
        }

        public Organization GetById(string id)
        {
            using (var con = _db.GetConnection())
            {
                return con.Get<Organization, Address, Contact, Organization>(id);
            }
        }

        public string Create(Organization entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            entity.CreatedAt = DateTime.Now;   //.ToString("yyyy-MM-dd HH:mm:ss");
            //string sql =
            //    "INSERT INTO organizations " +
            //    "(id, code, org_name, org_desc, regd_num, org_pan, org_tan, gstin, is_enabled, created_at) " +
            //    "VALUES " +
            //    $"(@id, @code, @orgName, @orgDesc, @regdNum, @pan, @tan, @gstin, @isEnabled, @createdAt)";
            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    string addressId = _addressRepository.Save(entity.Address, con, tran);
                    string contactId = _contactRepository.Save(entity.Contact, con, tran);
                    con.Insert(entity, tran); //con.Execute(sql, entity);

                    tran.Commit();
                    return entity.Id;
                }
            }
        }

        public bool Update(string id, Organization entity)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 36 || id != entity.Id)
            {
                return false;
            }

            entity.UpdatedAt = DateTime.Now;     //.ToString("yyyy-MM-dd HH:mm:ss")
            //string sql =
            //    "UPDATE organizations SET code=@code, org_name=@orgName, " +
            //    "org_desc=@orgDesc, regd_num=@regdNum, org_pan=@pan, " +
            //    "org_tan=@tan, gstin=@gstin, is_enabled=@isEnabled, " +
            //    $"updated_at=@updatedAt " +
            //    "WHERE id=@id";
            using (var con = _db.GetConnection())
            {
                using (var tran = con.BeginTransaction())
                {
                    string addressId = _addressRepository.Save(entity.Address, con, tran);
                    string contactId = _contactRepository.Save(entity.Contact, con, tran);
                    bool success = con.Update(entity, tran); //con.Execute(sql, entity);
                    tran.Commit();
                    return success;
                }
            }
        }

        public bool Remove(string id)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 36)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                Organization org = con.Get<Organization>(id);
                if (org == null)
                    return false;

                using (var tran = con.BeginTransaction())
                {
                    _addressRepository.Remove(org.AddressId, con, tran);
                    _contactRepository.Remove(org.ContactId, con, tran);
                    bool success = con.Delete(org, tran);
                    //int rows = con.Execute("DELETE FROM organizations WHERE id=@id", new { id }, tran);
                    tran.Commit();
                    return success;
                    //return rows == 1;
                }
            }
        }
    }
}
