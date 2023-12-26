using ConsoleAppSubmission2.Models;

namespace ConsoleAppSubmission2.Interfaces;

//Interface för contact service-funktionaliteten
public interface IContactService
{
    bool CreateNewContact(Contact contact);
    Contact GetContact(string email);
    IEnumerable<Contact> GetContacts();
    bool DeleteContact(string email);
}
