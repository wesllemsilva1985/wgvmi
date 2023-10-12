<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="wgvmi.Account.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Minha Página Inicial</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Bem-vindo à Minha Página Inicial</h2>

            <asp:LoginView ID="LoginView1" runat="server">
                <AnonymousTemplate>
                    <p>Por favor, faça login para acessar o conteúdo desta página.</p>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <p>Olá, <%= Context.User.Identity.Name %>! Você está autenticado e pode acessar o conteúdo exclusivo.</p>
                    <asp:HyperLink ID="LogoutLink" runat="server" NavigateUrl="Logout.aspx" Text="Sair" />
                </LoggedInTemplate>
            </asp:LoginView>
        </div>
    </form>
</body>
</html>