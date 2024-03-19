using Microsoft.Data.SqlClient;

namespace App_Blog;

class Program
{
    private const string CONNECTION_STRING = "Server=localhost,1433;Database=Blog;User ID=sa;Password=MyPassword123#;";
    static void Main(string[] args)
    {
        
    }

    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            
        }
    }
    
}