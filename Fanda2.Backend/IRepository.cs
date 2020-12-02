using System.Collections.Generic;
using System.Data;

namespace Fanda2.Backend
{
    internal interface IRepository<Entity>
    {
        /// <summary>
        /// Insert or Update or Delete table
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns>Always return GUID as string</returns>
        string Save(Entity entity, IDbConnection con, IDbTransaction tran);

        /// <summary>
        /// Delete from table
        /// </summary>
        /// <param name="id">GUID as string</param>
        /// <param name="con"></param>
        /// <param name="tran"></param>
        /// <returns></returns>
        bool Remove(string id, IDbConnection con, IDbTransaction tran);
    }

    internal interface IRepository<Entity, ListModel>
    {
        Entity GetById(string id);

        List<ListModel> GetAll(string searchTerm = null);

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Newly inserted GUID as string</returns>
        string Create(Entity entity);

        bool Update(string id, Entity entity);

        bool Remove(string id);
    }
}
