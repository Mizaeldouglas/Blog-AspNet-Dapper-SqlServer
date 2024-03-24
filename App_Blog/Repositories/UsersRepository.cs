using App_Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace App_Blog.Repositories;

public class UsersRepository : Repository<User>
{
    private readonly SqlConnection _connection;

    public UsersRepository(SqlConnection connection) : base(connection)
        => _connection = connection;

    public List<User> ReadWithRole()
    {
        var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

        var users = new List<User>();
        var items = _connection.Query<User, Models.Role, User>(
            query,
            (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    usr.Roles.Add(role);
                    users.Add(usr);
                }
                else
                    usr.Roles.Add(role);

                return user;
            }, splitOn: "Id");
        return users;
    }
}