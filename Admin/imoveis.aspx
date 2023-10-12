<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="imoveis.aspx.cs" Inherits="wgvmi.Admin.imoveis" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/imoveis.css" rel="stylesheet" />
    <div class="lateral-esquerda">
        <ul>
        
              <li><a href="/Admin/Models/CadastroImoveis.aspx">Cadastrar</a></li>
            <li><a href="/Admin/Views/lista-imoveis.aspx">Visualizar</a></li>
        </ul>
    </div>
</asp:Content>
