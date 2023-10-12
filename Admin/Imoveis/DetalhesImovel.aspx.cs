using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

using wgvmi.Admin.Models;

namespace wgvmi.Admin.Imoveis
{
    public partial class DetalhesImovel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int id = ObterIdDoImovel();

                if (id != 0)
                {
                    CarregarImovel(id);
                    CarregarImagens(id);
                }
                else
                {
                    // Trate o caso em que o ID do imóvel não foi fornecido na query string.
                    // Pode ser uma boa ideia redirecionar para uma página de erro ou lidar com isso de outra maneira.
                }
            }
        }


        private int ObterIdDoImovel()
        {
            if (int.TryParse(Request.QueryString["id"], out int idImovel))
            {
                return idImovel;
            }
            return 0; // Valor padrão para indicar que o ID não foi fornecido ou é inválido
        }

        private void CarregarImovel(int id)
        {
            Imovel imovel = Imovel.GetImovelPorID(id);

            if (imovel != null)
            {
                lblTitulo.Text = imovel.Titulo;
                lblTipo.Text = imovel.Tipo;
                lblEstado.Text = imovel.Estado;
                lblCidade.Text = imovel.Cidade;
                lblLocal.Text = imovel.Endereco;
                lblValor.Text = imovel.PrecoVenda;

                string fotoCapa;

                if (imovel.FotoCapa == "/Admin/Imoveis/Img/thumSemFoto.jpg")
                {
                    fotoCapa = imovel.FotoCapa;
                }
                else
                {
                    fotoCapa = "/Imoveis/Imagens/Capas/" + imovel.FotoCapa;
                }

                imgCapa.ImageUrl = fotoCapa;

                lblDesc.Text = imovel.Descricao;
            }
            else
            {
                // Imóvel não encontrado, faça o tratamento adequado
            }
        }

        private void CarregarImagens(int id)
        {
            List<ImovelAlbum> imagens = ImovelAlbum.BuscarImagensPorImovelId(id);

            // Limite a lista para conter apenas os 5 primeiros registros
            imagens = imagens.Take(5).ToList();

            // Vincule os dados ao asp:Repeater
            rptImagens.DataSource = imagens;
            rptImagens.DataBind();
        }


        // Renomeia a imagem para um nome aleatorio
        public static class NomeImagemAleatorio
        {
            public static string GerarNomeAleatorio(int idImovel, string nomeOriginal)
            {
                // Obtenha a extensão do nome original do arquivo
                string extensao = Path.GetExtension(nomeOriginal);

                // Gere o nome do arquivo com o ID do imóvel como prefixo
                string nomeArquivo = $"id{idImovel}_{Guid.NewGuid().ToString("N")}{extensao}";

                return nomeArquivo;
            }
        }

        // Função para salvar a imagem no servidor
        private void SalvarImagemNoServidor(FileUpload fileUpload, string nomeImagem)
        {
            string caminhoParaSalvar = Server.MapPath("/Imoveis/Imagens/" + nomeImagem);

            try
            {
                fileUpload.SaveAs(caminhoParaSalvar);
            }
            catch (Exception ex)
            {
                // Trate qualquer exceção que possa ocorrer durante o salvamento da imagem
                Response.Write($"Erro ao salvar a imagem: {ex.Message}");
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            List<string> nomesImagens = new List<string>();

            // Verifique cada controle FileUpload e obtenha o nome da imagem, se um arquivo for carregado
            if (fileUpload.HasFile)
            {
                string nomeImagem = NomeImagemAleatorio.GerarNomeAleatorio(id, fileUpload.FileName);
                nomesImagens.Add(nomeImagem);

                // Salve a imagem no servidor
                SalvarImagemNoServidor(fileUpload, nomeImagem);
            }

            if (fileUpload1.HasFile)
            {
                string nomeImagem = NomeImagemAleatorio.GerarNomeAleatorio(id, fileUpload1.FileName);
                nomesImagens.Add(nomeImagem);

                // Salve a imagem no servidor
                SalvarImagemNoServidor(fileUpload1, nomeImagem);
            }

            if (fileUpload2.HasFile)
            {
                string nomeImagem = NomeImagemAleatorio.GerarNomeAleatorio(id, fileUpload2.FileName);
                nomesImagens.Add(nomeImagem);

                // Salve a imagem no servidor
                SalvarImagemNoServidor(fileUpload2, nomeImagem);
            }

            if (fileUpload3.HasFile)
            {
                string nomeImagem = NomeImagemAleatorio.GerarNomeAleatorio(id, fileUpload3.FileName);
                nomesImagens.Add(nomeImagem);

                // Salve a imagem no servidor
                SalvarImagemNoServidor(fileUpload3, nomeImagem);
            }

            if (fileUpload4.HasFile)
            {
                string nomeImagem = NomeImagemAleatorio.GerarNomeAleatorio(id, fileUpload4.FileName);
                nomesImagens.Add(nomeImagem);

                // Salve a imagem no servidor
                SalvarImagemNoServidor(fileUpload4, nomeImagem);
            }

            if (fileUpload5.HasFile)
            {
                string nomeImagem = NomeImagemAleatorio.GerarNomeAleatorio(id, fileUpload5.FileName);
                nomesImagens.Add(nomeImagem);

                // Salve a imagem no servidor
                SalvarImagemNoServidor(fileUpload5, nomeImagem);
            }

            // Agora, a lista "nomesImagens" contém os nomes de todos os arquivos carregados
            foreach (string nomeImagem in nomesImagens)
            {
                // Crie um objeto ImovelAlbum com os dados da imagem
                ImovelAlbum album = new ImovelAlbum
                {
                    ImovelId = id, // Substitua pelo ID do seu imóvel
                                   // TituloImagem = "Título da Imagem", // Substitua pelo título da imagem
                    Imagem = nomeImagem, // Nome da imagem obtido do loop
                    DataCriacao = DateTime.Now // Data atual


                };

                // Chame a função para inserir os dados no banco de dados
                ImovelAlbum.AdicionarImagemAlbum(album);

                // Você pode processar os nomes das imagens conforme necessário aqui
                // Por exemplo, inseri-los em uma tabela no banco de dados ou salvá-los em algum lugar no servidor.
                // Response.Write($"Nome da Imagem: {nomeImagem}<br />");
            }

            // Após o processamento das imagens, você pode redirecionar para uma página de confirmação ou fazer qualquer outra ação necessária.
            Response.Redirect("DetalhesImovel.aspx?id=" + id);


        }





    }
}
