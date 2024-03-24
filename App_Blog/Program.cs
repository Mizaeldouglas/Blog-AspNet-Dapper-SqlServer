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
            Console.WriteLine("Sistema de gerenciamento de usuários");
            Console.WriteLine("---------------------");
            Console.WriteLine("1. Criar Usuário");
            Console.WriteLine("2. Atualizar Usuário");
            Console.WriteLine("3. Mostrar todos os Usuários");
            Console.WriteLine("4. Mostra Usuário Por ID");
            Console.WriteLine("5. Deletar Usuário");
            Console.WriteLine("6. Sair");
            Console.Write("Digite o número que deseja: ");    
            
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
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
                    break;
            }

            // Prompt to continue or exit
            Console.WriteLine("\nVocê quer continuar? (s/n)");
            string continueChoice = Console.ReadLine()!.ToLower();
            if (continueChoice != "s")
            {
                break;
            }
        }
        connection.Close();

        
    }

    
    
}