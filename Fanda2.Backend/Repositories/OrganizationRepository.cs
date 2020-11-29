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
            string qry = "SELECT id, code AS Code, org_name AS Name, org_desc AS Description " +
                // "regd_num AS RegdNum, org_pan AS PAN, org_tan AS TAN, gstin as GSTIN, " +
                // "CASE WHEN is_enabled='Y' THEN 1 ELSE 0 END AS IsEnabled " +
                //", created_at AS CreatedAt, updated_at AS UpdatedAt " +
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
            string qry = "SELECT id, code AS Code, org_name AS Name, org_desc AS Description, " +
                "regd_num AS RegdNum, org_pan AS PAN, org_tan AS TAN, gstin as GSTIN, " +
                "is_enabled AS IsEnabled, " +
                "created_at AS CreatedAt, updated_at AS UpdatedAt " +
                "FROM organizations " +
                "WHERE id=@id";

            using (var con = _connection.GetConnection())
            {
                return con.QuerySingle<Organization>(qry, new { id });
            }
        }

        public bool Create(Organization org)
        {
            using (var con = _connection.GetConnection())
            {
                string sql = "INSERT INTO organizations (id, code, org_name, org_desc, " +
                    "regd_num, org_pan, org_tan, gstin, is_enabled, created_at) " +
                    $"VALUES ('{Guid.NewGuid().ToString()}', @code, @name, @description, " +
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
                string sql = "UPDATE organizations SET code=@code, org_name=@name, " +
                    "org_desc=@description, regd_num=@regdNum, org_pan=@pan, " +
                    "org_tan=@tan, gstin=@gstin, is_enabled=@isEnabled, " +
                    $"updated_at='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'" +
                    "WHERE id=@id";
                con.Execute(sql, org);
            }
            return true;
        }

        public bool Remove(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                using (var con = _connection.GetConnection())
                {
                    string sql = "DELETE FROM organizations WHERE id=@id";
                    con.Execute(sql, new { id });
                }
                return true;
            }
            return false;
        }
    }
}