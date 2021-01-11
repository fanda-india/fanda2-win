using Dapper;

using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.ViewModels;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public class ProductCategoryRepository : MasterRepositoryBase<ProductCategory, ProductCategory>
    {
        public override List<ProductCategory> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                // [Filter]
                StringBuilder filters = new StringBuilder($"org_id = {orgId}");
                if (!includeDisabled)
                {
                    filters.Append(" and is_enabled = 1");
                }
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    filters.Append($" and (code like '%{searchTerm}%' or category_name like '%{searchTerm}%' or category_desc like '%{searchTerm}%')");
                }

                // Fetch from database
                var list = con.Query<ProductCategory>(
                    $"select id, code, category_name, category_desc, is_enabled, org_id, created_at, updated_at " +
                    $"from product_categories where {filters}")
                    .ToList();
                return list;

                #region Commented

                //Expression<Func<ProductCategoryListModel, bool>> filterDisabled;
                //if (includeDisabled)
                //{
                //    filterDisabled = (p) => true;
                //}
                //else
                //{
                //    filterDisabled = (p => p.IsEnabled == true);
                //}

                //if (string.IsNullOrEmpty(searchTerm))
                //{
                //    Expression<Func<ProductCategoryListModel, bool>> filterOrg = (p) => p.OrgId == orgId;

                //    var filters = DbHelper.AndAlso(filterDisabled, filterOrg);
                //    return con.Select(filters)
                //        .ToList();
                //}
                //else
                //{
                //    Expression<Func<ProductCategoryListModel, bool>> filterOrg = (pc) => pc.OrgId == orgId &&
                //        (pc.Code.Contains(searchTerm) ||
                //         pc.CategoryName.Contains(searchTerm) ||
                //         pc.CategoryDesc.Contains(searchTerm));
                //    // || pc.ParentCategoryName.Contains(searchTerm);

                //    var filters = DbHelper.AndAlso(filterDisabled, filterOrg);
                //    return con.Select<ProductCategoryListModel>(filters)
                //        .ToList();
                //}

                #endregion Commented
            }
        }

        public override bool Exists(KeyField keyField, string fieldValue, int id, int orgId)
        {
            using (var con = _db.GetConnection())
            {
                string query;
                switch (keyField)
                {
                    case KeyField.Code:
                        query = $"select 1 from product_categories where code=@code COLLATE NOCASE and org_id=@orgId and id <> @id";
                        return con.ExecuteScalar<int>(query, new { code = fieldValue, orgId, id }) == 1;

                    case KeyField.Name:
                        query = $"select 1 from product_categories where category_name=@categoryName COLLATE NOCASE and org_id=@orgId and id <> @id";
                        return con.ExecuteScalar<int>(query, new { categoryName = fieldValue, orgId, id }) == 1;

                    default:
                        return true;
                }
            }
        }
    }
}