<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListarTodasFotos.aspx.cs" Inherits="wgvmi.Admin.Imoveis.ListarTodasFotos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .img-tooltip {
            cursor: pointer;
        }

        .tooltip {
            position: absolute;
            display: none;
            padding: 10px;
            background-color: white;
            border: 1px solid #ccc;
            z-index: 9999;
        }

            .tooltip img {
                max-width: 300px;
            }
    </style>


    <form runat="server">
        <asp:GridView ID="GridViewImagens" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="ID" />
        <asp:BoundField DataField="ImovelId" HeaderText="ImovelId" />
        <asp:BoundField DataField="TituloImagem" HeaderText="Título da Imagem" />
        <asp:TemplateField HeaderText="Imagem">
            <ItemTemplate>
                <asp:Image ID="imgImagem" runat="server" ImageUrl='<%# "/Imoveis/Imagens/" + Eval("Imagem") %>' CssClass="img-tooltip" Width="32px" Height="32px" />
                <div class="tooltip">
                    <asp:Image ID="imgTooltip" runat="server" ImageUrl='<%# "/Imoveis/Imagens/" + Eval("Imagem") %>' />
                </div>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="DataCriacao" HeaderText="Data de Criação" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" />
        
        <asp:TemplateField HeaderText="Ações">
            <ItemTemplate>
                <!-- Adicione os controles de ações aqui, por exemplo, botões de edição e exclusão -->
               
             <asp:Button ID="btnExcluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" 
    CommandArgument='<%# Eval("Id") + "," + Eval("Imagem") %>' OnClientClick="return confirm('Deseja realmente excluir esta imagem?');" />




            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>



    </form>


</asp:Content>
