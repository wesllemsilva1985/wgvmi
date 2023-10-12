using System.Configuration;

namespace wgvmi.Data
{
    public class UserRepository
    {
        private string connectionString;

        public UserRepository()
        {
            // Obtenha a string de conexão do arquivo de configuração
            connectionString = ConfigurationManager.ConnectionStrings["SuaStringDeConexao"].ConnectionString;
        }

        /* Desativado por enquanto
        // Adicionar um novo usuário ao banco de dados
        public bool AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);

                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
        */

        /* Desativado por enquanto
      // Obter um usuário pelo nome de usuário
      public User GetUserByUsername(string username)
      {
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
              connection.Open();

              string sql = "SELECT * FROM Users WHERE Username = @Username";
              SqlCommand command = new SqlCommand(sql, connection);
              command.Parameters.AddWithValue("@Username", username);

              using (SqlDataReader reader = command.ExecuteReader())
              {
                  if (reader.Read())
                  {
                      User user = new User
                      {
                          Username = reader["Username"].ToString(),
                          Email = reader["Email"].ToString(),
                          Password = reader["Password"].ToString()
                      };

                      return user;
                  }
              }
          }

          return null;
      }
        */
    }
}