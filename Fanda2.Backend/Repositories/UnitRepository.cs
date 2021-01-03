using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public class UnitRepository : MasterRepositoryBase<Unit, UnitListModel>
    {
        public UnitRepository()
        {
            DommelMapper.LogReceived = (qry) =>
            {
                Debug.WriteLine("LOG: " + qry);
            };
        }

        public override List<UnitListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                StringBuilder filters = new StringBuilder($"org_id = {orgId}");

                if (!includeDisabled)
                    filters.Append(" and is_enabled = 1");

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filters.Append($" and (code like '%{searchTerm}%' or unit_name like '%{searchTerm}%' or unit_desc like '%{searchTerm}%')");
                }

                var list = con.Query<UnitListModel>($"select * from units where {filters}")
                    .ToList();

                return list;
            }
        }
    }
}