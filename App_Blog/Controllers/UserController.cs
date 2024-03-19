using App_Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace App_Blog.Controllers;

public class UserController
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=MyPassword123#;";
    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine($"Nome: {user.Name}");
                Console.WriteLine($"Sobre: {user.Bio}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine();


            }
        }
    }
    
    public static void ReadUser()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.Get<User>(1);

            Console.WriteLine(users.Name);
        }
    }
    
    public static void CreateUser()
    {

        var user = new User()
        {
            Bio = "Equipe Mizael",
            Name = "Equipe",
            Email = "email@email.com",
            Image = "image.png",
            Slug = "equipe de suporte",
            PasswordHash = "Hh247a8PASA@_FA9#2233#@"
        };
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.Insert<User>(user);

            Console.WriteLine("Cadastro feito com sucesso!!");
        }
    }
    
    public static void UpdateUser()
    {

        var user = new User()
        {
            Id = 2,
            Bio = "Suport Mizael",
            Name = "Suport",
            Email = "Suport@email.com",
            Image = "Suport.png",
            Slug = "equipe de suporte do mizael Douglas",
            PasswordHash = "Hh247a8asdasfasgha22124PASA@_FA9#2233#@"
        };
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.Update<User>(user);

            Console.WriteLine("Update feito com sucesso!!");
        }
    }
    
    public static void DeleteUser()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(1);
            connection.Delete<User>(user);

            Console.WriteLine($"Usuario {user.Name} deletado com sucesso!!");
        }
    }
}