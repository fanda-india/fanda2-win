using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class UnitRepository : MasterRepositoryBase<Unit, UnitListModel>
    {
        public override List<UnitListModel> GetAll(int orgId, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.Select<UnitListModel>(u => u.OrgId == orgId)
                        .ToList();
                }
                else
                {
                    return con.Select<UnitListModel>(u =>
                        u.OrgId == orgId &&
                         (u.Code.Contains(searchTerm) ||
                         u.UnitName.Contains(searchTerm) ||
                         u.UnitDesc.Contains(searchTerm))
                    ).ToList();
                }
            }
        }
    }
}
