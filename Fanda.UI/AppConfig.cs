using Fanda2.Backend.Database;

namespace Fanda.UI
{
    internal static class AppConfig
    {
        public static User LoggedInUser { get; set; }
        public static Organization CurrentCompany { get; set; }
        public static AccountYear CurrentYear { get; set; }
    }
}