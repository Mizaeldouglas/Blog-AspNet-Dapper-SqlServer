using App_Blog.Models;
using App_Blog.Repositories.Role;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace App_Blog.Controllers;

public class RoleController
{
    public static void GetAllUsers(SqlConnection connection)
    {
        var repository = new RoleRepository(connection);
        var roles = repository.GetAll();

        foreach (var role in  roles)
        {
            Console.WriteLine($"Nome: {role.Name}");
            Console.WriteLine($"Sobre: {role.Slug}");
            Console.WriteLine();
        }
    }

    public static void GetByIdUser(SqlConnection connections)
    {
        var repository = new RoleRepository(connections);
        Console.WriteLine("Enter Id");
        var byId = Console.ReadLine();

        if (byId != null)
        {
            var roles = repository.GetById(int.Parse(byId));

            Console.WriteLine($"Nome: {roles.Name}");
            Console.WriteLine($"Sobre: {roles.Slug}");
            Console.WriteLine();
        }
    }

    public static void CreateUser(SqlConnection connection)
    {
        var role = new Role();

        Console.WriteLine("Enter Name: ");
        role.Name = Console.ReadLine()!;

        Console.WriteLine("Enter Slug: ");
        role.Slug = Console.ReadLine()!;


        connection.Insert<Role>(role);

        Console.WriteLine("Cadastro feito com sucesso!!");
    }
    
    public static void UpdateUser(SqlConnection connection)
    {
        var repository = new RoleRepository(connection);

        Console.WriteLine("Digite o ID do usuário que você deseja atualizar:");
        var roleId = int.Parse(Console.ReadLine());

        var role = repository.GetById(roleId);

        if (role == null)
        {
            Console.WriteLine($"Usuário com ID {roleId} não encontrado.");
            return;
        }

        Console.WriteLine($"Atualizando usuário {role.Name} ({roleId}):");

        // Atualizar nome
        Console.WriteLine("Digite o novo nome:");
        role.Name = Console.ReadLine();

        Console.WriteLine("Enter Slug: ");
        role.Slug = Console.ReadLine()!;

        int rowsAffected = repository.Update(role);

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
        int roleId = int.Parse(Console.ReadLine());

        var role = connection.Get<Role>(roleId);
        if (role == null)
        {
            Console.WriteLine($"Usuário com ID {roleId} não encontrado.");
            return;
        }
        
        connection.Delete<Role>(role);

        Console.WriteLine($"Usuario {role.Name} deletado com sucesso!!");
    }
}