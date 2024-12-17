using System;
using System.Collections.Generic;

namespace Rapid.SmartReport.Examples.Models
{
    public static class SampleData
    {
        public static List<SalesData> GetSampleSalesData()
        {
            return new List<SalesData>
            {
                new() { Date = DateTime.Now.AddDays(-5), Product = "Laptop", Amount = 1299.99m, Region = "North", Quantity = 2, Category = "Electronics" },
                new() { Date = DateTime.Now.AddDays(-4), Product = "Smartphone", Amount = 899.99m, Region = "South", Quantity = 3, Category = "Electronics" },
                new() { Date = DateTime.Now.AddDays(-3), Product = "Desk Chair", Amount = 199.99m, Region = "East", Quantity = 5, Category = "Furniture" },
                new() { Date = DateTime.Now.AddDays(-2), Product = "Coffee Maker", Amount = 79.99m, Region = "West", Quantity = 8, Category = "Appliances" },
                new() { Date = DateTime.Now.AddDays(-1), Product = "Headphones", Amount = 149.99m, Region = "North", Quantity = 4, Category = "Electronics" },
                new() { Date = DateTime.Now, Product = "Monitor", Amount = 349.99m, Region = "South", Quantity = 3, Category = "Electronics" },
                new() { Date = DateTime.Now.AddDays(-6), Product = "Desk", Amount = 299.99m, Region = "East", Quantity = 2, Category = "Furniture" },
                new() { Date = DateTime.Now.AddDays(-7), Product = "Keyboard", Amount = 89.99m, Region = "West", Quantity = 6, Category = "Electronics" },
                new() { Date = DateTime.Now.AddDays(-8), Product = "Mouse", Amount = 49.99m, Region = "North", Quantity = 10, Category = "Electronics" },
                new() { Date = DateTime.Now.AddDays(-9), Product = "Printer", Amount = 199.99m, Region = "South", Quantity = 2, Category = "Electronics" },
                new() { Date = DateTime.Now.AddDays(-10), Product = "Bookshelf", Amount = 159.99m, Region = "East", Quantity = 3, Category = "Furniture" },
                new() { Date = DateTime.Now.AddDays(-11), Product = "Microwave", Amount = 129.99m, Region = "West", Quantity = 4, Category = "Appliances" },
                new() { Date = DateTime.Now.AddDays(-12), Product = "Tablet", Amount = 499.99m, Region = "North", Quantity = 2, Category = "Electronics" },
                new() { Date = DateTime.Now.AddDays(-13), Product = "Office Chair", Amount = 249.99m, Region = "South", Quantity = 5, Category = "Furniture" },
                new() { Date = DateTime.Now.AddDays(-14), Product = "Filing Cabinet", Amount = 179.99m, Region = "East", Quantity = 2, Category = "Furniture" }
            };
        }
    }

    public class SalesData
    {
        public DateTime Date { get; set; }
        public string Product { get; set; } = "";
        public decimal Amount { get; set; }
        public string Region { get; set; } = "";
        public int Quantity { get; set; }
        public string Category { get; set; } = "";
    }
}
