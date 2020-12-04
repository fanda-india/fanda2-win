using System.Collections.Generic;
using System.Data;

namespace Fanda2.Backend
{
    internal interface IRepository<Entity, ListModel>
    {
        List<ListModel> GetAll(int superId, string searchTerm = null);

        Entity GetById(int id);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Newly inserted id</returns>
        int Create(int superId, Entity entity);

        bool Update(int id, Entity entity);

        bool Remove(int id);
    }

    internal interface IRootRepository<Entity, ListModel>
    {
        List<ListModel> GetAll(string searchTerm = null);

        Entity GetById(int id);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Newly inserted id</returns>
        int Create(Entity entity);

        bool Update(int id, Entity entity);

        bool Remove(int id);
    }

    internal interface IRepository<Entity>
    {
        /// <summary>
        /// Insert or Update or Delete table
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns>id</returns>
        int? Save(Entity entity, IDbConnection con, IDbTransaction tran);

        /// <summary>
        /// Delete from table
        /// </summary>
        /// <param name="id">GUID as string</param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        bool Remove(int? id, IDbConnection con, IDbTransaction tran);
    }

    internal interface ISubRepository<Entity>
    {
        bool Save(int superId, Entity entity, IDbConnection con, IDbTransaction tran);

        bool Remove(int superId, IDbConnection con, IDbTransaction tran);
    }
}
