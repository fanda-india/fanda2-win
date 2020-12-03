using System;

namespace Fanda2.Backend.Database
{
    public class User
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPassword { get; set; }
        public DateTime? LoginAt { get; set; }
        public bool? IsResetPassword { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
