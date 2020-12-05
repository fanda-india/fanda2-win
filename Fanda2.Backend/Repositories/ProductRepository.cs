using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class ProductRepository : MasterRepositoryBase<Product, ProductListModel>
    {
        public override List<ProductListModel> GetAll(int orgId, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.Select<ProductListModel>(p => p.OrgId == orgId)
                        .ToList();
                }
                else
                {
                    return con.Select<ProductListModel>(p =>
                        p.OrgId == orgId &&
                         (p.Code.Contains(searchTerm) ||
                         p.ProductName.Contains(searchTerm) ||
                         p.ProductDesc.Contains(searchTerm)) ||
                         p.CategoryName.Contains(searchTerm)
                    ).ToList();
                }
            }
        }
    }
}
