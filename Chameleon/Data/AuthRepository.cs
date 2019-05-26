using Chameleon.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Linq;

namespace Chameleon.Data
{
    public static class AuthRepository
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlDataBase"].ConnectionString;

        public static User AuthUser(User user)
        {
            string sql = "SELECT EMAIL AS USERNAME, PASSWORD FROM user WHERE EMAIL = @email AND ACTIVE = 1";

            using (var conn = new MySqlConnection(connectionString))
            {
                return conn.Query<User>(sql, new { email = user.UserName }).FirstOrDefault();
            }
        }
    }
}
