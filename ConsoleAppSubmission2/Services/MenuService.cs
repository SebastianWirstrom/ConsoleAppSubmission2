
using ConsoleAppSubmission2.Interfaces;
using ConsoleAppSubmission2.Models;


namespace ConsoleAppSubmission2.Services;

public interface IMenuService
{
    void ShowMainMenu();
}

public class MenuService : IMenuService
{
    private readonly IContactService _contactService = new ContactService();

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("    Main Menu    ");
            Console.WriteLine("____________________\n");
            Console.WriteLine("1. Create new contact");
            Console.WriteLine("2. Find contact by E-mail");
            Console.WriteLine("3. Show all contacts");
            Console.WriteLine("4. Delete existing contact");
            Console.WriteLine();
            Console.WriteLine("0. Exit Application");
            Console.WriteLine();
            Console.Write("Select an option to proceed: ");

            var option = Console.ReadLine()!;

            switch (option)
            {
                case "1":
                    ShowCreateNewContactMenu();
                    break;

                case "2":
                    ShowGetContactMenu();
                    break;

                case "3":
                    ShowGetContactsMenu();
                    break;

                case "4":
                    ShowDeleteContactMenu();
                    break;

                case "0":
                    ShowExitApplication();
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option selected. Press any key to try again!");
                    Console.ReadKey();
                    break;
            }
        }
    }
    private void ShowCreateNewContactMenu()
    {
        Contact contact = new Contact();
        Console.Clear();

        Console.WriteLine("Create a new contact");
        Console.WriteLine("____________________\n");

        Console.Write("First Name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Last Name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("E-mail: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Phone number: ");
        contact.Phone = Console.ReadLine() ?? "";

        Console.Write("Street Address: ");
        contact.StreetAddress = Console.ReadLine()!;

        _contactService.CreateNewContact(contact);

        Console.Clear();
        Console.WriteLine($"Your new contact:\n{contact.FirstName} {contact.LastName} <{contact.Email}>, Phone: {contact.Phone}, Address: {contact.StreetAddress}");

        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    private void ShowGetContactMenu()
    {
        Console.Clear();
        Console.WriteLine("Show contact information");
        Console.WriteLine("_______________________\n");

        Console.Write("Please enter an E-mail address to search for: ");
        var email = Console.ReadLine()!;

        var contact = _contactService.GetContact(email);

        if (contact != null)
        {
            Console.Clear();
            Console.WriteLine($"Contact found: \n{contact.FirstName} {contact.LastName} <{contact.Email}>, Phone: {contact.Phone}, Address: {contact.StreetAddress}");
        }
        else
        {
            Console.WriteLine("Contact not found, please try again.");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    private void ShowGetContactsMenu()
    {
        Console.Clear();
        Console.WriteLine("All contacts: ");
        Console.WriteLine("__________________________\n");

        var res = _contactService.GetContacts();
        
        if (res is List<Contact> listOfContacts)
        {
            if (!listOfContacts.Any())
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                foreach (var contact in listOfContacts)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} <{contact.Email}>");
                }
            }
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    private void ShowDeleteContactMenu()
    {
        Console.Clear();
        Console.WriteLine("Delete contact: ");
        Console.WriteLine("__________________________\n");

        Console.Write("Please enter the E-mail address of the contact you wish to delete: ");
        var email = Console.ReadLine()!;

        Console.Write("Are you sure you want to delete this contact? (y/n) ");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            var contactDelete = _contactService.DeleteContact(email);


            if (contactDelete)
            {
                Console.Clear();
                Console.WriteLine("Contact successfully deleted!");
            }
            else
            {
                Console.WriteLine("Contact not found, please try again.");
            }
        }
        Console.WriteLine();
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    private void ShowExitApplication()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit this application? (y/n) ");

        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }
}
