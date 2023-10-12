<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListarImoveis.aspx.cs" Inherits="wgvmi.Admin.Imoveis.ListarImoveis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <link href="../css/ListaImoveis.css" rel="stylesheet" />
    <form runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridView-centralizado">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="titulo-coluna" ItemStyle-Width="50px" />
        <asp:BoundField DataField="Titulo" HeaderText="Titulo" HeaderStyle-CssClass="titulo-coluna" ItemStyle-Width="250px" />
        <asp:BoundField DataField="Tipo" HeaderText="Tipo" HeaderStyle-CssClass="titulo-coluna" ItemStyle-Width="120px" />
        <asp:BoundField DataField="Cidade" HeaderText="Cidade" HeaderStyle-CssClass="titulo-coluna" ItemStyle-Width="100px" />
        <asp:BoundField DataField="Bairro" HeaderText="Bairro" HeaderStyle-CssClass="titulo-coluna" ItemStyle-Width="100px" />
        <asp:BoundField DataField="Endereco" HeaderText="Endereco" HeaderStyle-CssClass="titulo-coluna" ItemStyle-Width="180px" />
        <asp:BoundField DataField="PrecoVenda" HeaderText="Preço Venda" HeaderStyle-CssClass="titulo-coluna" ItemStyle-Width="100px" />
        
        <asp:TemplateField HeaderText="Ações" HeaderStyle-CssClass="titulo-coluna"  ItemStyle-Width="130px">
            <ItemTemplate>
                <div style="text-align: center;">
                <!-- Aqui você pode adicionar botões ou links para ações relacionadas ao item -->
              <asp:Button ID="btnDetalhes" runat="server" Text="Detalhes" CommandName="Detalhes" CssClass="botao-estilo" OnClick="btnDetalhes_Click" CommandArgument='<%# Eval("id") %>' />

                <!-- Adicione outros elementos de ação conforme necessário -->
            </div>
                    </ItemTemplate>
        </asp:TemplateField>
    </Columns>
          
    <RowStyle CssClass="registro-linha"/>
            
</asp:GridView>

    </form>
</asp:Content>

