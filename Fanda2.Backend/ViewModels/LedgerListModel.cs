namespace Fanda2.Backend.ViewModels
{
    public class LedgerListModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string LedgerName { get; set; }
        public string LedgerDesc { get; set; }
        public string GroupName { get; set; }
        public LedgerType LedgerType { get; set; }
        public string LedgerTypeString { get { return this.LedgerType.ToString(); } }
        public bool IsEnabled { get; set; }
    }
}