using System;
using Liv.InventorySystem.ConsoleApp.Services;
using Liv.InventorySystem.ConsoleApp.Models;

class Program
{
    static void Main()
    {
        UserService userService = new UserService();
        ProductService productService = new ProductService();
        SalesService salesService = new SalesService();

        Console.WriteLine(" Welcome to Inventory Management System");

        User loggedInUser = null;
        
        while (loggedInUser == null)
        {
            Console.Write(" Enter Username: ");
            string username = Console.ReadLine();
            Console.Write(" Enter Password: ");
            string password = Console.ReadLine();

            loggedInUser = userService.AuthenticateUser(username, password);

            if (loggedInUser == null)
            {
                Console.WriteLine("Invalid credentials. Try again.");
            }
        }

        Console.WriteLine($" Login successful! Welcome, {loggedInUser.Username} ({loggedInUser.Role})");

        while (true)
        {
            Console.WriteLine("\nInventory Management Menu");
            if (loggedInUser.Role == "Admin")
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Display Products");
            }
            Console.WriteLine("5. Generate Sales Report");
            Console.WriteLine("6. Logout");
            Console.Write(" Choose an option: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1" when loggedInUser.Role == "Admin":
                    Console.Write("Enter Product ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Stock Quantity: ");
                    int stock = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Price: ");
                    decimal price = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter Low Stock Threshold: ");
                    int threshold = Convert.ToInt32(Console.ReadLine());

                    productService.AddProduct(id, name, stock, price, threshold);
                    break;

                case "2" when loggedInUser.Role == "Admin":
                    Console.Write("Enter Product ID to Update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter New Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter New Stock Quantity: ");
                    int newStock = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter New Price: ");
                    decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Enter New Low Stock Threshold: ");
                    int newThreshold = Convert.ToInt32(Console.ReadLine());

                    productService.UpdateProduct(updateId, newName, newStock, newPrice, newThreshold);
                    break;

                case "3" when loggedInUser.Role == "Admin":
                    Console.Write("Enter Product ID to Delete: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    productService.DeleteProduct(deleteId);
                    break;

                case "4" when loggedInUser.Role == "Admin":
                    productService.DisplayProducts();
                    break;

                case "5":
                    Console.Write("Generate (daily/weekly) report? ");
                    string period = Console.ReadLine().ToLower();
                    salesService.GenerateSalesReport(period);
                    break;

                case "6":
                    Console.WriteLine("Logging out...");
                    return;

                default:
                    Console.WriteLine(loggedInUser.Role == "Salesperson"
                        ? "Unauthorized: Only Admins can access this option."
                        : "Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
}
