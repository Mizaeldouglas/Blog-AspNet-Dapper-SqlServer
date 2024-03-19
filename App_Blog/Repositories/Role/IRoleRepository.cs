namespace App_Blog.Repositories.Role;
using App_Blog.Models;

public interface IRoleRepository
{
    long Create(Role role);
    Models.Role GetById(int id);
    IEnumerable<Models.Role> GetAll();
    int Update(Role role);
    int Delete(int id);
}