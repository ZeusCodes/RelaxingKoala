using System;

namespace RestaurantProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Our Relaxing Koala Restaurant!");
            Customer c = new Customer();
            c.DetermineMenu();
        }
    }
}
