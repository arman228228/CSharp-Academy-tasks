using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main()
        {
            const int totalContact = 3;
            Contact[] contact = new Contact[totalContact];

            for (int i = 0; i < totalContact; i++)
            {
                contact[i] = new Contact();
                
                //
                
                Console.WriteLine($"\nEnter #{i + 1} contact details:");
                
                //
                Console.WriteLine($"Enter Name:");
                contact[i].Name = Console.ReadLine();
                
                //
                Console.WriteLine($"Enter Phone Number:");
                contact[i].PhoneNumber = int.Parse(Console.ReadLine());
                
                //
                Console.WriteLine($"Enter Email:");
                contact[i].Email = Console.ReadLine();
            }
            
            Console.WriteLine($"\n\nContacts details added, use search:");

            string searchContact = Console.ReadLine();
            bool found = false;
            
            for (int i = 0; i < totalContact; i++)
            {
                if (searchContact.Equals(contact[i].Name))
                {
                    Console.WriteLine($"Found contact #{i + 1}:\n");
                    contact[i].DisplayInfo();

                    found = true;

                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }

    class Contact
    {
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"Contact details:\nName: {Name}\nPhoneNumber: {PhoneNumber}\nEmail: {Email}");
        }
    }
}