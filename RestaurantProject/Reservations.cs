using System;
using System.IO;
using System.Collections.Generic;

namespace RestaurantProject
{
    public class Reservation
    {
        private bool[][] tableAvailability = new bool[12][]; // 35 tables available at a given time i

        public Reservation()
        {
            for(int i = 0; i < 12; i++)
            {
                tableAvailability[i] = new bool[35];
                for (int j=0;j<35;j++)
                {
                    tableAvailability[i][j] = true;
                }
            }
            RetrieveReservations();
        }

        public void RetrieveReservations()
        {
            //Change the Text File Directory According to your Computer
            string filePath = "/Users/pallabpaul/Desktop/Pallab Paul/University/Sem6/SoftArch/Assignment3/RestaurantProject/RestaurantProject/Reservations.txt";
            try
            {
                string content = File.ReadAllText(filePath);
                string[] reservations = content.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string reservation in reservations)
                {
                    string[] col = reservation.Split(',');
                    tableAvailability[int.Parse(col[2])][int.Parse(col[3])] = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }
        }


        // Method to check if any table is available
        public bool IsTableAvailable(int time)
        {
            time = time - 10;
            if (time > 11)
            {
                Console.WriteLine($"Invalid Time");
                return false;
            }
            foreach (bool isAvailable in tableAvailability[time])
            {
                if (isAvailable)
                {
                    Console.WriteLine("Table is available! Press y to Confirm Reservation");
                    return true;
                }
            }
            Console.WriteLine("Table is not available at given time! Press try another time");
            return false;
        }

        // Method to make a reservation for a customer
        public bool MakeReservation(Customer customer, int time)
        {
            time = time - 10;
            for (int j=0;j<35;j++)
            {
                if (tableAvailability[time][j])
                {
                    tableAvailability[time][j] = false;
                    WriteReservationToFile(customer, time,j);
                    Console.WriteLine($"Reservation made for customer {customer.Name} at table {j + 1}.");
                    return true;
                }
            }
            //Console.WriteLine("No tables available for reservation.");
            return false;
        }

        public void WriteReservationToFile(Customer customer, int time,int tableNo)
        {
            try
            {
                //Change the Text File Directory According to your Computer
                string fileDir = "/Users/pallabpaul/Desktop/Pallab Paul/University/Sem6/SoftArch/Assignment3/RestaurantProject/RestaurantProject/Reservations.txt";
                using (StreamWriter writer = new StreamWriter(fileDir, true)) // Open the file in append mode
                {
                    string reservation = "";
                    reservation += $"{customer.CustomerID},{customer.Name},{time},{tableNo}";
                    writer.WriteLine(reservation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }
    }
}
