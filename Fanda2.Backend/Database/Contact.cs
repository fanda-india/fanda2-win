namespace Fanda2.Backend.Database
{
    public class Contact
    {
        public int Id { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string WorkPhone { get; set; }
        public string MobileNumber { get; set; }
        //public bool IsPrimary { get; set; }

        public bool IsEmpty()
        {
            return string.IsNullOrWhiteSpace(Salutation) &&
                string.IsNullOrWhiteSpace(FirstName) &&
                string.IsNullOrWhiteSpace(LastName) &&
                string.IsNullOrWhiteSpace(Designation) &&
                string.IsNullOrWhiteSpace(Department) &&
                string.IsNullOrWhiteSpace(Email) &&
                string.IsNullOrWhiteSpace(WorkPhone) &&
                string.IsNullOrWhiteSpace(MobileNumber);
        }
    }
}