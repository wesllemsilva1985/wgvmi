using System;
using System.Collections.Generic;

using wgvmi.Admin.Models;

namespace wgvmi.Admin.Imoveis
{
    public partial class Deletarimovel : System.Web.UI.Page
    {
        private static int totalImagens;
        private static int idDoImovel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar se o parâmetro "id" está presente na URL
                if (Request.QueryString["id"] != null)
                {
                    // Obter o valor do parâmetro "id" da URL
                    string id = Request.QueryString["id"];

                    lblID.Text = id;

                    // Chame a função para contar o total de imagens para o imóvel com o ID fornecido
                    idDoImovel = Convert.ToInt32(id);
                    totalImagens = Models.ImovelAlbum.ContarTotalImagensPorImovelId(idDoImovel);

                    // Agora você pode usar o valor de "totalImagens" como necessário
                    // Por exemplo, você pode exibi-lo em um rótulo (label) na página
                    if (totalImagens == 0)
                    {
                        lblTotalImagens.Text = "Este imóvel não possui imagens no álbum.";
                    }
                    else if (totalImagens == 1)
                    {
                        lblTotalImagens.Text = "Este imóvel possui um total de " + totalImagens.ToString() + " imagem no álbum.";
                    }
                    else
                    {
                        lblTotalImagens.Text = "Este imóvel possui um total de " + totalImagens.ToString() + " imagens no álbum.";
                    }
                }
                else
                {
                    // O parâmetro "id" não está presente na URL, faça algo adequado aqui
                    // Por exemplo, redirecione para uma página de erro ou exiba uma mensagem
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int TotalImg = 0;
            if (totalImagens > 0)
            {
                //Caso a tabela de imagens possua registros, executa primeiro a limpeza das imagens no servdor de acordo com o nome de cada imagem do banco

                List<Models.ImovelAlbum> imagens = Models.ImovelAlbum.BuscarImagensPorImovelId(idDoImovel);

                // Faça algo com a lista de imagens, por exemplo, percorra-a ou exiba os dados
                foreach (var imagem in imagens)
                {
                    // chama a função para excluir a imagem do servidor
                    string caminhoDaImagem = Server.MapPath("/Imoveis/Imagens/" + imagem.Imagem);
                    Imagens.ExcluirImagem(caminhoDaImagem);

                    // Exclui os registros da tabela das imagens
                    Models.ImovelAlbum.ExcluirImagensPorImovelId(idDoImovel);

                    TotalImg += 1;
                    lblTotalImagens.Text = "Excluindo o registro " + TotalImg.ToString() + " de " + totalImagens.ToString();
                }
                lblTotalImagens.Text = "Todos os registros de imagens excluidos com sucesso!";
                ExcluirImovel();
            }
            else
            {
                ExcluirImovel();
            }
        }

        protected void ExcluirImovel()
        {
            // após excluir e limpar os registos de imagens no banco e no servidor, inicia a exclusao da imagem de capa no servidor
            Models.Imovel imovel = Models.Imovel.GetImovelPorID(idDoImovel);
            if (imovel.FotoCapa != "/Admin/Imoveis/Img/thumSemFoto.jpg")
            {
                // chama a função para excluir a imagem do servidor
                string caminhoDaImagem = Server.MapPath("/Imoveis/Imagens/Capas/" + imovel.FotoCapa);
                Imagens.ExcluirImagem(caminhoDaImagem);
            }

            // Chame a função para deletar o imóvel por ID
            Models.Imovel.DeletarImovelPorID(idDoImovel);

            // Redireciona para a pagina de listagem dos imoveis
            Response.Redirect("/Admin/Imoveis/ListarImoveis.aspx");
        }
    }
}