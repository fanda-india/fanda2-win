using Dapper;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class OrganizationRepository : IRepository<Organization, OrganizationListModel>
    {
        private readonly DbConnection _connection;

        public OrganizationRepository()
        {
            _connection = new DbConnection();
        }

        public List<OrganizationListModel> GetAll(string searchTerm = null)
        {
            string qry = "SELECT id, code, org_name, org_desc, is_enabled " +
                "FROM organizations";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                qry += $" WHERE code LIKE '%{searchTerm}%' OR " +
                    $"org_name LIKE '%{searchTerm}%' OR " +
                    $"org_desc LIKE '%{searchTerm}%'";
            }

            using (var con = _connection.GetConnection())
            {
                return con.Query<OrganizationListModel>(qry)
                    .ToList();
            }
        }

        public Organization GetById(string id)
        {
            string qry = "SELECT * " +
                 "FROM organizations o " +
                 "LEFT JOIN addresses a ON o.address_id=a.id " +
                 "LEFT JOIN contacts c ON o.contact_id=c.id " +
                 "WHERE o.id=@id";

            using (var con = _connection.GetConnection())
            {
                var result = con.Query<Organization, Address, Contact, Organization>(qry,
                    (org, addr, contact) =>
                    {
                        org.Address = addr; org.Contact = contact; return org;
                    },
                    new { id }, splitOn: "id")
                    .FirstOrDefault();
                return result;
            }
        }

        public Organization Create(Organization org)
        {
            org.Id = Guid.NewGuid().ToString();
            org.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            using (var con = _connection.GetConnection())
            {
                string sql = "INSERT INTO organizations (id, code, org_name, org_desc, " +
                    "regd_num, org_pan, org_tan, gstin, is_enabled, created_at) " +
                    $"VALUES (@id, @code, @orgName, @orgDesc, " +
                    "@regdNum, @pan, @tan, @gstin, @isEnabled, " +
                    $"'{}')";
                con.Execute(sql, org);
            }
            return org;
        }

        public bool Update(string id, Organization org)
        {
            if (id != org.Id)
            {
                return false;
            }

            using (var con = _connection.GetConnection())
            {
                string sql = "UPDATE organizations SET code=@code, org_name=@orgName, " +
                    "org_desc=@orgDesc, regd_num=@regdNum, org_pan=@pan, " +
                    "org_tan=@tan, gstin=@gstin, is_enabled=@isEnabled, " +
                    $"updated_at='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'" +
                    "WHERE id=@id";
                int rows = con.Execute(sql, org);
                return rows == 1;
            }
        }

        public bool Remove(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                using (var con = _connection.GetConnection())
                {
                    string sql = "DELETE FROM organizations WHERE id=@id";
                    int rows = con.Execute(sql, new { id });
                    return rows == 1;
                }
            }
            return false;
        }
    }
}