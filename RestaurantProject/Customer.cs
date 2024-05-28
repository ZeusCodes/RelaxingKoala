using System;
using System.IO;
using System.Collections.Generic;

namespace RestaurantProject
{
    public class Customer : Person
    {
        // Properties specific to a customer
        public string CustomerID { get; set; }
        public string StoredCardDetails { get; set; }
        public string Password { get; set; }

        // Default constructor
        public Customer() { }

        // Parameterized constructor to initialize properties
        public Customer(string name, string address, string email, string phoneNumber, string customerID, string storedCardDetails,string password)
            : base(name, address, email, phoneNumber)
        {
            Password = password;
            CustomerID = customerID;
            StoredCardDetails = storedCardDetails;
        }

        // Method to determine if the customer wants to make a reservation or order online
        public bool WantsToMakeReservation()
        {
            Reservation r = new Reservation();
            Console.WriteLine("The Restaurant is open from 10am to 10pm\nPlease enter your desired time for Reservation(in 24 hour clock)(reservations only allowed for 1hour):");
            for(int i = 0;i<5;i++)
            { 
                string timeInput = Console.ReadLine();
                if (int.TryParse(timeInput, out int time))
                {

                    if (r.IsTableAvailable(time))
                    {
                        string input = Console.ReadLine();
                        if (input.ToLower() == "y")
                        {
                            r.MakeReservation(this, time);
                            return true; // Placeholder
                        }
                    } 
                }
                else
                {
                    // Conversion failed
                    Console.WriteLine("Invalid input. Please enter a valid time.");
                    return WantsToMakeReservation();
                }
            }
            return false;
        }

        // Method to make a new profile for the customer
        public void CreateNewProfile()
        {
            Console.WriteLine("Enter Name");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Address");
            Address = Console.ReadLine();
            Console.WriteLine("Enter Email Id");
            Email = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Password");
            Password = Console.ReadLine();
            Console.WriteLine("Enter Card Details");
            StoredCardDetails = Console.ReadLine();
            CustomerID = (NoOfEntries()+1).ToString();
            WriteProfileToFile();
            Console.WriteLine("New customer profile created.");
        }

        public int NoOfEntries()
        {
            string fileDir = "/Users/pallabpaul/Desktop/Pallab Paul/University/Sem6/SoftArch/Assignment3/RestaurantProject/RestaurantProject/CustomerProfile.txt";
            string content = File.ReadAllText(fileDir);
            string[] profiles = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return profiles.Length;
        }

        public void WriteProfileToFile()
        {
            try
            {
                //Change the Text File Directory According to your Computer
                string fileDir = "/Users/pallabpaul/Desktop/Pallab Paul/University/Sem6/SoftArch/Assignment3/RestaurantProject/RestaurantProject/CustomerProfile.txt";
                using (StreamWriter writer = new StreamWriter(fileDir, true)) // Open the file in append mode
                {
                    string profile = "";
                    profile += $"{CustomerID},{Name},{Password},{Email},{PhoneNumber},{Address},{StoredCardDetails};";
                    Console.WriteLine($"Writing to File this: {profile}");
                    writer.WriteLine(profile);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
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

