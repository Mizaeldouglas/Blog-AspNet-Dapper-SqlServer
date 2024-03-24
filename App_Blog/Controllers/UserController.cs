using System.Data;
using App_Blog.Models;
using App_Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace App_Blog.Controllers;

public class UserController
{
    public static void GetAllUsers(SqlConnection connection)
    {
        var repository = new UserRepository(connection);
        var users = repository.GetAll();

        foreach (var user in users)
        {
            Console.WriteLine($"Nome: {user.Name}");
            Console.WriteLine($"Sobre: {user.Bio}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine();
        }
    }

    public static void GetByIdUser(SqlConnection connections)
    {
        var repository = new UserRepository(connections);
        Console.WriteLine("Enter Id");
        var byId = Console.ReadLine();

        if (byId != null)
        {
            var users = repository.GetById(int.Parse(byId));

            Console.WriteLine($"Nome: {users.Name}");
            Console.WriteLine($"Sobre: {users.Bio}");
            Console.WriteLine($"Email: {users.Email}");
            Console.WriteLine();
        }
    }

    public static void CreateUser(SqlConnection connection)
    {
        var user = new User();

        Console.WriteLine("Enter Name: ");
        user.Name = Console.ReadLine()!;

        Console.WriteLine("Enter Email: ");
        user.Email = Console.ReadLine()!;

        Console.WriteLine("Enter Bio: ");
        user.Bio = Console.ReadLine()!;

        Console.WriteLine("Enter link image: ");
        user.Image = Console.ReadLine()!;

        Console.WriteLine("Enter Slug: ");
        user.Slug = Console.ReadLine()!;

        Console.WriteLine("Enter PasswordHash: ");
        user.PasswordHash = Console.ReadLine()!;


        var users = connection.Insert<User>(user);

        Console.WriteLine("Cadastro feito com sucesso!!");
    }
    
    public static void UpdateUser(SqlConnection connection)
    {
        var repository = new UserRepository(connection);

        Console.WriteLine("Digite o ID do usuário que você deseja atualizar:");
        var userId = int.Parse(Console.ReadLine());

        var user = repository.GetById(userId);

        if (user == null)
        {
            Console.WriteLine($"Usuário com ID {userId} não encontrado.");
            return;
        }

        Console.WriteLine($"Atualizando usuário {user.Name} ({userId}):");

        // Atualizar nome
        Console.WriteLine("Digite o novo nome:");
        user.Name = Console.ReadLine();

        // Atualizar email
        Console.WriteLine("Digite o novo email:");
        user.Email = Console.ReadLine();
        
        Console.WriteLine("Enter Bio: ");
        user.Bio = Console.ReadLine()!;

        Console.WriteLine("Enter link image: ");
        user.Image = Console.ReadLine()!;

        Console.WriteLine("Enter Slug: ");
        user.Slug = Console.ReadLine()!;

        Console.WriteLine("Enter PasswordHash: ");
        user.PasswordHash = Console.ReadLine()!;

        int rowsAffected = repository.Update(user);

        if (rowsAffected > 0)
        {
            Console.WriteLine("Atualização realizada com sucesso!");
        }
        else
        {
            Console.WriteLine("Falha ao atualizar o usuário. Verifique os dados e tente novamente.");
        }
    }
    
    public static void DeleteUser(SqlConnection connection)
    {
        Console.WriteLine("Digite o ID do usuário que deseja excluir:");
        int userId = int.Parse(Console.ReadLine());

        var user = connection.Get<User>(userId);
        if (user == null)
        {
            Console.WriteLine($"Usuário com ID {userId} não encontrado.");
            return;
        }
        
        connection.Delete<User>(user);

        Console.WriteLine($"Usuario {user.Name} deletado com sucesso!!");
    }
}
