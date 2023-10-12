using Npgsql; // Pacote Npgsql para interagir com o PostgreSQL

using System;
using System.Configuration; // Adicione esta referência
using System.IO; // Adicione esta referência para manipular o arquivo

using wgvmi.Admin.Models;

namespace wgvmi.Admin.Imoveis
{
    public partial class CadastroImoveis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            // Recuperar os valores dos campos do formulário
            string titulo = txtTitulo.Text;
            string tipo = ddlTipo.SelectedValue;
            string cidade = txtCidade.Text;
            string bairro = txtBairro.Text;
            string estado = ddlEstado.SelectedValue;
            string endereco = txtEndereco.Text;
            string precovenda = txtPrecoVenda.Text;
            string descricao = txtDescricao.Text;

            string fotocapa = "/Admin/Imoveis/Img/thumSemFoto.jpg"; // Nome padrão da imagem

            // Verifique se um arquivo de imagem foi carregado
            if (fileUpload.HasFile)
            {
                // Caminho onde a imagem será salva (você pode configurar isso conforme necessário)
                string caminhoSalvar = Server.MapPath("/Imoveis/Imagens/Capas/"); // Substitua pelo caminho real

                // Combine o caminho com o nome do arquivo de imagem
                string caminhoCompleto = Path.Combine(caminhoSalvar, fileUpload.FileName);

                // Salve o arquivo de imagem no servidor
                fileUpload.SaveAs(caminhoCompleto);

                // Recupere o caminho relativo da imagem para salvar no banco de dados
                fotocapa = fileUpload.FileName;
            }

            // Recuperar a string de conexão do web.config
            string connString = ConfigurationManager.ConnectionStrings["PostgreSQLConn"].ConnectionString;

            // Crie uma conexão com o banco de dados usando NpgsqlConnection
            using (NpgsqlConnection conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Crie um comando SQL para inserir os dados na tabela "imoveis"
                string sql = "INSERT INTO imoveis (titulo, tipo, cidade, bairro, estado, endereco, precovenda, descricao, fotocapa, datainserido) VALUES (@titulo, @tipo, @cidade, @bairro, @estado, @endereco, @precovenda, @descricao, @fotocapa, current_timestamp)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@titulo", titulo);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@cidade", cidade);
                    cmd.Parameters.AddWithValue("@bairro", bairro);
                    cmd.Parameters.AddWithValue("@estado", estado);
                    cmd.Parameters.AddWithValue("@endereco", endereco);
                    cmd.Parameters.AddWithValue("@precovenda", precovenda);
                    cmd.Parameters.AddWithValue("@descricao", descricao);
                    cmd.Parameters.AddWithValue("@fotocapa", fotocapa);

                    // Execute o comando SQL
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }

            // Após a inserção bem-sucedida, você pode redirecionar para uma página de confirmação ou fazer qualquer outra ação necessária.
            // Primeiro, obtenha o último ID inserido chamando a função que você criou
            int ultimoIDInserido = Imovel.GetUltimoIDInserido();

            // Agora você pode redirecionar para a página DetalhesImovel.aspx com o último ID inserido
            Response.Redirect("/Admin/Imoveis/DetalhesImovel.aspx?id=" + ultimoIDInserido);
        }
    }
}