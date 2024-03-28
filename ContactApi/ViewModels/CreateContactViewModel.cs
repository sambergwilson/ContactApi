namespace ContactApi.ViewModels
{
    public class CreateContactViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
    }
}
