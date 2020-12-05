namespace Fanda2.Backend.ViewModels
{
    public class UserListModel
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsEnabled { get; set; }
    }
}
