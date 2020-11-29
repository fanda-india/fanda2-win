using System;

namespace Fanda2.Backend.Database
{
    public class SerialNumber
    {
        // YY, YYYY, MM, MMM, DD
        // JJJ
        // N, NNN
        // HH, MI, SS, -- MS

        public Guid YearId { get; set; }

        public SerialNumberModule SerialModule { get; set; }
        public string SerialPrefix { get; set; }
        public string SerialFormat { get; set; }
        public string SerialSuffix { get; set; }
        public string LastValue { get; set; }
        public int LastNumber { get; set; }
        public DateTime LastDate { get; set; }
        public SerialNumberReset SerialReset { get; set; }
    }
}