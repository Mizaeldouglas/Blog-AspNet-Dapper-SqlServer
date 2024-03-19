using App_Blog.Models;

namespace App_Blog.Repositories;

public interface IUserRepository
{
    long Create(User user);
    User GetById(int id);
    IEnumerable<User> GetAll();
    int Update(User user);
    int Delete(int id);
}