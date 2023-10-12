using Npgsql; // Certifique-se de importar o namespace correto

using System;
using System.Web.UI.WebControls; // Importe esta biblioteca para usar controles da Web

namespace wgvmi.Imoveis
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // String de conexão do web.config
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

                // Configurar a conexão com o banco de dados PostgreSQL
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    // Definir a consulta SQL para recuperar registros da tabela "imoveis"
                    string query = "SELECT ID, Titulo, Tipo, estado, precovenda  FROM imoveis";

                    // Abrir a conexão com o banco de dados
                    connection.Open();

                    // Configurar o comando SQL
                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Dentro do método ExibirRegistrosDeImoveis
                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string id = reader["id"].ToString();
                                string tipo = reader["tipo"].ToString();
                                string titulo = reader["titulo"].ToString();
                                string estado = reader["estado"].ToString();
                                string valor = reader["precovenda"].ToString();

                                // Crie uma nova linha na tabela
                                TableRow row = new TableRow();

                                // Adicione as células (colunas) à linha
                                row.Cells.Add(new TableCell { Text = id });
                                row.Cells.Add(new TableCell { Text = titulo });
                                row.Cells.Add(new TableCell { Text = tipo });
                                row.Cells.Add(new TableCell { Text = estado });
                                row.Cells.Add(new TableCell { Text = valor });

                                // Preencha os controles Label na página com os dados recuperados
                                lblID.Text = id;
                                lblTipo.Text = titulo;
                                lblTitulo.Text = tipo;
                                lblEstado.Text = estado;
                                lblValor.Text = valor;
                            }
                        }
                    }
                }
            }
        }
    }
}