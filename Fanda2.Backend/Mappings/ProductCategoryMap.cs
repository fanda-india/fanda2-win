using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

namespace Fanda2.Backend.Mappings
{
    internal class ProductCategoryMap : DommelEntityMap<ProductCategory>
    {
        internal ProductCategoryMap()
        {
            ToTable("product_categories");

            Map(pc => pc.Id).ToColumn("id").IsKey();
            Map(pc => pc.Code).ToColumn("code");
            Map(pc => pc.CategoryName).ToColumn("category_name");
            Map(pc => pc.CategoryDesc).ToColumn("category_desc");
            Map(pc => pc.ParentId).ToColumn("parent_id");
            Map(pc => pc.OrgId).ToColumn("org_id");
            Map(pc => pc.IsEnabled).ToColumn("is_enabled");
            Map(pc => pc.CreatedAt).ToColumn("created_at");
            Map(pc => pc.UpdatedAt).ToColumn("updated_at");
        }
    }

    //internal class ProductCategoryListMap : DommelEntityMap<ProductCategoryListModel>
    //{
    //    internal ProductCategoryListMap()
    //    {
    //        ToTable("product_categories");

    //        Map(pc => pc.Id).ToColumn("id").IsKey();
    //        Map(pc => pc.Code).ToColumn("code");
    //        Map(pc => pc.CategoryName).ToColumn("category_name");
    //        Map(pc => pc.CategoryDesc).ToColumn("category_desc");
    //        // Map(pc => pc.ParentCategoryName).ToColumn("parent_category_name");
    //        Map(pc => pc.IsEnabled).ToColumn("is_enabled");
    //        //Map(pc => pc.OrgId).ToColumn("org_id");
    //    }
    //}
}