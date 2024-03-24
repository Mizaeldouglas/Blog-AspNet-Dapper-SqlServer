
using App_Blog.Data;
using App_Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace App_Blog.Repositories;

public class UserRepository : IUserRepository
{
    
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<User> GetAll() => _connection.GetAll<User>();

    public User GetById(int id) => _connection.Get<User>(id);

    public long Create(User user) => _connection.Insert<User>(user);

    public int Update(User user)
    {
        int rowsAffected =
            _connection.Execute(
                "UPDATE [User] SET Name = @Name, Email = @Email, Bio = @Bio, Image = @Image, Slug = @Slug, PasswordHash = @PasswordHash WHERE Id = @Id",
                user);
        return rowsAffected;
    }
    
    public int Delete(int id)
    {
        int rowsAffected = _connection.Execute("DELETE FROM [User] WHERE Id = @Id", new { Id = id });
        return rowsAffected; // Return the number of affected rows
    }

}