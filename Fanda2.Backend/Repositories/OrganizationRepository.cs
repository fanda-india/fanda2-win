using Dapper;

using Fanda2.Backend.Database;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class OrganizationRepository
    {
        private readonly DbConnection _connection;

        public OrganizationRepository()
        {
            _connection = new DbConnection();
        }

        public List<Organization> GetAll(string searchTerm = null)
        {
            string qry = "SELECT id, code AS Code, org_name AS OrgName, org_desc AS OrgDesc " +
                "FROM organizations";

            if (!string.IsNullOrEmpty(searchTerm))
            {
                qry += $" WHERE code LIKE '%{searchTerm}%' OR " +
                    $"org_name LIKE '%{searchTerm}%' OR " +
                    $"org_desc LIKE '%{searchTerm}%'";
            }

            using (var con = _connection.GetConnection())
            {
                return con.Query<Organization>(qry)
                    .ToList();
            }
        }

        public Organization GetById(string id)
        {
            string qry = "SELECT o.id, o.code AS Code, o.org_name AS OrgName, o.org_desc AS OrgDesc, " +
                "o.regd_num AS RegdNum, o.org_pan AS PAN, o.org_tan AS TAN, o.gstin as GSTIN, " +
                "o.address_id AddressId, o.contact_id ContactId, " +
                "o.is_enabled AS IsEnabled, " +
                "o.created_at AS CreatedAt, o.updated_at AS UpdatedAt, " +
                "a.id, a.attention, a.addr_line1 AddressLine1, a.addr_line2 AddressLine2, a.city, a.addr_state State, " +
                "a.country, a.postal_code PostalCode, a.phone, a.fax, " +
                "c.id, c.salutation, c.first_name FirstName, c.last_name LastName, c.designation, c.department, c.email, " +
                "c.work_phone WorkPhone, c.mobile_number MobileNumber " +
                "FROM organizations o " +
                "LEFT JOIN addresses a ON o.address_id=a.id " +
                "LEFT JOIN contacts c ON o.contact_id=c.id " +
                "WHERE o.id=@id";

            using (var con = _connection.GetConnection())
            {
                var result = con.Query<Organization, Address, Contact, Organization>(qry,
                    (org, addr, contact) => { org.Address = addr; org.Contact = contact; return org; },
                    new { id }, splitOn: "id")
                    .FirstOrDefault();
                return result;
            }
        }

        public bool Create(Organization org)
        {
            using (var con = _connection.GetConnection())
            {
                string sql = "INSERT INTO organizations (id, code, org_name, org_desc, " +
                    "regd_num, org_pan, org_tan, gstin, is_enabled, created_at) " +
                    $"VALUES ('{Guid.NewGuid().ToString()}', @code, @orgName, @orgDesc, " +
                    "@regdNum, @pan, @tan, @gstin, @isEnabled, " +
                    $"'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
                con.Execute(sql, org);
            }
            return true;
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
