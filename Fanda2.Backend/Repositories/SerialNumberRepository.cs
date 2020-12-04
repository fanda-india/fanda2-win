using Dommel;

using Fanda2.Backend.Database;
using Fanda2.Backend.Enums;

using System;
using System.Linq;
using System.Text;

namespace Fanda2.Backend.Repositories
{
    public sealed class SerialNumberRepository
    {
        private readonly SQLiteDB _db;
        private static readonly object syncRoot = new object();

        public SerialNumberRepository()
        {
            _db = new SQLiteDB();
        }

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
                        return null;

                    int firstIndex = serialNumber.SerialFormat.IndexOf('N'); // YYJJJNNNNN = 5
                    int lastIndex = serialNumber.SerialFormat.LastIndexOf('N'); // YYJJJNNNNN = 9
                    string nums = serialNumber.SerialFormat.Substring(firstIndex, (lastIndex - firstIndex) + 1);

                    int nextNumber = serialNumber.LastNumber + 1;

                    switch (serialNumber.SerialReset)
                    {
                        case SerialNumberReset.Max:
                        case SerialNumberReset.AccountingYear:
                            if (nextNumber.ToString().Length > nums.Length)
                            {
                                nextNumber = 1;
                            }

                            break;

                        case SerialNumberReset.Daily:
                            if (serialNumber.LastDate.Day != DateTime.Today.Day)
                            {
                                nextNumber = 1;
                            }

                            break;

                        case SerialNumberReset.Monthly:
                            if (serialNumber.LastDate.Month != DateTime.Today.Month)
                            {
                                nextNumber = 1;
                            }

                            break;

                        case SerialNumberReset.CalendarYear:
                            if (DateTime.Today.Year > serialNumber.LastDate.Year)
                            {
                                nextNumber = 1;
                            }

                            break;
                            //case SerialNumberReset.AccountingYear: // 01/04/2019 - 31/03/2020
                            //                                       //var accountYear = await context.AccountYears
                            //                                       //    .FindAsync(yearId);
                            //    if (DateTime.Today > yearEnd)
                            //    {
                            //        nextNumber = 1;
                            //    }
                            //    break;
                    }

                    var sbSerialNumber =
                        new StringBuilder($"{serialNumber.SerialPrefix}{serialNumber.SerialFormat}{serialNumber.SerialSuffix}");

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

                    serialNumber.LastSerial = nextValue;
                    serialNumber.LastNumber = nextNumber;
                    serialNumber.LastDate = DateTime.Now;

                    con.Update(serialNumber);
                    return nextValue;
                }
            }
        }

        public string IncrementAlpha(string alpha)
        {
            if (string.IsNullOrWhiteSpace(alpha))
                return alpha;
            alpha = alpha.ToUpper();

            int alphaLen = alpha.Length;
            char lastChar = alpha[alphaLen - 1];
            string next;

            if (lastChar == 'Z')
                next = "A";
            //else if (!(lastChar >= 'A' && lastChar <= 'Z'))
            //{
            //    if (alphaLen > 1)
            //    {
            //        string stripLast = alpha.Substring(0, alphaLen - 1);
            //        next = IncrementAlpha(stripLast) + stripLast;
            //    }
            //    else
            //        next = Convert.ToString(lastChar);
            //}
            else
                next = Convert.ToString((char)(lastChar + 1));

            if (alphaLen > 1)
            {
                string stripLast = alpha.Substring(0, alphaLen - 1);
                if (lastChar == 'Z')
                    next = IncrementAlpha(stripLast) + next;
                else
                    next = stripLast + next;
            }

            return next;
        }
    }

    public static class ExcelColumn
    {
        public static int ToNumber(String name)
        {
            int number = 0;
            for (int i = 0; i < name.Length; i++)
            {
                number = number * 26 + (name[i] - ('A' - 1));
            }
            return number;
        }

        public static String ToName(int number)
        {
            StringBuilder sb = new StringBuilder();
            while (number-- > 0)
            {
                sb.Append((char)('A' + (number % 26)));
                number /= 26;
            }
            return sb.ToString().Reverse().ToString();
        }
    }
}

//var con = context.Database.GetDbConnection();
//var result = await con.ExecuteScalarAsync<string>("SELECT TOP 1 LastValue FROM SerialNumbers");
