using System.ComponentModel.DataAnnotations.Schema;

namespace App_Blog.Models;

[Table("[Role]")]
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    
}