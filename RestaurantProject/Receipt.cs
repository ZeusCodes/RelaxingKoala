using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace RestaurantProject
{
    public class Receipt
    {
        // Property to store customer email
        private string CustomerEmail { get; set; }
        private List<MenuItem> selectedItems;
        private decimal amount;

        // Constructor to initialize the customer email
        public Receipt(decimal amount, string customerEmail, List<MenuItem> selectedItems)
        {
            this.amount = amount;
            this.CustomerEmail = customerEmail;
            this.selectedItems = selectedItems;
            SendReceipt();
        }

        // Method to create and send a receipt to the customer
        public void SendReceipt()
        {
            string receiptContent = GenerateReceiptContent();
            SendEmail(CustomerEmail, "Your Receipt", receiptContent);
        }

        // Private method to generate receipt content
        private string GenerateReceiptContent()
        {
            string reciept = $"-----------------------------------------------------------\n-----------------------------------------------------------\n Receipt\n-----------------------------------------------------------\n";
            reciept += $"Item ID   Item\t\t\tPrice\n\n";
            foreach (var item in selectedItems)
            {
                reciept += $"{item.Id}   {item.Name}\t\t\t\t{item.Price}\n";
            }
            reciept += "-----------------------------------------------------------\n";
            reciept += $"\nTotal Bill: {amount:C}\n";
            reciept += "-----------------------------------------------------------\n";
            reciept += "-----------------------------------------------------------\nThank You For Your Order!!";
            reciept += "-----------------------------------------------------------\n";
            Console.WriteLine(reciept);
            return reciept;
        }

        // Private method to send an email
        private void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage("your-email@example.com", toEmail);
                SmtpClient client = new SmtpClient
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.example.com",
                    Credentials = new System.Net.NetworkCredential("your-email@example.com", "your-password")
                };

                mail.Subject = subject;
                mail.Body = body;
                client.Send(mail);

                Console.WriteLine($"Receipt sent to {toEmail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send receipt: {ex.Message}");
            }
        }
    }
}
