using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public class UnitRepository : MasterRepositoryBase<Unit, UnitListModel>
    {
        //public UnitRepository()
        //{
        //    DommelMapper.LogReceived = (qry) =>
        //    {
        //        Debug.WriteLine("LOG: " + qry);
        //    };
        //}

        public override List<UnitListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
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
                var list = con.Query<UnitListModel>($"select id, code, unit_name, unit_desc, is_enabled from units where {filters}")
                    .ToList();
                return list;
            }
        }

        public override bool Exists(KeyField keyField, string fieldValue, int id, int orgId)
        {
            bool exists = true;
            using (var con = _db.GetConnection())
            {
                switch (keyField)
                {
                    case KeyField.Code:
                        exists = con.Any<Unit>(o => o.Id != id && o.Code == fieldValue && o.OrgId == orgId);
                        break;

                    case KeyField.Name:
                        exists = con.Any<Unit>(o => o.Id != id && o.UnitName == fieldValue && o.OrgId == orgId);
                        break;
                }
            }
            return exists;
        }
    }
}
