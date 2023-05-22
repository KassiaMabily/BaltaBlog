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
      ReadUsers();
    }

    public static void ReadUsers()
    {
      var repository = new UserRepository();
      var users = repository.Get();

      foreach (var user in users)
        Console.WriteLine(user.Name);

    }

    public static void ReadUser()
    {
      using (var connection = new SqlConnection(CONNECTION_STRING))
      {
        var user = connection.Get<User>(1);
        Console.WriteLine(user.Name);
      }
    }

    public static void CreateUser()
    {
      var user = new User()
      {
        Bio = "Desenvolvedora FullStack",
        Email = "dev@fullstack.com",
        Image = "https://...",
        Name = "Uma dev aí",
        PasswordHash = "HASH",
        Slug = "uma-dev-ai"
      };
      using (var connection = new SqlConnection(CONNECTION_STRING))
      {
        connection.Insert<User>(user);
        Console.WriteLine("Cadastro realizado com sucesso");
      }
    }

    public static void UpdateUser()
    {
      var user = new User()
      {
        Id = 2,
        Bio = "Desenvolvedora FullStack",
        Email = "dev@fullstack.com",
        Image = "https://...",
        Name = "DEV",
        PasswordHash = "HASH",
        Slug = "dev"
      };
      using (var connection = new SqlConnection(CONNECTION_STRING))
      {
        connection.Update<User>(user);
        Console.WriteLine("Atualização realizada com sucesso");
      }
    }

    public static void DeleteUser()
    {
      using (var connection = new SqlConnection(CONNECTION_STRING))
      {
        var user = connection.Get<User>(2);
        connection.Delete<User>(user);
        Console.WriteLine("Exclusão realizada com sucesso");
      }
    }
  }
}
