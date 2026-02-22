using ContactsSolution.Buisiness;
using ContactsSolution.buisness;
using System;


namespace ContactsSolution
{
    internal class Program
    {

        private static void printContactInfo(ContactInfo contact)
        {
            Console.WriteLine($"ID: {contact.id}");
            Console.WriteLine($"First Name: {contact.firstName}");
            Console.WriteLine($"Last Name: {contact.lastName}");
            Console.WriteLine($"Email: {contact.email}");
            Console.WriteLine($"Phone Number: {contact.phoneNumber}");
            Console.WriteLine($"Address: {contact.address}");
            Console.WriteLine($"Date of Birth: {contact.dateOfBirth}");
            Console.WriteLine($"Country ID: {contact.countryId}");
            Console.WriteLine($"Image Path: {contact.imagePath}");
        }

        private static void findContactByID(int contactId)
        {
            ContactInfo contact = ContactsInfoBuisiness.GetContactInfoByID(contactId);
            if (contact != null)
            {
                printContactInfo(contact);
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }


        private static void createContact()
        {
            ContactInfo newContact = new ContactInfo();

            newContact.firstName = "John";
            newContact.lastName = "Doe";
            newContact.email = "johndoe@gmail.com";
            newContact.phoneNumber = "123-456-7890";
            newContact.address = "123 Main St, Anytown, USA";
            newContact.dateOfBirth = new DateTime(1990, 1, 1);
            newContact.countryId = 1;
            newContact.imagePath = "path/to/image.jpg";

            if (newContact.save()) 
            {
                Console.WriteLine("Contact created successfully.\n");
                printContactInfo(newContact);
            }
            else
            {
                Console.WriteLine("Failed to create contact.");
            }

        }

        private static void updateContact(int contactId)
        {
            ContactInfo contact = ContactsInfoBuisiness.GetContactInfoByID(contactId);
            if (contact != null)
            {
                contact.firstName = "Jane";
                contact.lastName = "Smith";
                contact.email = "noureddinebentaher@gmail.com";

                if (contact.save())
                {
                    Console.WriteLine("Contact updated successfully.\n");
                    printContactInfo(contact);

                }
                else
                {
                    Console.WriteLine("Failed to update contact.");
                }
            }
        }


        private static void deleteContact(int contactId)
        {
            ContactInfo contact = ContactsInfoBuisiness.GetContactInfoByID(contactId);
            if (contact != null)
            {
                if (ContactInfo.Delete(contactId))
                {
                    Console.WriteLine("Contact deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to delete contact.");
                }
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        static void Main(string[] args)
        {
           //findContactByID(1);
           //reateContact();
            //updateContact(1);
            deleteContact(9);
        }
    }
}
