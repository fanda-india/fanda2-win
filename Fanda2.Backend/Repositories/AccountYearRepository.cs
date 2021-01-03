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
    public class AccountYearRepository : MasterRepositoryBase<AccountYear, AccountYearListModel>
    {
        public override List<AccountYearListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                Expression<Func<AccountYearListModel, bool>> filterDisabled;
                if (includeDisabled)
                    filterDisabled = (p) => true;
                else
                    filterDisabled = (p => p.IsEnabled == true);

                if (string.IsNullOrEmpty(searchTerm))
                {
                    Expression<Func<AccountYearListModel, bool>> filterOrg = (o) => o.OrgId == orgId;

                    var expr = DbHelper.AndAlso<AccountYearListModel>(filterDisabled, filterOrg);
                    return con.Select<AccountYearListModel>(expr)
                        .ToList();
                }
                else
                {
                    Expression<Func<AccountYearListModel, bool>> filterOrg =
                        (ay) => ay.OrgId == orgId &&
                        ay.YearCode.Contains(searchTerm);

                    var expr = DbHelper.AndAlso<AccountYearListModel>(filterDisabled, filterOrg);
                    return con.Select<AccountYearListModel>(expr)
                        .ToList();
                }
            }
        }

        //public int? Save(AccountYear year, IDbConnection con, IDbTransaction tran)
        //{
        //    if (year.OrgId <= 0)
        //    {
        //        throw new ArgumentNullException("YearId of AccountYear is null");
        //    }

        //    // Insert
        //    if (year.Id == 0)
        //    {
        //        if (year.IsEmpty())
        //        {
        //            return null;
        //        }
        //        int id = Convert.ToInt32(con.Insert(year));
        //        year.Id = id;
        //        return id;
        //    }
        //    // Update
        //    else
        //    {
        //        if (year.IsEmpty())
        //        {
        //            if (Remove(year.Id, con, tran))
        //            {
        //                return null;
        //            }

        //            return balance.Id;
        //        }
        //        else
        //        {
        //            con.Update(balance, tran);
        //            return balance.Id;
        //        }
        //    }
        //}
    }
}