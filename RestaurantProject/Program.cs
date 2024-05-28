using System;
using System.Diagnostics;
using System.IO;

namespace RestaurantProject
{
    //class Program
    //{
    //    static void Main()
    //    {
    //        Customer c = new Customer();
    //        c.DetermineMenu();
    //    }
    //}
    class Program
    {
        Kitchen k = new Kitchen();
        static void Main(string[] args)
        {
            Program p = new Program();
            if (args.Length > 0)
            {
                if (args[0] == "customer")
                {

                    p.RunCustomerScreen();
                }
                else if (args[0] == "staff")
                {
                    p.RunStaffScreen();
                }
            }
            else
            {
                StartNewConsole("customer");
                StartNewConsole("staff");
            }
        }

        static void StartNewConsole(string role)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = $"run -- {role}",
                UseShellExecute = true
            };
            Process.Start(startInfo);
        }

        void RunStaffScreen()
        {
            Console.WriteLine("Staff Screen");
            while (true)
            {
                // Implement staff screen logic here
                k.Run();
                //System.Threading.Thread.Sleep(5000);
            }
        }

        void RunCustomerScreen()
        {
            Console.WriteLine("Welcome To Relaxing Koala!!\nPlease Press Y to make a reservation or Press M to see the menu to Order");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Customer c = null;
                Console.WriteLine("Press Y if You Have a Profile");
                string isRegistered = Console.ReadLine();
                if (isRegistered.ToLower() == "y")
                {
                    Console.WriteLine("Please Enter You Name and Password:");
                    string name = Console.ReadLine();
                    string password = Console.ReadLine();
                    c = RetrieveProfile(name, password);
                }
                if (isRegistered.ToLower() != "y" || c == null)
                {
                    Console.WriteLine("\nPlease Create a Profile to Continue");
                    c = new Customer();
                    c.CreateNewProfile();
                }
                c.WantsToMakeReservation();
            }
            if (input.ToLower() == "m")
            {
                Customer c=null;
                Console.WriteLine("Press Y if You Have a Profile");
                string isRegistered = Console.ReadLine();
                if (isRegistered.ToLower() == "y")
                {
                    Console.WriteLine("Please Enter You Name and Password:");
                    string name = Console.ReadLine();
                    string password = Console.ReadLine();
                    c = RetrieveProfile(name, password);
                }
                if(isRegistered.ToLower() != "y" || c == null)
                {
                    Console.WriteLine("\nContinuing as Guest User");
                    c = new Customer();
                }
                c.DetermineMenu();
            }

        }

        public Customer RetrieveProfile(string name, string pass)
        {
            string filePath = "/Users/pallabpaul/Desktop/Pallab Paul/University/Sem6/SoftArch/Assignment3/RestaurantProject/RestaurantProject/CustomerProfile.txt";
            try
            {
                string content = File.ReadAllText(filePath);
                string[] profiles = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string profile in profiles)
                {
                    string[] col = profile.Split(',');
                    if (col[1] == name && col[2] == pass)
                    {
                        Customer existingCustomer = new Customer(col[1], col[5], col[3], col[4], col[0], col[6], col[2]);
                        return existingCustomer;
                    }
                }
                Console.WriteLine("Could Not Find User!! Please Check Your Credentials");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
                return null;
            }
        }
    }
}