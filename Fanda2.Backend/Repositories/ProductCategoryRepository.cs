﻿using Dommel;

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

        public override bool Exists(KeyField keyField, string fieldValue, int id, int orgId)
        {
            bool exists = true;
            using (var con = _db.GetConnection())
            {
                switch (keyField)
                {
                    case KeyField.Code:
                        exists = con.Any<ProductCategory>(o => o.Id != id && o.Code == fieldValue && o.OrgId == orgId);
                        break;

                    case KeyField.Name:
                        exists = con.Any<ProductCategory>(o => o.Id != id && o.CategoryName == fieldValue && o.OrgId == orgId);
                        break;
                }
            }
            return exists;
        }
    }
}
