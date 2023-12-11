namespace ConsoleAppSubmission2.Interfaces
{
    public interface IContact
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string StreetAddress { get; set; }
    }
}