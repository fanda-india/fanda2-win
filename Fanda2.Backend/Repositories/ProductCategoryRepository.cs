using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Helpers;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fanda2.Backend.Repositories
{
    public class ProductCategoryRepository : MasterRepositoryBase<ProductCategory, ProductCategoryListModel>
    {
        public override List<ProductCategoryListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                Expression<Func<ProductCategoryListModel, bool>> filterDisabled;
                if (includeDisabled)
                {
                    filterDisabled = (p) => true;
                }
                else
                {
                    filterDisabled = (p => p.IsEnabled == true);
                }

                if (string.IsNullOrEmpty(searchTerm))
                {
                    Expression<Func<ProductCategoryListModel, bool>> filterOrg = (p) => p.OrgId == orgId;

                    var filters = DbHelper.AndAlso(filterDisabled, filterOrg);
                    return con.Select(filters)
                        .ToList();
                }
                else
                {
                    Expression<Func<ProductCategoryListModel, bool>> filterOrg = (pc) => pc.OrgId == orgId &&
                        (pc.Code.Contains(searchTerm) ||
                         pc.CategoryName.Contains(searchTerm) ||
                         pc.CategoryDesc.Contains(searchTerm)) ||
                         pc.ParentCategoryName.Contains(searchTerm);

                    var filters = DbHelper.AndAlso(filterDisabled, filterOrg);
                    return con.Select<ProductCategoryListModel>(filters)
                        .ToList();
                }
            }
        }
    }
}