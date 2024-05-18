using System;
namespace RestaurantProject
{
    //public interface Person
    //{

    //}
    public class Person
    {
        // Properties to store common information about a person
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Default constructor
        public Person() { }

        // Parameterized constructor to initialize properties
        public Person(string name, string address, string email, string phoneNumber)
        {
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        // Method to display person's information
        public void DisplayInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Address: " + Address);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Phone Number: " + PhoneNumber);
        }
    }
}


