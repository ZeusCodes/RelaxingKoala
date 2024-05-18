using System;
namespace RestaurantProject
{
    public class MenuItem
    {
        // Properties to store information about a menu item
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Default constructor
        public MenuItem() { }

        // Parameterized constructor to initialize properties
        public MenuItem(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        // Method to display menu item's information
        public void DisplayInfo()
        {
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Price: " + Price.ToString("C")); // Format as currency
        }
    }
}