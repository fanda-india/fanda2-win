namespace Fanda2.Backend.ViewModels
{
    public class OrganizationListModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string OrgName { get; set; }
        public string OrgDesc { get; set; }
        public bool IsEnabled { get; set; }
    }
}