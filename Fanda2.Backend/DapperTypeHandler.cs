using Dapper;

using System;
using System.Data;

namespace Fanda2.Backend
{
    internal abstract class SqliteTypeHandler<T> : SqlMapper.TypeHandler<T>
    {
        // Parameters are converted by Microsoft.Data.Sqlite
        public override void SetValue(IDbDataParameter parameter, T value)
            => parameter.Value = value;
    }

    internal class DateTimeOffsetHandler : SqliteTypeHandler<DateTimeOffset>
    {
        public override DateTimeOffset Parse(object value)
            => DateTimeOffset.Parse((string)value);
    }

    internal class GuidHandler : SqliteTypeHandler<Guid>
    {
        public override Guid Parse(object value)
            => Guid.Parse((string)value);
    }

    internal class TimeSpanHandler : SqliteTypeHandler<TimeSpan>
    {
        public override TimeSpan Parse(object value)
            => TimeSpan.Parse((string)value);
    }
}
