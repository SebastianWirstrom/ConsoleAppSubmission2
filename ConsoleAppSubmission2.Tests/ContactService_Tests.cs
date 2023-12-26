using ConsoleAppSubmission2.Interfaces;
using ConsoleAppSubmission2.Models;
using ConsoleAppSubmission2.Services;

namespace ConsoleAppSubmission2.Tests;

public class ContactService_Tests
{

    //Test för att lägga till en kontakt i listan
    [Fact]
    public void CreateNewContactShould_AddNewCustomerToList_ThenReturnTrue()
    {

        //Arrange
        Contact contact = new()
        {
            FirstName = "FirstName_test",
            LastName = "LastName_test",
            Email = "Email_test",
            Phone = "Phone_test",
            StreetAddress = "StreetAddress_test"
        };
        IContactService contactService = new ContactService();

        //Act
        bool result = contactService.CreateNewContact(contact);

        //Assert
        Assert.True(result);
    }


    //Test för att hämta samtliga kontakter från listan
    [Fact]
    public void GetContactsShould_GetAllContactsFromList_ThenReturnList()
    {

        //Arrange
        IContactService contactService = new ContactService();

        //Act
        var result = contactService.GetContacts();

        //Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
    }
}

