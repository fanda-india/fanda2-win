using System;

namespace Fanda2.Backend.Database
{
    public class ProductCategory : IMaster
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public int? ParentId { get; set; }     // nullable
        public int OrgId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Code) &&
                string.IsNullOrWhiteSpace(CategoryName);
        }
    }
}