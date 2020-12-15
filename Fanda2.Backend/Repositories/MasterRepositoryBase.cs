using Dommel;

using System;
using System.Collections.Generic;
using System.Data;

namespace Fanda2.Backend.Repositories
{
    public abstract class MasterRepositoryBase<TEntity, TListModel> :
        IRepository<TEntity, TListModel>
        where TEntity : class, IMaster
        where TListModel : class
    {
        protected readonly SQLiteDB _db;

        protected MasterRepositoryBase()
        {
            _db = new SQLiteDB();
        }

        public abstract List<TListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null);

        public virtual TEntity GetById(int id)
        {
            using (var con = _db.GetConnection())
            {
                return con.Get<TEntity>(id);
            }
        }

        public virtual int Create(int orgId, TEntity entity)
        {
            using (var con = _db.GetConnection())
            {
                int newId = Create(orgId, entity, con, null);
                return newId;
            }
        }

        public int Create(int orgId, TEntity entity, IDbConnection con, IDbTransaction tran)
        {
            if (entity == null || entity.IsEmpty())
                return 0;

            entity.OrgId = orgId;
            entity.CreatedAt = DateTime.Now;
            int newId = Convert.ToInt32(con.Insert(entity, tran));
            entity.Id = newId;
            return newId;
        }

        public virtual bool Update(int id, TEntity entity)
        {
            using (var con = _db.GetConnection())
            {
                return Update(id, entity, con, null);
            }
        }

        public bool Update(int id, TEntity entity, IDbConnection con, IDbTransaction tran)
        {
            if (entity == null || entity.IsEmpty())
                return false;

            if (id <= 0 || id != entity.Id)
            {
                return false;
            }
            entity.UpdatedAt = DateTime.Now;
            return con.Update(entity, tran);
        }

        public virtual bool Remove(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                TEntity entity = con.Get<TEntity>(id);
                if (entity == null)
                {
                    return false;
                }

                return con.Delete(entity);
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
