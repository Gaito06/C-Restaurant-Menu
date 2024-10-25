using System;
using System.Collections.Generic;

public class MenuItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Category { get; set; } // e.g., Appetizer, Main Course, Dessert
    public bool IsNew { get; set; }

    public MenuItem(string name, decimal price, string description, string category, bool isNew)
    {
        Name = name;
        Price = price;
        Description = description;
        Category = category;
        IsNew = isNew;
    }
}

public class Menu
{
    public List<MenuItem> Items { get; private set; }
    public DateTime LastUpdated { get; private set; }

    public Menu()
    {
        Items = new List<MenuItem>();
        UpdateLastUpdated();
    }

    public void AddItem(MenuItem item)
    {
        Items.Add(item);
        UpdateLastUpdated(); // Update the last updated time
    }

    private void UpdateLastUpdated()
    {
        // Get the current time in UTC and convert it to CST
        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
        LastUpdated = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cstZone);
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Current Menu (Last updated: " + LastUpdated + "):");
        foreach (var item in Items)
        {
            Console.WriteLine("- " + item.Name + " (" + item.Category + ")");
            Console.WriteLine("  Price: " + item.Price.ToString("C"));
            Console.WriteLine("  Description: " + item.Description);
            Console.WriteLine("  New: " + (item.IsNew ? "Yes" : "No"));
            Console.WriteLine();
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Create a new menu
        Menu restaurantMenu = new Menu();

        // Add some menu items
        restaurantMenu.AddItem(new MenuItem("Bruschetta", 7.99m, "Grilled bread with tomatoes, garlic, and basil.", "Appetizer", true));
        restaurantMenu.AddItem(new MenuItem("Spaghetti Carbonara", 12.99m, "Pasta with creamy sauce, pancetta, and parmesan.", "Main Course", false));
        restaurantMenu.AddItem(new MenuItem("Chocolate Lava Cake", 5.99m, "Warm chocolate cake with a gooey center.", "Dessert", true));

        // Display the menu
        restaurantMenu.DisplayMenu();
    }
}
