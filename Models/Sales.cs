using System;

namespace Liv.InventorySystem.ConsoleApp.Models
{
    public class Sale
    {
        public int ProductId { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateSold { get; set; }

        public Sale(int productId, int quantitySold, decimal totalPrice, DateTime dateSold)
        {
            ProductId = productId;
            QuantitySold = quantitySold;
            TotalPrice = totalPrice;
            DateSold = dateSold;
        }
    }
}