namespace Fanda2.Backend.ViewModels
{
    public class LedgerListModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string LedgerName { get; set; }
        public string LedgerDesc { get; set; }
        public string GroupName { get; set; }
        public LedgerType LedgerType { get; set; }
        public bool IsEnabled { get; set; }
    }
}