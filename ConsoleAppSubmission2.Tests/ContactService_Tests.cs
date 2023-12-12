using ConsoleAppSubmission2.Interfaces;
using ConsoleAppSubmission2.Models;
using ConsoleAppSubmission2.Services;

namespace ConsoleAppSubmission2.Tests;

public class ContactService_Tests
{
    [Fact]
    public void CreateNewContactShould_AddNewCustomerToList_ThenReturnTrue()
    {
        // arrange
        Contact contact = new()
        {
            FirstName = "FirstName_test",
            LastName = "LastName_test",
            Email = "Email_test",
            Phone = "Phone_test",
            StreetAddress = "StreetAddress_test"
        };
        IContactService contactService = new ContactService();

        // act
        bool result = contactService.CreateNewContact(contact);

        // assert
        Assert.True(result);
    }

    [Fact]
    public void GetContactsShould_GetAllContactsFromList_ThenReturnList()
    {
        // arrange
        IContactService contactService = new ContactService();

        // act
        var result = contactService.GetContacts();

        // assert
        Assert.NotNull(result);
        Assert.True(result.Any());
    }
}

