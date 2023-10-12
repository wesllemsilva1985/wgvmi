using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using wgvmi.Admin.Models;

namespace wgvmi.Admin.Imoveis
{
    public partial class ListarImoveis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Chame a função ListarTodosImoveis para obter os registros
                List<Imovel> imoveis = Imovel.ListarTodosImoveis();

                // Vincule a lista de imóveis ao GridView
                GridView1.DataSource = imoveis;
                GridView1.DataBind();
            }
        }

        protected void btnDetalhes_Click(object sender, EventArgs e)
        {
            // Determine o botão clicado
            Button btn = (Button)sender;

            // Recupere o valor do CommandArgument que foi definido no botão
            int idDoRegistro = Convert.ToInt32(btn.CommandArgument);

            // Redirecione para a página DetalhesImovel.aspx com o ID como parâmetro
            Response.Redirect("DetalhesImovel.aspx?id=" + idDoRegistro);
            //Response.Write("ID: " + idDoRegistro);
        }


    }
}