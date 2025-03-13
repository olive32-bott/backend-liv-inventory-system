using System;
using System.Collections.Generic;
using System.Linq;
using Liv.InventorySystem.ConsoleApp.Models;

namespace Liv.InventorySystem.ConsoleApp.Services
{
    public class ProductService
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(int id, string name, int stock, decimal price, int threshold)
        {
            products.Add(new Product(id, name, stock, price, threshold));
            Console.WriteLine("Product added successfully!");
        }

        public void UpdateProduct(int id, string newName, int newStock, decimal newPrice, int newThreshold)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = newName;
                product.StockQuantity = newStock;
                product.Price = newPrice;
                product.LowStockThreshold = newThreshold;
                Console.WriteLine("Product updated successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        public void DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully!");
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        public void DisplayProducts()
        {
            Console.WriteLine("\nID | Name | Stock | Price | Low Stock Alert");
            Console.WriteLine("-------------------------------------------");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id} | {product.Name} | {product.StockQuantity} | {product.Price:C} | {(product.IsLowStock() ? "⚠ LOW STOCK" : "OK")}");
            }
        }
    }
}
