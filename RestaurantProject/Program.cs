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
            Console.WriteLine("Customer Screen");
            Customer c = new Customer();
            c.DetermineMenu();
        }
    }
}