using App_Blog.Models;
using App_Blog.Repositories.Role;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace App_Blog.Controllers;

public class RoleController
{
    public static void GetAllRoles(SqlConnection connection)
    {
        var repository = new RoleRepository(connection);
        var roles = repository.GetAll();

        foreach (var role in roles)
        {
            Console.WriteLine($"Nome: {role.Name}");
            Console.WriteLine($"Sobre: {role.Slug}");
            Console.WriteLine();
        }
    }

    public static void GetByIdRole(SqlConnection connections)
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

    public static void CreateRoles(SqlConnection connection)
    {
        var role = new Role();

        Console.WriteLine("Enter Name: ");
        role.Name = Console.ReadLine()!;

        Console.WriteLine("Enter Slug: ");
        role.Slug = Console.ReadLine()!;

        connection.Insert<Role>(role);

        Console.WriteLine("Cadastro feito com sucesso!!");
    }

    public static void UpdateRole(SqlConnection connection)
    {
        var role = new Role()
        {
            Id = 2,
            Name = "Suport",
            Slug = "equipe de suporte do mizael Douglas",
        };

       connection.Update<Role>(role);

        Console.WriteLine("Update feito com sucesso!!");
    }

    public static void DeleteRole(SqlConnection connection)
    {
        var role = connection.Get<Role>(1);
        connection.Delete<Role>(role);

        Console.WriteLine($"Usuario {role.Name} deletado com sucesso!!");
    }
}