using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class ProductCategoryRepository : MasterRepositoryBase<ProductCategory, ProductCategoryListModel>
    {
        public override List<ProductCategoryListModel> GetAll(int orgId, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.Select<ProductCategoryListModel>(pc => pc.OrgId == orgId)
                        .ToList();
                }
                else
                {
                    return con.Select<ProductCategoryListModel>(pc =>
                        pc.OrgId == orgId &&
                         (pc.Code.Contains(searchTerm) ||
                         pc.CategoryName.Contains(searchTerm) ||
                         pc.CategoryDesc.Contains(searchTerm)) ||
                         pc.ParentCategoryName.Contains(searchTerm)
                    ).ToList();
                }
            }
        }
    }

    //public class UnitRepository : IRepository<Unit, UnitListModel>
    //{
    //    private readonly SQLiteDB _db;

    //    public UnitRepository()
    //    {
    //        _db = new SQLiteDB();
    //    }

    //    public List<UnitListModel> GetAll(int orgId, string searchTerm = null)
    //    {
    //        using (var con = _db.GetConnection())
    //        {
    //            if (string.IsNullOrEmpty(searchTerm))
    //            {
    //                return con.Select<UnitListModel>(u => u.OrgId == orgId)
    //                    .ToList();
    //            }
    //            else
    //            {
    //                return con.Select<UnitListModel>(u =>
    //                    u.OrgId == orgId &&
    //                     (u.Code.Contains(searchTerm) ||
    //                     u.UnitName.Contains(searchTerm) ||
    //                     u.UnitDesc.Contains(searchTerm))
    //                ).ToList();
    //            }
    //        }
    //    }

    //    public Unit GetById(int id)
    //    {
    //        using (var con = _db.GetConnection())
    //        {
    //            return con.Get<Unit>(id);
    //        }
    //    }

    //    public int Create(int orgId, Unit unit)
    //    {
    //        using (var con = _db.GetConnection())
    //        {
    //            unit.OrgId = orgId;
    //            unit.CreatedAt = DateTime.Now;
    //            int unitId = Convert.ToInt32(con.Insert(unit));
    //            return unitId;
    //        }
    //    }

    //    public bool Update(int unitId, Unit unit)
    //    {
    //        if (unitId <= 0 || unitId != unit.Id)
    //        {
    //            return false;
    //        }

    //        using (var con = _db.GetConnection())
    //        {
    //            unit.UpdatedAt = DateTime.Now;
    //            return con.Update(unit);
    //        }
    //    }

    //    public bool Remove(int id)
    //    {
    //        if (id <= 0)
    //        {
    //            return false;
    //        }

    //        using (var con = _db.GetConnection())
    //        {
    //            //Ledger ledger = con.Get<Ledger>(ledgerId);
    //            //if (ledger == null)
    //            //    return false;

    //            int rows = con.Execute("DELETE FROM units WHERE id=@id", new { id });
    //            return rows == 1;
    //        }
    //    }
    //}
}
