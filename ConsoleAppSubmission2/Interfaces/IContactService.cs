namespace ConsoleAppSubmission2.Interfaces;

public interface IContactService
{
    void CreateNewContact(IContact contact);
    IEnumerable<IContact> GetContact(string email);
    IEnumerable<IContact> GetContacts();
    IEnumerable<IContact> DeleteContact(string email);
}
