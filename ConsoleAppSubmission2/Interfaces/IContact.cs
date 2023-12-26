namespace ConsoleAppSubmission2.Interfaces
{

    //Interface för kontakt-modellen
    public interface IContact
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string StreetAddress { get; set; }
    }
}