<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Deletarimovel.aspx.cs" Inherits="wgvmi.Admin.Imoveis.Deletarimovel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../css/Imovel.css" rel="stylesheet" />
    <section class="main-content">
        <form id="form1" runat="server">
            <h1 class="titulo">Deseja deletar o registro do imóvel de ID
                <asp:Label ID="lblID" runat="server" Text=""></asp:Label>?</h1>
            <p class="alerta">Ao confirmar, você estara deletando todo o registro deste imóvel, incluindo fotos e todas as informações relacionadas..</p>
            <asp:Label ID="lblTotalImagens" runat="server" Text=""></asp:Label>
            <div class="botoes-container">
                <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="botao" OnClick="btnConfirmar_Click" />

                <button class="botao">Cancelar</button>
            </div>
        </form>
    </section>
</asp:Content>