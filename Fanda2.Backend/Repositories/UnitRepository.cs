using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Helpers;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fanda2.Backend.Repositories
{
    public class UnitRepository : MasterRepositoryBase<Unit, UnitListModel>
    {
        public override List<UnitListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                Expression<Func<UnitListModel, bool>> filterDisabled;
                if (includeDisabled)
                    filterDisabled = (p) => true;
                else
                    filterDisabled = (p => p.IsEnabled == true);

                if (string.IsNullOrEmpty(searchTerm))
                {
                    Expression<Func<UnitListModel, bool>> filterOrg = (o) => o.OrgId == orgId;

                    var filters = DbHelper.AndAlso(filterDisabled, filterOrg);
                    return con.Select(filters)
                        .ToList();
                }
                else
                {
                    Expression<Func<UnitListModel, bool>> filterOrg = (u) => u.OrgId == orgId &&
                        (u.Code.Contains(searchTerm) ||
                        u.UnitName.Contains(searchTerm) ||
                        u.UnitDesc.Contains(searchTerm));

                    var filters = DbHelper.AndAlso(filterDisabled, filterOrg);
                    return con.Select(filters)
                        .ToList();
                }
            }
        }
    }
}