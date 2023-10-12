using System;

namespace wgvmi
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // Evento Application_Start é acionado quando o aplicativo é iniciado.
            // Você pode adicionar código de inicialização do aplicativo aqui.
            // RouteConfig.RegisterRoutes(RouteTable.Routes); // Registra as rotas no evento Application_Start
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Evento Session_Start é acionado quando uma nova sessão é iniciada.
            // Você pode adicionar código relacionado ao início de sessão aqui.
            // RouteConfig.RegisterRoutes(RouteTable.Routes);

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

            // Obtenha o caminho da solicitação
            string path = Context.Request.Path;

            // Verifique se o usuário não está autenticado e se a página está no diretório "Admin"
            if (!Context.Request.IsAuthenticated && path.StartsWith("/Admin/"))
            {
                // Redirecione para a página de login
                Response.Redirect("~/Account/Login.aspx");
            }

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Evento Application_AuthenticateRequest é acionado durante a autenticação de solicitação.
            // Você pode adicionar código relacionado à autenticação aqui.
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Evento Application_Error é acionado quando ocorre um erro não tratado.
            // Você pode adicionar código relacionado ao tratamento de erros aqui.
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Evento Session_End é acionado quando uma sessão é encerrada.
            // Você pode adicionar código relacionado ao encerramento de sessão aqui.
        }

        protected void Application_End(object sender, EventArgs e)
        {
            // Evento Application_End é acionado quando o aplicativo é encerrado.
            // Você pode adicionar código de encerramento do aplicativo aqui.
        }
    }
}
