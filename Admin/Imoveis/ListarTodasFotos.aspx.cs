using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using wgvmi.Admin.Models;

namespace wgvmi.Admin.Imoveis
{
    public partial class ListarTodasFotos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<ImovelAlbum> imagens = ImovelAlbum.ExibirTodosRegistros();

                // Vincule a lista de imóveis ao GridView
                GridViewImagens.DataSource = imagens;
                GridViewImagens.DataBind();
                // Agora, você pode usar a lista de imagens como desejar, por exemplo, exibi-las em uma grade (GridView) ou realizar outras operações com elas.
            }
        }

        protected void btnExcluir_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ExcluirImagem")
            {
                try
                {
                    string argumento = e.CommandArgument.ToString();
                    string[] argumentos = argumento.Split(',');
                    string caminhoArquivo = "/Imoveis/Imagens/" + argumentos[1];

                    // Tente chamar a função ExcluirImagem com o caminho do arquivo como argumento
                    Imagens.ExcluirImagem(caminhoArquivo);

                    int id = Convert.ToInt32(argumentos[0]);

                    // Tente chamar a função ExcluirImagensPorImovelId com o ID como argumento
                    ImovelAlbum.ExcluirImagensPorImovelId(id);

                    // Aqui você pode adicionar qualquer lógica adicional após a exclusão da imagem, se necessário

                    // Exibindo uma mensagem de sucesso (você pode personalizar isso conforme necessário)
                    ScriptManager.RegisterStartupScript(this, GetType(), "showSuccessAlert", "alert('Imagem excluída com sucesso!');", true);
                    // Redirecionar para a mesma página após a mensagem de sucesso
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    // Tratamento de erro: exiba a mensagem de erro ou registre o erro em um log, conforme necessário
                    string mensagemErro = "Ocorreu um erro ao excluir a imagem: " + ex.Message;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showErrorAlert", "alert('" + mensagemErro + "');", true);
                }
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Button btnExcluir = (Button)sender;
            string argumento = btnExcluir.CommandArgument.ToString();
            string[] argumentos = argumento.Split(',');
            int idRegistro = Convert.ToInt32(argumentos[0]);
            string caminhoArquivo = "/Imoveis/Imagens/" + argumentos[1];

            try
            {
                // Chame a função ExcluirImagem com o caminho do arquivo como argumento
                Imagens.ExcluirImagem(caminhoArquivo);

                // Chame a função ExcluirImagensPorImovelId com o ID como argumento
                ImovelAlbum.ExcluirRegistroPorId(idRegistro);

                // Exibindo uma mensagem de sucesso
                ScriptManager.RegisterStartupScript(this, GetType(), "showSuccessAlert", "alert('Imagem excluída com sucesso!');", true);
            }
            catch (Exception ex)
            {
                // Tratamento de erro: exiba a mensagem de erro ou registre o erro em um log, conforme necessário
                string mensagemErro = "Ocorreu um erro ao excluir a imagem: " + ex.Message;
                ScriptManager.RegisterStartupScript(this, GetType(), "showErrorAlert", "alert('" + mensagemErro + "');", true);
            }

            // Redirecionar para a mesma página após a exclusão (caso deseje)
            Response.Redirect(Request.RawUrl);
        }


    }
}