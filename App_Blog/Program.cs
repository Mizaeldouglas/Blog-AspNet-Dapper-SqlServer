using App_Blog.Controllers;
using App_Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace App_Blog;

class Program
{
    
    static void Main(string[] args)
    {
        UserController.CreateUser();
        // UserController.UpdateUser();
        // UserController.ReadUsers();
        // UserController.DeleteUser();
        // UserController.ReadUser();
    }

    
    
}