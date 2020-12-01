using System;

namespace Fanda2.Backend.Database
{
    public class Unit
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string UnitName { get; set; }
        public string UnitDesc { get; set; }
        public string OrgId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
