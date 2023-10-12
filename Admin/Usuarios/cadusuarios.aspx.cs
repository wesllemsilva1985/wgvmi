using Npgsql;

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace wgvmi.Admin.Usuarios
{
    public partial class cadusuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlGenero.Items.Add(new ListItem("Masculino", "Masculino"));
                ddlGenero.Items.Add(new ListItem("Feminino", "Feminino"));
                ddlGenero.Items.Add(new ListItem("Indefinido", "Indefinido"));
            }
        }

        protected bool VerificarEmailExistente(string email)
        {
            // Defina a conexão com o banco de dados
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Defina a consulta SQL para verificar se o email existe
                string query = "SELECT COUNT(*) FROM usuarios WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                // Abra a conexão
                connection.Open();

                // Execute a consulta e obtenha o resultado
                int count = (int)command.ExecuteScalar();

                // Se o resultado for maior que zero, o email já está cadastrado
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string sobrenome = txtSobrenome.Text;
            string genero = ddlGenero.SelectedValue;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            string confirmacaoSenha = txtConfirmacaoSenha.Text;

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Verificar se o email já está cadastrado
                    string verificaEmailSql = "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email";
                    using (NpgsqlCommand cmdVerificaEmail = new NpgsqlCommand(verificaEmailSql, connection))
                    {
                        cmdVerificaEmail.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(cmdVerificaEmail.ExecuteScalar());
                        if (count > 0)
                        {
                            lblMensagemErro.Text = "O email já está cadastrado. Por favor, escolha outro email.";
                            txtEmail.Focus();
                            return; // Impede o cadastro
                        }
                    }

                    // Continuar com o cadastro se o email não existe no banco
                    string sql = "INSERT INTO Usuarios (Nome, Sobrenome, Email, Genero, SenhaHash, TipoUsuario, Sessao) " +
                                 "VALUES (@Nome, @Sobrenome, @Email, @Genero, @SenhaHash, @TipoUsuario, @Sessao)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Sobrenome", sobrenome);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Genero", genero);

                        string senhaHash = GerarSenhaHash(senha);
                        cmd.Parameters.AddWithValue("@SenhaHash", senhaHash);

                        cmd.Parameters.AddWithValue("@TipoUsuario", "Corretor");
                        cmd.Parameters.AddWithValue("@Sessao", DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }

                divFormulario.Visible = false;
                divMensagemSucesso.Style.Add("display", "block");
            }
            catch (Exception ex)
            {
                lblMensagemErro.Text = "Ocorreu um erro: " + ex.Message;
            }
        }


        private string GerarSenhaHash(string senha)
        {
            // Implemente a lógica de geração de hash segura aqui.
            // Não armazene senhas em texto simples no banco de dados.
            // Use bibliotecas de hash seguras como BCrypt ou argon2.
            // Retorne o hash gerado.
            return senha;
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadusuarios.aspx");
        }
    }
}
