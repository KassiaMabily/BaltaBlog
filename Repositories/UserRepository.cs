using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository
    {
        public IEnumerable<User> Get()
        {
            using var connection = new SqlConnection("");
            return connection.GetAll<User>();
        }

        public User Get(int id)
        {
            using var connection = new SqlConnection("");
            return connection.Get<User>(id);
        }

        public void Create(User user)
        {
            using var connection = new SqlConnection("");
            connection.Insert<User>(user);
        }
    }
}
