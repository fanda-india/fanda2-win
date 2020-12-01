using Fanda2.Backend.Database;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fanda.UI
{
    internal static class AppConfig
    {
        public static User LoggedInUser { get; set; }
        public static Organization CurrentCompany { get; set; }
        public static AccountYear CurrentYear { get; set; }
    }
}