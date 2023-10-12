<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="wgvmi.Index1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="div-titu-imov_destaque">
        <div class="text-titu-imov-destaque">IMÓVEIS<strong> EM DESTAQUE</strong></div>
        <p class="aviso-em-desenvolvimento">Esta página está em desenvolvimento. Novas funções e informações serão adicionadas em breve.</p>
    </div>
    <div class="repeater-container">
        <asp:Repeater ID="RepeaterImoveis" runat="server">
            <ItemTemplate>
                <div class="imovel">
                    <div class="div-block-4">
                        <div class="div-image-imov-destaque">
                            <img src="<%# "/Imoveis/Imagens/Capas/" + Eval("FotoCapa") %>" loading="lazy" alt="">
                            <div class="div-venda-imov-destaque">
                                <div class="text-venda-imov-destaque">Venda</div>
                            </div>
                            <div class="div-preco-imov-destaque">
                                <div class="text-venda-imov-destaque"><%# Eval("PrecoVenda") %></div>
                            </div>
                            <div class="div-block-5">
                                <div class="text-block-2"><%# Eval("Estado") %> - <%# Eval("Bairro") %> - <%# Eval("Endereco") %></div>
                                <div class="div-block-6">
                                    <a href="<%# "/Pages/Imoveis/Imovel.aspx?Id=" + Eval("Id") %>" class="button w-button">+ Detalhes</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>