using ConsoleAppSubmission2.Models;

namespace ConsoleAppSubmission2.Interfaces;

public interface IContactService
{
    void CreateNewContact(Contact contact);
    Contact GetContact(string email);
    IEnumerable<Contact> GetContacts();
    bool DeleteContact(string email);
}
