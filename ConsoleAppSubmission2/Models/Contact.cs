using ConsoleAppSubmission2.Interfaces;
namespace ConsoleAppSubmission2.Models;


public class Contact : IContact
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
