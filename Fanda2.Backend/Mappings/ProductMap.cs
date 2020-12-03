using Dapper.FluentMap.Dommel.Mapping;

using Fanda2.Backend.Database;
using Fanda2.Backend.ViewModels;

namespace Fanda2.Backend.Mappings
{
    internal class ProductMap : DommelEntityMap<Product>
    {
        internal ProductMap()
        {
            ToTable("products");

            Map(pc => pc.Id).ToColumn("id").IsKey();
            Map(pc => pc.Code).ToColumn("code");
            Map(pc => pc.ProductName).ToColumn("product_name");
            Map(pc => pc.ProductDesc).ToColumn("product_desc");
            Map(pc => pc.ProductType).ToColumn("parent_type");
            Map(pc => pc.CategoryId).ToColumn("category_id");
            Map(pc => pc.UnitId).ToColumn("unit_id");
            Map(pc => pc.CostPrice).ToColumn("cost_price");
            Map(pc => pc.SellingPrice).ToColumn("selling_price");
            Map(pc => pc.TaxCode).ToColumn("tax_code");
            Map(pc => pc.TaxPreference).ToColumn("tax_preference");
            Map(pc => pc.TaxPct).ToColumn("tax_pct");
            Map(pc => pc.OrgId).ToColumn("org_id");
            Map(pc => pc.IsEnabled).ToColumn("is_enabled");
            Map(pc => pc.CreatedAt).ToColumn("created_at");
            Map(pc => pc.UpdatedAt).ToColumn("updated_at");
        }
    }

    internal class ProductListMap : DommelEntityMap<ProductListModel>
    {
        internal ProductListMap()
        {
            ToTable("products");

            Map(pc => pc.Id).ToColumn("id").IsKey();
            Map(pc => pc.Code).ToColumn("code");
            Map(pc => pc.ProductName).ToColumn("product_name");
            Map(pc => pc.ProductDesc).ToColumn("product_desc");
            Map(pc => pc.CategoryName).ToColumn("category_name");
            Map(pc => pc.OrgId).ToColumn("org_id");
            Map(pc => pc.IsEnabled).ToColumn("is_enabled");
        }
    }
}
