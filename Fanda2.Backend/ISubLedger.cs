using Fanda2.Backend.Database;

namespace Fanda2.Backend
{
    internal interface ISubLedger
    {
        int LedgerId { get; set; }
        int? AddressId { get; set; }
        int? ContactId { get; set; }

        Address Address { get; set; }
        Contact Contact { get; set; }

        bool IsEmpty();
    }
}
