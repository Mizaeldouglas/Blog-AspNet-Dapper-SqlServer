using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace App_Blog.Repositories.Role;

using App_Blog.Models;

public class RoleRepository : IRoleRepository
{
    private readonly SqlConnection _connection;

    public RoleRepository(SqlConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Role> GetAll() => _connection.GetAll<Role>();

    public Role GetById(int id) => _connection.Get<Role>(id);

    public long Create(Role role) => _connection.Insert<Role>(role);

    public int Update(Role role)
    {
        int rowsAffected =
            _connection.Execute(
                "UPDATE [User] SET Name = @Name, Email = @Email, Bio = @Bio, Image = @Image, Slug = @Slug, PasswordHash = @PasswordHash WHERE Id = @Id",
                role);
        return rowsAffected;
    }

    public int Delete(int id)
    {
        int rowsAffected = _connection.Execute("DELETE FROM [User] WHERE Id = @Id", new { Id = id });
        return rowsAffected; // Return the number of affected rows
    }
}