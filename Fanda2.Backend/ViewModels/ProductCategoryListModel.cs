namespace Fanda2.Backend.ViewModels
{
    public class ProductCategoryListModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public string ParentCategoryName { get; set; }
        public bool IsEnabled { get; set; }
        public int OrgId { get; set; }
    }
}
