using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;
using Fanda2.Backend.Helpers;
using Fanda2.Backend.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fanda2.Backend.Repositories
{
    public class ProductRepository : MasterRepositoryBase<Product, ProductListModel>
    {
        public override List<ProductListModel> GetAll(int orgId, bool includeDisabled = true, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                Expression<Func<ProductListModel, bool>> filterDisabled;
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
                    Expression<Func<ProductListModel, bool>> filterOrg = (p) => p.OrgId == orgId;

                    var filters = DbHelper.AndAlso(filterDisabled, filterOrg);
                    return con.Select(filters)
                        .ToList();
                }
                else
                {
                    Expression<Func<ProductListModel, bool>> filterOrg = (p) => p.OrgId == orgId &&
                        (p.Code.Contains(searchTerm) ||
                         p.ProductName.Contains(searchTerm) ||
                         p.ProductDesc.Contains(searchTerm)) ||
                         p.CategoryName.Contains(searchTerm);

                    var filters = DbHelper.AndAlso(filterDisabled, filterOrg);
                    return con.Select<ProductListModel>(filters)
                        .ToList();
                }
            }
        }

        public override bool Exists(KeyField keyField, string fieldValue, int id, int orgId)
        {
            bool exists = true;
            using (var con = _db.GetConnection())
            {
                switch (keyField)
                {
                    case KeyField.Code:
                        exists = con.Any<Product>(o => o.Id != id && o.Code == fieldValue && o.OrgId == orgId);
                        break;

                    case KeyField.Name:
                        exists = con.Any<Product>(o => o.Id != id && o.ProductName == fieldValue && o.OrgId == orgId);
                        break;
                }
            }
            return exists;
        }
    }
}
