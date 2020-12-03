
using Dommel;

using System;
using System.Collections.Generic;

namespace Fanda2.Backend.Repositories
{
    public abstract class MasterRepositoryBase<TEntity, TListModel> :
        IRepository<TEntity, TListModel>
        where TEntity : class, IMaster
        where TListModel : class
    {
        private readonly SQLiteDB _db;

        public MasterRepositoryBase()
        {
            _db = new SQLiteDB();
        }

        public virtual List<TListModel> GetAll(int orgId, string searchTerm = null)
        {
            //using (var con = _db.GetConnection())
            //{
            //    if (string.IsNullOrEmpty(searchTerm))
            //    {
            //        return con.Select<TListModel>(u => u.OrgId == orgId)
            //            .ToList();
            //    }
            //    else
            //    {
            //        return con.Select<TListModel>(u =>
            //            u.OrgId == orgId &&
            //             (u.Code.Contains(searchTerm) ||
            //             u.UnitName.Contains(searchTerm) ||
            //             u.UnitDesc.Contains(searchTerm))
            //        ).ToList();
            //    }
            //}
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(int id)
        {
            using (var con = _db.GetConnection())
            {
                return con.Get<TEntity>(id);
            }
        }

        public virtual int Create(int orgId, TEntity unit)
        {
            using (var con = _db.GetConnection())
            {
                unit.OrgId = orgId;
                unit.CreatedAt = DateTime.Now;
                int unitId = Convert.ToInt32(con.Insert(unit));
                return unitId;
            }
        }

        public virtual bool Update(int unitId, TEntity unit)
        {
            if (unitId <= 0 || unitId != unit.Id)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                unit.UpdatedAt = DateTime.Now;
                return con.Update(unit);
            }
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
