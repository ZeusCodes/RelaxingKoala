using System;
using System.Collections.Generic;

namespace RestaurantProject
{
    public class Payments
    {
        // Properties to store customer card information and email
        //private int amount;
        private List<MenuItem> selectedItems;
        private readonly Customer customer;
        private readonly decimal amount;
        public readonly Receipt receipt=null;

        // Constructor to initialize payment details
        public Payments(Customer customer, List<MenuItem> selectedItems, decimal amount)
        {
            this.customer = customer;
            this.selectedItems = selectedItems;
            this.amount = amount;
            if (ProcessPayment(amount, customer.StoredCardDetails))
            {
                this.receipt = new Receipt(this.amount, this.customer.Email, this.selectedItems);
            }
        }

        // Method to process the payment with an external payment partner
        public bool ProcessPayment(decimal amount,String CardDetails)
        {
            Console.WriteLine("Processing payment through external payment partner...");
            Console.WriteLine($"Amount: {amount.ToString("C")}");
            do
            {
                Random random = new Random();
                int randomNumber = random.Next(100000, 1000000);
                Console.WriteLine($"\nRewrite Code Correctly to confirm payment...\t'{randomNumber}'");
                string input = Console.ReadLine();
                int number;
                if (int.TryParse(input, out number))
                {
                    if (number == randomNumber)
                    {
                        Console.WriteLine($"Payment processed successfully using card:\n {CardDetails}");
                        return true;
                    }
                }
                Console.WriteLine("Payment failed.\nTry Again or Exit");
            } while (Console.ReadLine().ToLower() != "exit");
            return false;
        }
    }
}
