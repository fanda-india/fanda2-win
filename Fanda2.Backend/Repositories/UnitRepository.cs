using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class UnitRepository : MasterRepositoryBase<Unit, UnitListModel>
    {
        public override List<UnitListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                Func<UnitListModel, bool> filterDisabled;
                if (includeDisabled)
                    filterDisabled = (p) => true;
                else
                    filterDisabled = (p => p.IsEnabled == true);

                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.Select<UnitListModel>(u => u.OrgId == orgId && filterDisabled(u))
                        .ToList();
                }
                else
                {
                    return con.Select<UnitListModel>(u =>
                        u.OrgId == orgId && filterDisabled(u) &&
                         (u.Code.Contains(searchTerm) ||
                         u.UnitName.Contains(searchTerm) ||
                         u.UnitDesc.Contains(searchTerm))
                    ).ToList();
                }
            }
        }
    }
}