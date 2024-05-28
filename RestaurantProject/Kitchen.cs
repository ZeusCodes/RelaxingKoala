using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantProject
{
    public class Kitchen
    {
        private List<List<MenuItem>> listOfOrders;
        private string previousContentHash = null;

        public Kitchen()
        {
            listOfOrders = new List<List<MenuItem>>();
        }

        public List<List<MenuItem>> ShowOrders()
        {
            //Change the Text File Directory According to your Computer
            string filePath = "/Users/pallabpaul/Desktop/Pallab Paul/University/Sem6/SoftArch/Assignment3/RestaurantProject/RestaurantProject/OrdersToKitchen.txt";
            try
            {
                string content = File.ReadAllText(filePath);
                string currentContentHash = CalculateHash(content);

                if (currentContentHash != previousContentHash)
                {
                    listOfOrders.Clear();
                    // Content has changed, process it
                    //Console.WriteLine($"Present Orders:\n{content}\n");

                    string[] orders = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string order in orders)
                    {
                        string[] itemsString = order.Split(';');
                        List<MenuItem> items = new List<MenuItem>();

                        foreach (string itemString in itemsString)
                        {
                            string[] parts = itemString.Split(',');
                            if (parts.Length == 2)
                            {
                                string id = parts[0];
                                string name = parts[1];
                                MenuItem item = new MenuItem(id, name, 0); // Set price to 0 for now
                                items.Add(item);
                            }
                        }
                        listOfOrders.Add(items);
                    }
                    Console.WriteLine($"-------------Order List Updated!-------------");
                    Console.WriteLine("\n---------------------------------------\n---------------------------------------"); 

                    foreach (var order in listOfOrders)
                    {
                        int index = listOfOrders.IndexOf(order);
                        Console.Write($"--------------Order No: {index}--------------\nOrder Items: ");
                        foreach (var item in order)
                        {
                            Console.Write($"{item.Name} , ");
                        }                    Console.WriteLine("\n---------------------------------------\n---------------------------------------"); 

                        Console.WriteLine(); 
                    }
                    Console.WriteLine("\n---------------------------------------\n---------------------------------------"); 
                    previousContentHash = currentContentHash;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }

            return listOfOrders;
        }

        // Method to calculate hash of content
        private string CalculateHash(string content)
        {
            return content.GetHashCode().ToString();
        }

        public void Run()
        {
            ShowOrders();
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int result))
                {
                    RemoveServedOrder(result);
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid number.");
                }
            }
        }

        // Method to remove a served item from an order
        public void RemoveServedOrder(int index)
        {
            try
            {
                listOfOrders.RemoveAt(index);
                WriteUpdatedOrderList();
                Console.WriteLine($"Completed Order No {index}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing order from Queue: {ex.Message}");
            }
        }

        public void WriteUpdatedOrderList()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("/Users/pallabpaul/Desktop/Pallab Paul/University/Sem6/SoftArch/Assignment3/RestaurantProject/RestaurantProject/OrdersToKitchen.txt", false)) // Open the file in overwrite mode
                {
                    foreach (var order in listOfOrders)
                    {
                        string orderLine = "";
                        foreach (var item in order)
                        {
                            orderLine += $"{item.Id},{item.Name};";
                        }
                        writer.WriteLine(orderLine); // Write the order line to the file
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

    }
}
