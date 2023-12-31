﻿using ConsoleAppSubmission2.Interfaces;
using ConsoleAppSubmission2.Models;
using Newtonsoft.Json;
using System.Diagnostics;
namespace ConsoleAppSubmission2.Services;

public class ContactService : IContactService
{
    //Lista för att spara kontakter
    private List<Contact> _contacts = [];

    //File service för att hantera och spara ner json-filen med kontaktlistan
    private readonly FileService _fileService = new FileService(@"c:\Projects\contacts.json");


    //skapa ny kontakt-method
    public bool CreateNewContact(Contact contact)
    {
        try
        {
            if (!_contacts.Any(c => c.Email == contact.Email))
            {
                _contacts.Add(contact);
                _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contacts));
                return true;
            }
            else
            {
                Console.WriteLine("Contact already exists!");
                return false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }

    //Hämta specifik kontakt-method
    public Contact GetContact(string email)
    {
        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
                var contact = _contacts.FirstOrDefault(c => c.Email == email);
                return contact!;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

        if (_contacts.Count == 0)
        {
            return null!;
        }
        return _contacts.FirstOrDefault()!;
    }

    //Hämta samtliga kontakter i listan-method
    public IEnumerable<Contact> GetContacts()
    {
        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
            }
            else
            {
                Console.WriteLine("No contacts found!");
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return _contacts;
    }

    //Ta bort kontakt från listan-method
    public bool DeleteContact(string email)
    {
        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contacts = JsonConvert.DeserializeObject<List<Contact>>(content)!;
                var contactToDelete = _contacts.FirstOrDefault(c => c.Email == email);

                if (contactToDelete != null)
                {
                    _contacts.Remove(contactToDelete);
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contacts));
                    Console.WriteLine("Contact deleted successfully!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Contact not found, try again!");
                    return false;
                }
            } 
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
        return false;
    }  
}
