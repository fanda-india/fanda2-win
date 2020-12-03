using Dapper;

using Dommel;

using Fanda2.Backend.Database;

using System;
using System.Data;

namespace Fanda2.Backend.Repositories
{
    internal class AddressRepository : IRepository<Address>
    {
        public int? Save(Address entity, IDbConnection con, IDbTransaction tran)
        {
            if (entity == null)
                return null;

            // Insert
            if (entity.Id == 0)
            {
                if (entity.IsEmpty())
                    return null;

                int id = Convert.ToInt32(con.Insert(entity, tran));
                entity.Id = id;
                return id;
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

        public bool Remove(int? id, IDbConnection con, IDbTransaction tran)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return false;
            }
            int rows = con.Execute("DELETE FROM addresses WHERE id=@id", new { id }, tran);
            return rows == 1;
        }
    }
}