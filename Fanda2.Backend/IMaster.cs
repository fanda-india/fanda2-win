using System;

namespace Fanda2.Backend
{
    public interface IMaster
    {
        int Id { get; set; }
        int OrgId { get; set; }
        bool IsEnabled { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }

        bool IsEmpty();
    }
}
