using System;
using System.Collections.Generic;

using wgvmi.Models;

namespace wgvmi
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Chame a função para listar todos os imóveis
                List<Imovel> listaImoveis = Imovel.ListarTodosImoveis();
                // Vincule a lista de imóveis ao Repeater
                RepeaterImoveis.DataSource = listaImoveis;
                RepeaterImoveis.DataBind();
            }
        }
    }
}