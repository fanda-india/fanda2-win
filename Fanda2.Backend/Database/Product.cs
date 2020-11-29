using System;

namespace Fanda2.Backend.Database
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType ProductType { get; set; }

        public Guid CategoryId { get; set; }

        //public Guid? BrandId { get; set; }
        //public Guid? SegmentId { get; set; }
        //public Guid? VarietyId { get; set; }
        public Guid UnitId { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellingPrice { get; set; }

        #region Tax / GST

        public string TaxCode { get; set; } //HSN code for Goods; SAC code for Service
        public ProductTaxPreference TaxPreference { get; set; }
        public decimal TaxPct { get; set; }

        #endregion Tax / GST

        public Guid OrgId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}