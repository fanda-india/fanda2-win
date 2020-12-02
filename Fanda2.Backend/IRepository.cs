using System;
using System.Collections.Generic;
using System.Text;

namespace Fanda2.Backend
{
    internal interface IRepository<Entity, ListModel>
    {
        List<ListModel> GetAll(string searchTerm = null);

        Entity GetById(string id);

        Entity Create(Entity entity);

        bool Update(string id, Entity entity);

        bool Remove(string id);
    }
}