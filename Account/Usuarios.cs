using Npgsql;

using System;
using System.Configuration;
using System.Text;

namespace wgvmi.Account
{
    public class Usuario
    {
        public int id { get; set; }
        public string nomeuser { get; set; }
        public string usuario { get; set; }
        public string email { get; set; }
        public string senhahash { get; set; }
        public DateTime datacadastro { get; set; }
        public string nivel { get; set; }
        public string sessao { get; set; }
        public bool ativo { get; set; }
        public DateTime ult_acesso { get; set; }
        public int tentativas_login { get; set; }
        public string token_reset_senha { get; set; }

        public class DadosUsuario
        {
            public string NomeUsuario { get; set; }
            public string Senha { get; set; }
            public string Email { get; set; }
        }

        // Verifica se o usuario existe no banco
        public static DadosUsuario LerUsuariosDaView(string usuario = null, string email = null)
        {
            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            DadosUsuario dadosUsuario = new DadosUsuario();

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                string sql = "SELECT * FROM tblUsername WHERE usuario = @Usuario OR email = @Usuario";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Usuario", usuario ?? (object)DBNull.Value);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dadosUsuario.NomeUsuario = reader.IsDBNull(reader.GetOrdinal("usuario")) ? string.Empty : reader.GetString(reader.GetOrdinal("usuario"));
                            dadosUsuario.Senha = reader.IsDBNull(reader.GetOrdinal("senhahash")) ? string.Empty : reader.GetString(reader.GetOrdinal("senhahash")); ;
                            dadosUsuario.Email = reader.IsDBNull(reader.GetOrdinal("email")) ? string.Empty : reader.GetString(reader.GetOrdinal("email")); ;
                        }
                    }
                }

                conn.Close();
            }

            return dadosUsuario;
        }

        public static bool AtualizarTokenRedefinicaoSenha(string email, string novoToken)
        {
            // Obtenha a string de conexão do arquivo de configuração
            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // SQL para atualizar o campo token_reset_senha na tabela usuarios
                string sql = "UPDATE usuarios SET token_reset_senha = @NovoToken WHERE email = @Email";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Parâmetros para a consulta SQL
                    cmd.Parameters.AddWithValue("@NovoToken", novoToken);
                    cmd.Parameters.AddWithValue("@Email", email);

                    // Execute a consulta SQL e obtenha o número de linhas afetadas
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Verifique se a atualização foi bem-sucedida com base no número de linhas afetadas
                    return rowsAffected > 0;
                }

                // Feche a conexão com o banco de dados
#pragma warning disable CS0162 // Código inacessível detectado
                conn.Close();
#pragma warning restore CS0162 // Código inacessível detectado
            }

            // Se algo der errado, retorne falso
            return false;
        }

        public static string GerarToken(int tamanho)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder tokenBuilder = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < tamanho; i++)
            {
                int index = random.Next(caracteresPermitidos.Length);
                tokenBuilder.Append(caracteresPermitidos[index]);
            }

            return tokenBuilder.ToString();
        }
    }
}