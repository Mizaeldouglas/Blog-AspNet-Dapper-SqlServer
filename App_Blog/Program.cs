using App_Blog.Controllers;
using App_Blog.Models;
using App_Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace App_Blog;



class Program
    {
     private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=MyPassword123#;";

        static void Main(string[] args)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var repository = new Repository<User>(connection);

            // CreateUser(repository);
            // UpdateUser(repository);
            // DeleteUser(repository);
            // ReadUser(repository);
            // ReadUsers(repository);
            ReadWithRoles(connection);
        }

        private static void CreateUser(Repository<User> repository)
        {
            var user = new User
            {
                Bio = "8x Microsoft MVP",
                Email = "andre@balta.io",
                Image = "https://balta.io/andrebaltieri.jpg",
                Name = "André Baltieri",
                Slug = "andre-baltieri",
                PasswordHash = Guid.NewGuid().ToString()
            };

            repository.Create(user);
        }

        private static void ReadUsers(Repository<User> repository)
        {
            var users = repository.Read();
            foreach (var item in users)
                Console.WriteLine(item.Email);
        }

        private static void ReadUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            Console.WriteLine(user?.Email);
        }

        private static void UpdateUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            user.Email = "hello@balta.io";
            repository.Update(user);

            Console.WriteLine(user?.Email);
        }

        private static void DeleteUser(Repository<User> repository)
        {
            var user = repository.Read(2);
            repository.Delete(user);
        }

        private static void ReadWithRoles(SqlConnection connection)
        {
            var repository = new UsersRepository(connection);
            var users = repository.ReadWithRole();
        
            foreach (var user in users)
            {
                Console.WriteLine(user.Email);
                foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
            }
        }
    }


// class Program
// {
//     private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=MyPassword123#;";
//     
//     static void Main(string[] args)
//     {
//         var connection = new SqlConnection(CONNECTION_STRING);
//         connection.Open();
//         while (true)
//         {
//             Console.WriteLine("Sistema de gerenciamento de usuários");
//             Console.WriteLine("---------------------");
//             Console.WriteLine("1. Criar Usuário");
//             Console.WriteLine("2. Atualizar Usuário");
//             Console.WriteLine("3. Mostrar todos os Usuários");
//             Console.WriteLine("4. Mostra Usuário Por ID");
//             Console.WriteLine("5. Deletar Usuário");
//             Console.WriteLine("6. Sair");
//             Console.Write("Digite o número que deseja: ");    
//             
//             string choice = Console.ReadLine()!;
//
//             switch (choice)
//             {
//                 case "1":
//                     UserController.CreateUser(connection);
//                     break;
//                 case "2":
//                     UserController.UpdateUser(connection);
//                     break;
//                 case "3":
//                     UserController.GetAllUsers(connection);
//                     break;
//                 case "4":
//                     UserController.GetByIdUser(connection);
//                     break;
//                 case "5":
//                     UserController.DeleteUser(connection);
//                     break;
//                 case "6":
//                     Console.WriteLine("Saindo...");
//                     return;
//                 default:
//                     Console.WriteLine("Escolha inválida. Por favor, tente novamente.");
//                     break;
//             }
//
//             // Prompt to continue or exit
//             Console.WriteLine("\nVocê quer continuar? (s/n)");
//             string continueChoice = Console.ReadLine()!.ToLower();
//             if (continueChoice != "s")
//             {
//                 break;
//             }
//         }
//         connection.Close();
//
//         
//     }
//
//     
//     
// }