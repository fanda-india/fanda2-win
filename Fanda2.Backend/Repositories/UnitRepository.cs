using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public class UnitRepository : MasterRepositoryBase<Unit, Unit>
    {
        //public UnitRepository()
        //{
        //    DommelMapper.LogReceived = (qry) =>
        //    {
        //        Debug.WriteLine("LOG: " + qry);
        //    };
        //}

        public override List<Unit> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                // [Filter]
                StringBuilder filters = new StringBuilder($"org_id = {orgId}");
                if (!includeDisabled)
                {
                    filters.Append(" and is_enabled = 1");
                }
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filters.Append($" and (code like '%{searchTerm}%' or unit_name like '%{searchTerm}%' or unit_desc like '%{searchTerm}%')");
                }

                // Fetch from database
                var list = con.Query<Unit>(
                    $"select id, code, unit_name, unit_desc, is_enabled, org_id, created_at, updated_at " +
                    $"from units where {filters}")
                    .ToList();
                return list;
            }
        }

        public override bool Exists(KeyField keyField, string fieldValue, int id, int orgId)
        {
            using (var con = _db.GetConnection())
            {
                string query;
                switch (keyField)
                {
                    case KeyField.Code:
                        query = $"select 1 from units where code=@code COLLATE NOCASE and org_id=@orgId and id <> @id";
                        return con.ExecuteScalar<int>(query, new { code = fieldValue, orgId, id }) == 1;

                    case KeyField.Name:
                        query = $"select 1 from units where unit_name=@unitName COLLATE NOCASE and org_id=@orgId and id <> @id";
                        return con.ExecuteScalar<int>(query, new { unitName = fieldValue, orgId, id }) == 1;

                    default:
                        return true;
                }
            }
        }
    }
}