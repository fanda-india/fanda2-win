using Fanda2.Backend.Enums;

using System;

namespace Fanda2.Backend.Database
{
    public class Product : IMaster
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public ProductType ProductType { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }

        #region Tax / GST

        public string TaxCode { get; set; } //HSN code for Goods; SAC code for Service
        public ProductTaxPreference TaxPreference { get; set; }
        public decimal TaxPct { get; set; }

        #endregion Tax / GST

        public int OrgId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Product Clone()
        {
            return (Product)MemberwiseClone();
        }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Code) &&
                string.IsNullOrWhiteSpace(ProductName) &&
                (int)ProductType == 1 &&
                CategoryId == 0 &&
                UnitId == 0;
        }
    }
}
