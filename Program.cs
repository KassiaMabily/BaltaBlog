using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
  class Program
  {
    private const string CONNECTION_STRING = "Server=localhost,1432;Database=Blog;User ID=sa;Password=Serif@123;Trusted_Connection=False;Encrypt=False;MultipleActiveResultSets=true;";
    static void Main(string[] args)
    {
      ReadUsers();
    }

    public static void ReadUsers()
    {
      using (var connection = new SqlConnection(CONNECTION_STRING))
      {
        var users = connection.GetAll<User>();
        foreach (var user in users)
        {
          Console.WriteLine(user.Name);
        }
      }
    }
  }
}
