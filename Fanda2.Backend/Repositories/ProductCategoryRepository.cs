using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Fanda2.Backend.Repositories
{
    public class ProductCategoryRepository : MasterRepositoryBase<ProductCategory, ProductCategoryListModel>
    {
        public override List<ProductCategoryListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                Func<ProductCategoryListModel, bool> filterDisabled;
                if (includeDisabled)
                    filterDisabled = (p) => true;
                else
                    filterDisabled = (p => p.IsEnabled == true);

                if (string.IsNullOrEmpty(searchTerm))
                {
                    return con.Select<ProductCategoryListModel>(pc => pc.OrgId == orgId && filterDisabled(pc))
                        .ToList();
                }
                else
                {
                    return con.Select<ProductCategoryListModel>(pc =>
                        pc.OrgId == orgId && filterDisabled(pc) &&
                         (pc.Code.Contains(searchTerm) ||
                         pc.CategoryName.Contains(searchTerm) ||
                         pc.CategoryDesc.Contains(searchTerm)) ||
                         pc.ParentCategoryName.Contains(searchTerm)
                    ).ToList();
                }
            }
        }
    }
}