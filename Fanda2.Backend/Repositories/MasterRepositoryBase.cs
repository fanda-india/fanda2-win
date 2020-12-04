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

        public virtual int Create(int orgId, TEntity entity)
        {
            using (var con = _db.GetConnection())
            {
                entity.OrgId = orgId;
                entity.CreatedAt = DateTime.Now;
                int newId = Convert.ToInt32(con.Insert(entity));
                return newId;
            }
        }

        public virtual bool Update(int id, TEntity entity)
        {
            if (id <= 0 || id != entity.Id)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                entity.UpdatedAt = DateTime.Now;
                return con.Update(entity);
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
