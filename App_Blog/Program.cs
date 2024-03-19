using App_Blog.Controllers;
using Microsoft.Data.SqlClient;

namespace App_Blog;

class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=MyPassword123#;";
    
    static void Main(string[] args)
    {
        var connection = new SqlConnection(CONNECTION_STRING);
        connection.Open();
        while (true)
        {
            Console.WriteLine("User Management System");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Update User");
            Console.WriteLine("3. Read Users");
            Console.WriteLine("4. Read User by ID");
            Console.WriteLine("5. Delete User");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");    
            
            string choice = Console.ReadLine()!;

            switch (choice)
            {
                case "1":
                    UserController.CreateUser(connection);
                    break;
                case "2":
                    UserController.UpdateUser(connection);
                    break;
                case "3":
                    UserController.GetAllUsers(connection);
                    break;
                case "4":
                    UserController.GetByIdUser(connection);
                    break;
                case "5":
                    UserController.DeleteUser(connection);
                    break;
                case "6":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            // Prompt to continue or exit
            Console.WriteLine("\nDo you want to continue? (y/n)");
            string continueChoice = Console.ReadLine()!.ToLower();
            if (continueChoice != "y")
            {
                break;
            }
        }
        connection.Close();

        
    }

    
    
}