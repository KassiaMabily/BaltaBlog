using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
  class Program
  {
    private const string CONNECTION_STRING = "Server=localhost,1432;Database=Blog;User ID=sa;Password=Serif@123;Trusted_Connection=False;Encrypt=False;MultipleActiveResultSets=true;";
    static void Main(string[] args)
    {
      var connection = new SqlConnection(CONNECTION_STRING);
      connection.Open();
      ReadUsers(connection);
      ReadRoles(connection);
      connection.Close();
    }

    public static void ReadUsers(SqlConnection connection)
    {
      var repository = new Repository<User>(connection);
      var users = repository.Read();

      foreach (var user in users)
        Console.WriteLine(user.Name);

    }

    public static void ReadRoles(SqlConnection connection)
    {
      var repository = new Repository<Role>(connection);
      var roles = repository.Read();

      foreach (var role in roles)
        Console.WriteLine(role.Name);

    }


  }
}
