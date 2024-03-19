namespace App_Blog.Data;

public class ConnectionString
{
    private static readonly string _connection = "Server=localhost,1433;Database=Blog;User ID=sa;Password=MyPassword123#;";
    
    public static string GetConnectionString()
    {
        return _connection;
    }
}