using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog
{
  class Program
  {
    private const string CONNECTION_STRING = "Server=localhost,1432;Database=Blog;User ID=sa;Password=Serif@123;Trusted_Connection=False;Encrypt=False;MultipleActiveResultSets=true;";
    static void Main(string[] args)
    {
      using var connection = new SqlConnection(CONNECTION_STRING);
      var repository = new Repository<User>(connection);

      ReadWithRoles(connection);
    }

    private static void ReadUsers(Repository<User> repository)
    {
      var users = repository.Read();
      foreach (var item in users)
        Console.WriteLine(item.Email);
    }

    private static void ReadUser(Repository<User> repository)
    {
      var user = repository.Read(2);
      Console.WriteLine(user?.Email);
    }

    private static void ReadWithRoles(SqlConnection connection)
    {
      var repository = new UserRepository(connection);
      var users = repository.ReadWithRole();

      foreach (var user in users)
      {
        Console.WriteLine(user.Email);
        foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
      }
    }
  }
}
