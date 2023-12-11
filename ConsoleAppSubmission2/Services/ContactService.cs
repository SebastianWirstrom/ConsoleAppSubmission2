using ConsoleAppSubmission2.Interfaces;
namespace ConsoleAppSubmission2.Services;

public class ContactService : IContactService
{
    private List<IContact> _contacts = [];
    private readonly FileService _fileService = new FileService(@"c:\Projects\contracts.json");
    public void CreateNewContact(IContact contact)
    {
        
    }
    public IEnumerable<IContact> GetContact(string email)
    {

    }
    public IEnumerable<IContact> GetContacts()
    {
        
    }
    public IEnumerable<IContact> DeleteContact(string email)
    {
        
    }  
}
