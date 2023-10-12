<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="wgvmi.Imoveis.index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="aimov-naim">

        <!-- Título -->
        <div class="imov-titulo">Imóveis cadastrados</div>

        <!--- tabela com celulas de titulos --->
        <div class="imov-cel-titulos">
            <div class="titu-lado">ID</div>
            <div class="titu-lado">Tipo</div>
            <div class="titu-lado">Titulo</div>
            <div class="titu-lado">Estado</div>
            <div class="titu-lado">R$</div>
        </div>
        <!--- tabela com celulas dos registros do banco --->
        <div class="imov-cel-dados">
            <div class="dados-lado">
                <asp:Label ID="lblID" runat="server"></asp:Label>
            </div>
            <div class="dados-lado">
                <asp:Label ID="lblTipo" runat="server"></asp:Label>
            </div>
            <div class="dados-lado">
                <asp:Label ID="lblTitulo" runat="server"></asp:Label>
            </div>
            <div class="dados-lado">
                <asp:Label ID="lblEstado" runat="server"></asp:Label>
            </div>
            <div class="dados-lado">
                R$<asp:Label ID="lblValor" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>