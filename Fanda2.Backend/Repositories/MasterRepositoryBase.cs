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
        protected readonly SQLiteDB _db;

        protected MasterRepositoryBase()
        {
            _db = new SQLiteDB();
        }

        public abstract List<TListModel> GetAll(int orgId, string searchTerm = null);

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
