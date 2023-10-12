<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="wgvmi.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <style>
        body {
            background-color: #fff;
            font-family: Arial, sans-serif;
            text-align: center;
        }

        .login-container {
            background-color: #f0f0ff;
            border-radius: 8px;
            box-shadow: 0 0 10px 0 #007bff; /* Sombra azul claro */
            width: 300px;
            margin: 50px auto 0;
            padding: 20px;
        }

        h1 {
            color: #ff8c00; /* Laranja */
        }

        .message {
            color: #d9534f; /* Vermelho - para mensagens de erro */
            text-align: center;
            margin-bottom: 10px;
        }

        label {
            display: block;
            margin: 10px 0;
            color: #333;
            text-align: left;
        }

        input[type="text"],
        input[type="password"] {
            width: 90%;
            padding: 10px;
            margin: 6px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        input[type="submit"] {
            background-color: #007bff; /* Azul */
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

            input[type="submit"]:hover {
                background-color: #0056b3; /* Azul mais escuro */
            }

        .hyperlink {
            color: #007bff; /* Cor azul para o link */
            text-decoration: none; /* Remove sublinhado */
        }

            /* Estilo quando o mouse passa sobre o link (hover) */
            .hyperlink:hover {
                color: #0056b3; /* Cor mais escura quando o mouse passa sobre o link */
                text-decoration: underline; /* Adiciona um sublinhado quando o mouse passa sobre o link */
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />

        <asp:Panel ID="loginContainer" runat="server">
            <div class="login-container">
                <h1>Login</h1>
                <div>
                    <asp:Label ID="ErrorMessageLabel" runat="server" CssClass="message"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblUsuario" runat="server" Text="Usuário:" AssociatedControlID="txtUsuario" CssClass="label" />
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="textbox" />
                </div>
                <div>
                    <asp:Label ID="lblSenha" runat="server" Text="Senha:" AssociatedControlID="txtSenha" CssClass="label" />
                    <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" CssClass="textbox" />
                </div>
                <div>
                    <asp:Button ID="btnLogin" runat="server" Text="Entrar" CssClass="btn" OnClick="btnLogin_Click" />
                </div>

                <!-- Seção de recuperação de senha -->
                <div>

                    <asp:LinkButton ID="lnkRecPass" runat="server" Text="Esqueci minha senha" CssClass="btn" OnClick="lnkRecPass_Click" />
                </div>

                <!-- Fim da seção de recuperação de senha -->
            </div>
        </asp:Panel>

        <asp:UpdatePanel ID="updatePanel" runat="server" EnableViewState="true">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnRecoverPassword" />
                <asp:PostBackTrigger ControlID="lnkCancel" />
                <asp:PostBackTrigger ControlID="lnkRecPass" />
            </Triggers>
            <ContentTemplate>
                <!-- Coloque aqui os controles que deseja atualizar via AJAX -->
                <asp:Panel ID="pnlRecoverPassword" runat="server">
                    <div class="login-container">
                        <!-- Conteúdo do painel de recuperação de senha -->
                        <asp:LinkButton ID="lnkCancel" runat="server" Text="Cancelar" OnClick="lnkCancel_Click" />

                        <asp:TextBox ID="txtRecoveryEmail" runat="server" CssClass="textbox" />
                        <asp:Button ID="btnRecoverPassword" runat="server" Text="Recuperar Senha" CssClass="btn" OnClick="btnRecoverPassword_Click" />
                        <div>
                            <asp:Label ID="RecoveryLabel" runat="server" CssClass="message"></asp:Label>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="mailSucesso" runat="server">
                    <div class="login-container">
                        <div>
                            <asp:Label ID="msdMailSucesso" runat="server" CssClass="message"></asp:Label>
                        </div>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>