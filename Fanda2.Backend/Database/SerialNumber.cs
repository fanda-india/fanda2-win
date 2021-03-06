﻿using Fanda2.Backend.Enums;

using System;

namespace Fanda2.Backend.Database
{
    public class SerialNumber
    {
        // YY, YYYY, MM, MMM, DD
        // JJJ
        // N, NNN
        // HH, MI, SS, -- MS

        public int Id { get; set; }
        public SerialNumberModule SerialModule { get; set; }
        public string SerialPrefix { get; set; }
        public string SerialFormat { get; set; }
        public string SerialSuffix { get; set; }
        public string LastSerial { get; set; }
        public int LastNumber { get; set; }
        public DateTime LastDate { get; set; }
        public SerialNumberReset SerialReset { get; set; }
        public int YearId { get; set; }

        public SerialNumber Clone()
        {
            return (SerialNumber)MemberwiseClone();
        }
    }
}
