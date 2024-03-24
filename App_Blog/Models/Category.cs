using Dapper.Contrib.Extensions;

namespace App_Blog.Models;

[Table("[Category]")]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}