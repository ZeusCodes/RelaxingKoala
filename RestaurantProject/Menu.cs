using System;
using System.Collections.Generic;
namespace RestaurantProject
{
    public class Menu
    {
        // Dictionaries to store menu items for different meal types
        private Dictionary<string, MenuItem> breakfastMenuItems;
        private Dictionary<string, MenuItem> lunchMenuItems;
        private Dictionary<string, MenuItem> dinnerMenuItems;
        private Dictionary<string, MenuItem> menuToSelectFrom;
        private List<MenuItem> selectedItems;

        // Default constructor to initialize the menu
        public Menu()
        {
            breakfastMenuItems = new Dictionary<string, MenuItem>();
            lunchMenuItems = new Dictionary<string, MenuItem>();
            dinnerMenuItems = new Dictionary<string, MenuItem>();
            selectedItems = new List<MenuItem>();
            PopulateMenus();
        }

        // Method to populate the menus with sample items
        private void PopulateMenus()
        {
            // Adding breakfast items
            breakfastMenuItems.Add("B01", new MenuItem("B01", "Pancakes", 5.99m));
            breakfastMenuItems.Add("B02", new MenuItem("B02", "Omelette", 6.99m));
            breakfastMenuItems.Add("B03", new MenuItem("B03", "French Toast", 5.49m));
            breakfastMenuItems.Add("B04", new MenuItem("B04", "Bagel with Cream Cheese", 3.99m));
            breakfastMenuItems.Add("B05", new MenuItem("B05", "Breakfast Burrito", 7.49m));
            breakfastMenuItems.Add("B06", new MenuItem("B06", "Smoothie", 4.99m));
            breakfastMenuItems.Add("B07", new MenuItem("B07", "Granola with Yogurt", 4.59m));
            breakfastMenuItems.Add("B08", new MenuItem("B08", "Scrambled Eggs", 3.99m));
            breakfastMenuItems.Add("B09", new MenuItem("B09", "Avocado Toast", 6.99m));
            breakfastMenuItems.Add("B10", new MenuItem("B10", "Fruit Salad", 4.49m));

            // Adding lunch items
            lunchMenuItems.Add("L01", new MenuItem("L01", "Cheeseburger", 8.99m));
            lunchMenuItems.Add("L02", new MenuItem("L02", "Grilled Chicken Sandwich", 7.99m));
            lunchMenuItems.Add("L03", new MenuItem("L03", "Caesar Salad", 6.99m));
            lunchMenuItems.Add("L04", new MenuItem("L04", "Turkey Club Sandwich", 8.49m));
            lunchMenuItems.Add("L05", new MenuItem("L05", "Vegetable Wrap", 7.49m));
            lunchMenuItems.Add("L06", new MenuItem("L06", "BLT Sandwich", 7.99m));
            lunchMenuItems.Add("L07", new MenuItem("L07", "Chicken Caesar Wrap", 8.49m));
            lunchMenuItems.Add("L08", new MenuItem("L08", "Minestrone Soup", 4.99m));
            lunchMenuItems.Add("L09", new MenuItem("L09", "Grilled Cheese Sandwich", 5.99m));
            lunchMenuItems.Add("L10", new MenuItem("L10", "Tuna Salad", 6.99m));

            // Adding dinner items
            dinnerMenuItems.Add("D01", new MenuItem("D01", "Spaghetti Bolognese", 12.99m));
            dinnerMenuItems.Add("D02", new MenuItem("D02", "Grilled Salmon", 15.99m));
            dinnerMenuItems.Add("D03", new MenuItem("D03", "Steak with Mashed Potatoes", 18.99m));
            dinnerMenuItems.Add("D04", new MenuItem("D04", "Chicken Alfredo", 14.99m));
            dinnerMenuItems.Add("D05", new MenuItem("D05", "Vegetable Stir Fry", 11.99m));
            dinnerMenuItems.Add("D06", new MenuItem("D06", "Beef Tacos", 10.99m));
            dinnerMenuItems.Add("D07", new MenuItem("D07", "Shrimp Scampi", 16.99m));
            dinnerMenuItems.Add("D08", new MenuItem("D08", "Lamb Chops", 19.99m));
            dinnerMenuItems.Add("D09", new MenuItem("D09", "BBQ Ribs", 17.99m));
            dinnerMenuItems.Add("D10", new MenuItem("D10", "Caesar Salad with Grilled Chicken", 12.49m));
        }

        // Method to show all menu items with their prices for a specific meal type
        public Dictionary<string, MenuItem> ShowMenu(string mealType)
        {
            menuToSelectFrom = mealType.ToLower() switch
            {
                "breakfast" => breakfastMenuItems,
                "lunch" => lunchMenuItems,
                "dinner" => dinnerMenuItems,
                _ => null
            };
            if (menuToSelectFrom == null)
            {
                Console.WriteLine("Invalid meal type. Please choose from 'breakfast', 'lunch', or 'dinner'.");
                ShowMenu(Console.ReadLine());
            }
            return menuToSelectFrom;
        }

        // Method to select items (by IDs) from a specific meal type and return the total price
        public void SelectItem(string item)
        {
            if (menuToSelectFrom.ContainsKey(item))
            {
                this.selectedItems.Add(menuToSelectFrom[item]);
                Console.WriteLine($"{menuToSelectFrom[item].Name} has been added to your order. Select More Items\n");
            }
            else
            {
                Console.WriteLine($"{item} is not available in the desired menu. Please Select Another Items\n");
            }
        }

        public List<MenuItem> Checkout()
        {
            return this.selectedItems;
        }
    }
}
