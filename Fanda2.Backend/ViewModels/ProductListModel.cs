namespace Fanda2.Backend.ViewModels
{
    public class ProductListModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public string CategoryName { get; set; }
        public bool IsEnabled { get; set; }
        public int OrgId { get; set; }
    }
}
