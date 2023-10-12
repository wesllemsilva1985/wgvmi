using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wgvmi
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                Literal litConteudo = (Literal)Page.PreviousPage.FindControl("litConteudo");
                if (litConteudo != null)
                {
                    ContentPlaceHolder1.Controls.Add(new LiteralControl(litConteudo.Text));
                }
            }
        }
    }
}