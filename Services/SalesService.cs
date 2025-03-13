using System;
using System.Collections.Generic;
using System.Linq;
using Liv.InventorySystem.ConsoleApp.Models;

namespace Liv.InventorySystem.ConsoleApp.Services
{
    public class SalesService
    {
        private List<Sale> sales = new List<Sale>();

        public void GenerateSalesReport(string period)
        {
            DateTime startDate = period == "daily" ? DateTime.Today : DateTime.Today.AddDays(-7);
            var filteredSales = sales.Where(s => s.DateSold >= startDate).ToList();

            Console.WriteLine($"\n{period.ToUpper()} SALES REPORT");
            Console.WriteLine("--------------------------------");
            foreach (var sale in filteredSales)
            {
                Console.WriteLine($"Product ID: {sale.ProductId}, Sold: {sale.QuantitySold}, Total: {sale.TotalPrice:C}, Date: {sale.DateSold}");
            }
        }
    }
}