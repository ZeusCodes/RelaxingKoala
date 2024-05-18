using System;
using System.Collections.Generic;

namespace RestaurantProject
{
    public class Order
    {
        // Properties to store order details
        private List<MenuItem> selectedItems;
        private Customer customer;

        // Constructor to initialize order
        public Order(Customer customer, List<MenuItem> selectedItems)
        {
            this.selectedItems = selectedItems;
            this.customer = customer;
        }

        // Method to show the selected items and total bill
        public void ShowInvoice()
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("Customer Details:");
            Console.WriteLine("---------------------------------------");

            customer.DisplayInfo();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("\nOrder Items:");
            Console.WriteLine("---------------------------------------");

            foreach (var item in selectedItems)
            {
                item.DisplayInfo();
            }
            Console.WriteLine("---------------------------------------");

            decimal totalBill = CalculateTotalBill();
            Console.WriteLine($"\nTotal Bill: {totalBill.ToString("C")}");
            Console.WriteLine("---------------------------------------");

        }

        // Method to calculate the total bill
        private decimal CalculateTotalBill()
        {
            decimal total = 0;
            foreach (var item in selectedItems)
            {
                total += item.Price;
            }
            return total;
        }

        // Method to request payment
        public void makePayment()
        {
            // Logic to request payment
            // This is a stub implementation for demonstration purposes
            Console.WriteLine("Payment requested.");
        }
    }
}
