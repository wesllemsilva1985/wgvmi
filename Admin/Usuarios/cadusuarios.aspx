<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cadusuarios.aspx.cs" Inherits="wgvmi.Admin.Usuarios.cadusuarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cadastro de Usuários</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            margin: 0;
            padding: 0;
            height: 100vh;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: flex-start;
        }

        .title {
            font-size: 24px;
            color: #e67e22;
            font-weight: bold;
            text-shadow: 2px 2px 4px #000000;
            margin-top: 2px;
            margin-bottom: 15px;
        }

        .form-container {
            background-color: #fff;
            padding: 5px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
            width: 50%; /* Ajuste o tamanho desejado, por exemplo, 70% da largura da tela */
            margin-top: 10px;
            margin-bottom: 10px;
        }


        .form-group {
            margin-bottom: 15px;
        }

        .form-label {
            font-size: 16px;
            font-weight: bold;
            display: block;
        }

        .form-input {
            width: 95%;
            height: 13px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
            transition: background-color 0.3s ease;
        }

            .form-input:focus {
                background-color: #fff7e0;
            }

        .form-button {
            background-color: #e67e22;
            color: #fff;
            padding: 10px 10px;
            border: none;
            border-radius: 5px;
            font-size: 18px;
            cursor: pointer;
        }

        .form-select {
            width: 99%;
            height: 40px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 16px;
            transition: background-color 0.3s ease;
        }

            .form-select:focus {
                background-color: #fff7e0;
            }

        .error-message {
            font-size: 14px;
            color: red;
            font-weight: bold;
            margin-top: 10px;
            text-align: center;
        }

        .success-message {
            display: none;
            text-align: center;
            background-color: #4CAF50;
            color: white;
            padding: 20px;
            position: absolute;
            left: 50%;
            top: 50%;
            transform: translate(-50%, -50%);
            border-radius: 5px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
        }

        .back-button {
            background-color: #333;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 18px;
            cursor: pointer;
            margin-top: 20px;
        }

            .back-button:hover {
                background-color: #555;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-container">
        <div id="divFormulario" runat="server">
            <div class="title">
                Cadastro de Usuário
            </div>
            <div class="form-container" style="width: 95%;">
                <div class="form-group">
                    <label class="form-label">Nome:</label>
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-input" onblur="validarNome(this)" />
                    <span id="nome-error" class="error-message"></span>
                </div>
                <div class="form-group">
                    <label class="form-label">Sobrenome:</label>
                    <asp:TextBox ID="txtSobrenome" runat="server" CssClass="form-input" onblur="validarSobrenome(this)" />
                    <span id="sobrenome-error" class="error-message"></span>
                </div>
                <div class="form-group">
                    <label class="form-label">Gênero:</label>
                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label class="form-label">Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input" onblur="validarEmail(this)" />
                    <span id="email-error" class="error-message"></span>
                </div>
                <div class="form-group">
                    <label class="form-label">Senha:</label>
                    <asp:TextBox ID="txtSenha" runat="server" CssClass="form-input" TextMode="Password" onblur="validarSenha(this)" />
                    <span id="senha-error" class="error-message"></span>
                </div>
                <div class="form-group">
    <label class="form-label">Confirmação de Senha:</label>
    <asp:TextBox ID="txtConfirmacaoSenha" runat="server" CssClass="form-input" TextMode="Password" onblur="validarConfirmacaoSenha(this)" onkeyup="validarConfirmacaoSenha(this)" />
    <span id="senha-error" class="error-message"></span>
</div>
               <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" CssClass="form-button" OnClientClick="return validarCadastro();" />

            </div>
            <asp:Label ID="lblMensagemErro" runat="server" ForeColor="Red" Text="" CssClass="error-message"></asp:Label>
        </div>
        <div id="divMensagemSucesso" runat="server" class="success-message" style="display: none;">
            <p>Cadastro realizado com sucesso!</p>
            <asp:Button ID="btnVoltar" runat="server" Text="Voltar" OnClick="btnVoltar_Click" CssClass="back-button" />
        </div>
    </form>
</body>
</html>
