using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class AccountYearRepository : MasterRepositoryBase<AccountYear, AccountYearListModel>
    {
        public override List<AccountYearListModel> GetAll(int orgId, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.Select<AccountYearListModel>(ay => ay.OrgId == orgId)
                        .ToList();
                }
                else
                {
                    return con.Select<AccountYearListModel>(ay => ay.OrgId == orgId && ay.YearCode.Contains(searchTerm))
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
