using System;

namespace Fanda2.Backend.Database
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public int? ParentId { get; set; }     // nullable
        public int OrgId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}