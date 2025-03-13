namespace Liv.InventorySystem.ConsoleApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public int LowStockThreshold { get; set; }

        public Product(int id, string name, int stockQuantity, decimal price, int lowStockThreshold)
        {
            Id = id;
            Name = name;
            StockQuantity = stockQuantity;
            Price = price;
            LowStockThreshold = lowStockThreshold;
        }

        public bool IsLowStock() => StockQuantity <= LowStockThreshold;
    }
}