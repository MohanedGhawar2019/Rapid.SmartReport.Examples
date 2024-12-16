namespace Rapid.SmartReport.Examples.Models;

public class SalesData
{
    public DateTime Date { get; set; }
    public string Product { get; set; }
    public decimal Amount { get; set; }
    public string Region { get; set; }
    public int Quantity { get; set; }
}

public static class SampleData
{
    public static List<SalesData> GetSampleSalesData()
    {
        return new List<SalesData>
        {
            new() { Date = DateTime.Now.AddDays(-5), Product = "Laptop", Amount = 1299.99m, Region = "North", Quantity = 3 },
            new() { Date = DateTime.Now.AddDays(-4), Product = "Monitor", Amount = 499.99m, Region = "South", Quantity = 5 },
            new() { Date = DateTime.Now.AddDays(-3), Product = "Mouse", Amount = 49.99m, Region = "East", Quantity = 10 },
            new() { Date = DateTime.Now.AddDays(-2), Product = "Keyboard", Amount = 99.99m, Region = "West", Quantity = 7 },
            new() { Date = DateTime.Now.AddDays(-1), Product = "Laptop", Amount = 1399.99m, Region = "North", Quantity = 2 },
            new() { Date = DateTime.Now, Product = "Monitor", Amount = 599.99m, Region = "South", Quantity = 4 }
        };
    }
}
