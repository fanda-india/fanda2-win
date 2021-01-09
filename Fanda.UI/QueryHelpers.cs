using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fanda.UI
{
    internal static class QueryHelpers
    {
        internal static string EscapeSqlLike(string s_)
        {
            StringBuilder s = new StringBuilder(s_);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\'')
                {
                    s.Insert(i++, '\'');
                    continue;
                }
                if (s[i] == '[' || s[i] == '*' || s[i] == '?')
                {
                    s.Insert(i++, '[');
                    s.Insert(++i, ']');
                }
            }
            return s.ToString();
        }
    }
}
