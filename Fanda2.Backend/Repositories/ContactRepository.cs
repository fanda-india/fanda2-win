using Dapper;

using Dommel;

using Fanda2.Backend.Database;

using System;
using System.Data;

namespace Fanda2.Backend.Repositories
{
    internal class ContactRepository : IRepository<Contact>
    {
        public string Save(Contact entity, IDbConnection con, IDbTransaction tran)
        {
            if (entity == null)
                return null;

            // Insert
            if (string.IsNullOrEmpty(entity.Id))
            {
                if (entity.IsEmpty())
                    return null;

                entity.Id = Guid.NewGuid().ToString();
                con.Insert(entity, tran);
                return entity.Id;
            }
            // Update
            else
            {
                if (entity.IsEmpty())
                {
                    if (Remove(entity.Id, con, tran))
                        return null;
                    return entity.Id;
                }
                else
                {
                    con.Update(entity, tran);
                    return entity.Id;
                }
            }
        }

        public bool Remove(string id, IDbConnection con, IDbTransaction tran)
        {
            if (string.IsNullOrEmpty(id) || id.Length != 36)
            {
                return false;
            }
            int rows = con.Execute("DELETE FROM contacts WHERE id=@id", new { id }, tran);
            return rows == 1;
        }
    }
}
