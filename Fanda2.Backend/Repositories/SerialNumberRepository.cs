using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public sealed class SerialNumberRepository : IRepository<SerialNumber, SerialNumber>
    {
        private readonly SQLiteDB _db;
        private static readonly object syncRoot = new object();

        public SerialNumberRepository()
        {
            _db = new SQLiteDB();
        }

        #region Increment methods

        public string NextNumber(int yearId, SerialNumberModule module,
            DateTime? yearEnd = default)
        {
            lock (syncRoot)
            {
                using (var con = _db.GetConnection())
                {
                    SerialNumber serialNumber = con.Select<SerialNumber>(sn =>
                        sn.YearId == yearId && sn.SerialModule == module)
                        .FirstOrDefault();

                    if (serialNumber == null)
                    {
                        return null;
                    }

                    #region Commented

                    //int firstIndex = serialNumber.SerialFormat.IndexOf('N'); // YYJJJNNNNN = 5
                    //int lastIndex = serialNumber.SerialFormat.LastIndexOf('N'); // YYJJJNNNNN = 9
                    //string nums = serialNumber.SerialFormat.Substring(firstIndex, (lastIndex - firstIndex) + 1);

                    //int nextNumber = serialNumber.LastNumber + 1;

                    //// Serial prefix to increment alpha
                    //string serialPrefix = serialNumber.SerialPrefix;

                    //switch (serialNumber.SerialReset)
                    //{
                    //    case SerialNumberReset.Max:
                    //    case SerialNumberReset.AccountingYear:
                    //        if (nextNumber.ToString().Length > nums.Length)
                    //        {
                    //            serialPrefix = IncrementAlpha(serialPrefix);
                    //            nextNumber = 1;
                    //        }

                    //        break;

                    //    case SerialNumberReset.Daily:
                    //        if (serialNumber.LastDate.Day != DateTime.Today.Day)
                    //        {
                    //            serialPrefix = IncrementAlpha(serialPrefix);
                    //            nextNumber = 1;
                    //        }

                    //        break;

                    //    case SerialNumberReset.Monthly:
                    //        if (serialNumber.LastDate.Month != DateTime.Today.Month)
                    //        {
                    //            serialPrefix = IncrementAlpha(serialPrefix);
                    //            nextNumber = 1;
                    //        }

                    //        break;

                    //    case SerialNumberReset.CalendarYear:
                    //        if (DateTime.Today.Year > serialNumber.LastDate.Year)
                    //        {
                    //            serialPrefix = IncrementAlpha(serialPrefix);
                    //            nextNumber = 1;
                    //        }

                    //        break;
                    //        //case SerialNumberReset.AccountingYear: // 01/04/2019 - 31/03/2020
                    //        //                                       //var accountYear = await context.AccountYears
                    //        //                                       //    .FindAsync(yearId);
                    //        //    if (DateTime.Today > yearEnd)
                    //        //    {
                    //        //        serialPrefix = IncrementAlpha(serialPrefix);
                    //        //        nextNumber = 1;
                    //        //    }
                    //        //    break;
                    //}

                    //var sbSerialNumber =
                    //    new StringBuilder($"{serialPrefix}{serialNumber.SerialFormat}{serialNumber.SerialSuffix}");

                    //sbSerialNumber.Replace("YYYY", DateTime.Today.ToString("yyyy"));
                    //sbSerialNumber.Replace("YY", DateTime.Today.ToString("yy"));
                    //sbSerialNumber.Replace("MMM", DateTime.Today.ToString("MMM").ToUpper());
                    //sbSerialNumber.Replace("MM", DateTime.Today.ToString("MM"));
                    //sbSerialNumber.Replace("DD", DateTime.Today.ToString("dd"));
                    //sbSerialNumber.Replace("JJJ", $"{DateTime.Today.DayOfYear:D3}");
                    //sbSerialNumber.Replace("HH", DateTime.Now.ToString("HH"));
                    //sbSerialNumber.Replace("MI", DateTime.Now.ToString("mm"));
                    //sbSerialNumber.Replace("SS", DateTime.Now.ToString("ss"));

                    //string nextSerial = nextNumber.ToString().PadLeft(nums.Length, '0');
                    //sbSerialNumber.Replace(nums, nextSerial);
                    //string nextValue = sbSerialNumber.ToString();

                    #endregion Commented

                    var (nextValue, nextNumber) = NextNumber(serialNumber.SerialPrefix,
                        serialNumber.SerialFormat, serialNumber.SerialSuffix, serialNumber.LastNumber,
                        serialNumber.LastDate, yearEnd, serialNumber.SerialReset);

                    serialNumber.LastSerial = nextValue;
                    serialNumber.LastNumber = nextNumber;
                    serialNumber.LastDate = DateTime.Now;

                    con.Update(serialNumber);
                    return nextValue;
                }
            }
        }

        public (string, int) NextNumber(string prefix, string format, string suffix,
            int lastNumber, DateTime? lastDate = default, DateTime? yearEnd = default,
            SerialNumberReset serialReset = SerialNumberReset.Max)
        {
            int firstIndex = format.IndexOf('N');       // YYJJJNNNNN = 5
            int lastIndex = format.LastIndexOf('N');    // YYJJJNNNNN = 9
            string nums = format.Substring(firstIndex, (lastIndex - firstIndex) + 1);

            int nextNumber = lastNumber + 1;

            // Serial prefix to increment alpha
            //string serialPrefix = serialNumber.SerialPrefix;

            switch (serialReset)
            {
                case SerialNumberReset.Max:
                    //case SerialNumberReset.AccountingYear:
                    if (nextNumber.ToString().Length > nums.Length)
                    {
                        prefix = IncrementAlpha(prefix);
                        nextNumber = 1;
                    }

                    break;

                case SerialNumberReset.Daily:
                    if (lastDate?.Day != DateTime.Today.Day)
                    {
                        prefix = IncrementAlpha(prefix);
                        nextNumber = 1;
                    }

                    break;

                case SerialNumberReset.Monthly:
                    if (lastDate?.Month != DateTime.Today.Month)
                    {
                        prefix = IncrementAlpha(prefix);
                        nextNumber = 1;
                    }

                    break;

                case SerialNumberReset.CalendarYear:
                    if (DateTime.Today.Year > lastDate?.Year)
                    {
                        prefix = IncrementAlpha(prefix);
                        nextNumber = 1;
                    }

                    break;

                case SerialNumberReset.AccountingYear: // 01/04/2019 - 31/03/2020
                                                       //var accountYear = await context.AccountYears
                                                       //    .FindAsync(yearId);
                    if (DateTime.Today > yearEnd)
                    {
                        prefix = IncrementAlpha(prefix);
                        nextNumber = 1;
                    }
                    break;
            }

            var sbSerialNumber =
                new StringBuilder($"{prefix}{format}{suffix}");

            sbSerialNumber.Replace("YYYY", DateTime.Today.ToString("yyyy"));
            sbSerialNumber.Replace("YY", DateTime.Today.ToString("yy"));
            sbSerialNumber.Replace("MMM", DateTime.Today.ToString("MMM").ToUpper());
            sbSerialNumber.Replace("MM", DateTime.Today.ToString("MM"));
            sbSerialNumber.Replace("DD", DateTime.Today.ToString("dd"));
            sbSerialNumber.Replace("JJJ", $"{DateTime.Today.DayOfYear:D3}");
            sbSerialNumber.Replace("HH", DateTime.Now.ToString("HH"));
            sbSerialNumber.Replace("MI", DateTime.Now.ToString("mm"));
            sbSerialNumber.Replace("SS", DateTime.Now.ToString("ss"));

            string nextSerial = nextNumber.ToString().PadLeft(nums.Length, '0');
            sbSerialNumber.Replace(nums, nextSerial);
            string nextValue = sbSerialNumber.ToString();
            return (nextValue, nextNumber);
        }

        public string IncrementAlpha(string alpha)
        {
            if (string.IsNullOrWhiteSpace(alpha))
            {
                return alpha;
            }

            alpha = alpha.ToUpper();

            int alphaLen = alpha.Length;
            char lastChar = alpha[alphaLen - 1];
            string next;

            if (lastChar == 'Z')
            {
                next = "A";
            }
            else if (lastChar >= 'A' && lastChar < 'Z')
            {
                next = Convert.ToString((char)(lastChar + 1));
            }
            else
            {
                next = Convert.ToString(lastChar);
            }

            if (alphaLen > 1)
            {
                string stripLast = alpha.Substring(0, alphaLen - 1);

                if (!(lastChar >= 'A' && lastChar <= 'Z'))
                {
                    //if (alphaLen > 1)
                    //{
                    //string stripLast = alpha.Substring(0, alphaLen - 1);
                    next = IncrementAlpha(stripLast) + lastChar;
                    //}
                    //else
                    //    next = Convert.ToString(lastChar);
                }
                else if (lastChar == 'Z')
                {
                    next = IncrementAlpha(stripLast) + next;
                }
                else
                {
                    next = stripLast + next;
                }
            }

            return next;
        }

        #endregion Increment methods

        #region Repository methods

        public List<SerialNumber> GetAll(int yearId, string searchTerm = null)
        {
            using (var con = _db.GetConnection())
            {
                //if (string.IsNullOrEmpty(searchTerm))
                //{
                return con.Select<SerialNumber>(sn => sn.YearId == yearId)
                    .ToList();
                //}
                //else
                //{
                //    return con.Select<SerialNumber>(u =>
                //        u.YearId == yearId &&
                //         (u.Contains(searchTerm) ||
                //         u.UnitName.Contains(searchTerm) ||
                //         u.UnitDesc.Contains(searchTerm))
                //    ).ToList();
                //}
            }
        }

        public SerialNumber GetById(int id)
        {
            using (var con = _db.GetConnection())
            {
                return con.Get<SerialNumber>(id);
            }
        }

        public int Create(int yearId, SerialNumber entity)
        {
            using (var con = _db.GetConnection())
            {
                return Create(yearId, entity, con, null);
            }
        }

        public int Create(int yearId, SerialNumber entity,
            IDbConnection con, IDbTransaction tran)
        {
            entity.YearId = yearId;
            int serialId = Convert.ToInt32(con.Insert(entity, tran));
            return serialId;
        }

        public bool Update(int id, SerialNumber entity)
        {
            if (id <= 0 || id != entity.Id)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                return con.Update(entity);
            }
        }

        public bool Remove(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            using (var con = _db.GetConnection())
            {
                SerialNumber entity = con.Get<SerialNumber>(id);
                if (entity == null)
                {
                    return false;
                }

                return con.Delete(entity);
            }
        }

        #endregion Repository methods
    }
}

//public static class ExcelColumn
//{
//    public static int ToNumber(String name)
//    {
//        int number = 0;
//        for (int i = 0; i < name.Length; i++)
//        {
//            number = number * 26 + (name[i] - ('A' - 1));
//        }
//        return number;
//    }

//    public static String ToName(int number)
//    {
//        StringBuilder sb = new StringBuilder();
//        while (number-- > 0)
//        {
//            sb.Append((char)('A' + (number % 26)));
//            number /= 26;
//        }
//        return sb.ToString().Reverse().ToString();
//    }
//}

//var con = context.Database.GetDbConnection();
//var result = await con.ExecuteScalarAsync<string>("SELECT TOP 1 LastValue FROM SerialNumbers");
