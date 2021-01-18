using Fanda2.Backend.Enums;

using System.Collections.Generic;
using System.Data;

namespace Fanda2.Backend
{
    internal interface IRepository<Entity, ListModel>
    {
        List<ListModel> GetAll(int superId, bool includeDisabled = true, string searchTerm = null);

        Entity GetById(int id);

        int Add(int superId, Entity entity);

        bool Update(int id, Entity entity);

        bool Remove(int id);

        bool Exists(KeyField keyField, string fieldValue, int id, int superId);
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

    internal interface IRootRepository<Entity, ListModel>
    {
        List<ListModel> GetAll(bool includeDisabled = true, string searchTerm = null);

        Entity GetById(int id);

        int Add(Entity entity);

        bool Update(int id, Entity entity);

        bool Remove(int id);

        bool Exists(KeyField keyField, string fieldValue, int id);
    }
}
