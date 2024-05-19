using System;
using System.Collections.Generic;

namespace RestaurantProject
{
    public class Customer : Person
    {
        // Properties specific to a customer
        public string CustomerID { get; set; }
        public string StoredCardDetails { get; set; }

        // Default constructor
        public Customer() { }

        // Parameterized constructor to initialize properties
        public Customer(string name, string address, string email, string phoneNumber, string customerID, string storedCardDetails)
            : base(name, address, email, phoneNumber)
        {
            CustomerID = customerID;
            StoredCardDetails = storedCardDetails;
        }

        // Method to determine if the customer wants to make a reservation or order online
        public bool WantsToMakeReservation()
        {
            // Logic to determine if the customer wants to make a reservation
            // This is a stub implementation for demonstration purposes
            return true; // Placeholder
        }

        // Method to make a new profile for the customer
        public void CreateNewProfile(string name, string address, string email, string phoneNumber, string customerID, string storedCardDetails)
        {
            Name = name;
            Address = address;
            Email = email;
            PhoneNumber = phoneNumber;
            CustomerID = customerID;
            StoredCardDetails = storedCardDetails;
            Console.WriteLine("New customer profile created.");
        }

        // Method to determine which menu to show
        public void DetermineMenu()
        {
            Console.WriteLine("Please enter your desired menu:\nBreakfast\nLunch\nDinner\n");
            string menuType = Console.ReadLine();
            Menu m = new Menu();
            Dictionary<string, MenuItem> menu = m.ShowMenu(menuType);
            List<MenuItem> selectedItems = new List<MenuItem>();
            foreach (var item in menu.Values)
            {
                item.DisplayInfo();
                Console.WriteLine(); // Add a blank line between items
            }
            bool checkOut = false;
            do
            {
                Console.WriteLine("Please enter your desired item's id \t Or Checkout");
                string input = Console.ReadLine();
                if (input.ToLower() == "checkout")
                {
                    checkOut = true;
                    selectedItems = m.Checkout();
                } else
                {
                    m.SelectItem(input);
                }
            } while (checkOut != true);
            Order o = new Order(this, selectedItems);
            o.ShowInvoice();
            o.makePayment();
        }

        // Override the DisplayInfo method to include customer-specific details
        public new void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine("Customer ID: " + CustomerID);
            Console.WriteLine("Stored Card Details: " + StoredCardDetails);
        }
    }
}

