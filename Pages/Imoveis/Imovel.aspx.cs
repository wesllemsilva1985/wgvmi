using System;
using System.Collections.Generic;

using wgvmi.Models;

namespace wgvmi.Pages.Imoveis
{
    public partial class Imovel : System.Web.UI.Page
    {
        int idDoImovel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string idParametro = Request.QueryString["id"];
                    idDoImovel = int.TryParse(idParametro, out int parsedId) ? parsedId : 0;

                    // List das imagens do album do ID do imovel filtrado
                    List<ImovelAlbum> imagensDoImovel = ImovelAlbum.BuscarImagensPorImovelId(idDoImovel);

                    // Associe os dados ao Repeater para listar as imagens do album
                    repeaterSlides.DataSource = imagensDoImovel;
                    repeaterSlides.DataBind();

                    // recuperar os dados da tabela imovel de acordo com o id
                    Models.Imovel imovel = Models.Imovel.GetImovelPorID(idDoImovel);

                    Estado.Text = imovel.Estado;
                    Cidade.Text = imovel.Cidade;
                    Bairro.Text = imovel.Bairro;
                    Titulo.Text = imovel.Titulo;
                    Localizacao.Text = imovel.Endereco;

                    Tipo.Text = imovel.Tipo;
                    Desc.Text = imovel.Descricao;

                    Valor.Text = imovel.PrecoVenda;
                    // Agora você pode usar o objeto 'imovel' como necessário no seu código-behind.


                }
            }
        }
    }
}
