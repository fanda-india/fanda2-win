using System;

namespace Fanda2.Backend.Database
{
    public class Unit : IMaster
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string UnitName { get; set; }
        public string UnitDesc { get; set; }
        public int OrgId { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
