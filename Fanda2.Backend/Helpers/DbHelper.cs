using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Fanda2.Backend.Helpers
{
    internal static class DbHelper
    {
        public static Expression<Func<T, bool>> AndAlso<T>(Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var body = Expression.AndAlso(expr1.Body, expr2.Body);
            var lambda = Expression.Lambda<Func<T, bool>>(body, expr1.Parameters[0]);
            return lambda;
        }
    }
}