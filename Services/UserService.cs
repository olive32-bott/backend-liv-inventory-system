using System.Collections.Generic;
using System.Linq;
using Liv.InventorySystem.ConsoleApp.Models;

namespace Liv.InventorySystem.ConsoleApp.Services
{
    public class UserService
    {
        private List<User> users = new List<User>
        {
            new User(1, "Admin", "1234", "Admin"),
            new User(2, "Salesperson", "1235", "Salesperson")
        };

        public User AuthenticateUser(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}