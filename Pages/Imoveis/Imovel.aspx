<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Imovel.aspx.cs" Inherits="wgvmi.Pages.Imoveis.Imovel" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/themes/ByWescomp/WsStick.css" rel="stylesheet" />
    <link href="../../Content/themes/base/Imovel.css" rel="stylesheet" />

    <section class="section-titulo-top">
        <h2>
            <asp:Label ID="Estado" runat="server"></asp:Label>
            -
            <asp:Label ID="Cidade" runat="server"></asp:Label>
            -
            <asp:Label ID="Bairro" runat="server"></asp:Label>
            -
              <asp:Label ID="Titulo" runat="server"></asp:Label>
            -
            <asp:Label ID="Localizacao" runat="server"></asp:Label>
        </h2>
        <p>...</p>
    </section>


    <div class="carousel-container">
        <div class="carousel slider">
            <asp:Repeater ID="repeaterSlides" runat="server">
                <ItemTemplate>
                    <div style="width: 300px; height: 200px; overflow: hidden; text-align: center;" class="imagem-container">
                        <asp:Image ID="imgItem" runat="server" ImageUrl='<%# "~/Imoveis/Imagens/" + Eval("Imagem") %>' AlternateText='<%# Eval("TituloImagem") %>' CssClass="imagem-contida" data-toggle="modal" data-target="#imagemModal" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>


    <!-- Seção com a classe "section-detalhes-imov" -->
    <section class="section-detalhes-imov">

        <div class="mapa-links">Seção em desenvolvimento...</div>

        <div class="referencia-imovel">Ref:</div>
        <div class="numero-visitas">Visitas</div>
        <!-- Div para tipo do imóvel -->
        <div class="tipo-imovel"><asp:Label ID="Tipo" runat="server"></asp:Label></div>
        <div class="area-util">Área util</div>

        <!-- Div para total de área -->
        <div class="area-total">Area Total</div>
        <div class="quantidade-quartos">Quartos: </div>

        <!-- Div para total de banheiros -->
        <div class="banheiros">Banheiros:</div>
        <div class="garagem">Estacionamento:</div>


    </section>

    <section class="section-desc-imov">
       <h2>Descrição do Imóvel</h2>
        <p><asp:Label ID="Desc" runat="server"></asp:Label></p>
        </section>

    <!-- Outra div fora da seção -->
    <div class="mais-detalhes">
       <div class="venda">Venda</div>
        <div class="container-pai">
    <div class="valor-label">Valor: </div>
    <div class="preco"><asp:Label ID="Valor" runat="server"></asp:Label></div>
</div>



    </div>

    <script>
        // Seleciona o elemento .mais-detalhes
        const maisDetalhes = document.querySelector('.mais-detalhes');
        const sectionDetalhesImov = document.querySelector('.section-detalhes-imov');

        // Obtém a posição inicial da div .mais-detalhes em relação ao topo da página
        const distanciaDaParteSuperior = maisDetalhes.getBoundingClientRect().top;

        // Verifica a posição do topo da tela
        window.addEventListener('scroll', () => {
            const scrollTop = window.scrollY;

            if (scrollTop >= distanciaDaParteSuperior) {
                maisDetalhes.classList.add('fixo');
            } else {
                maisDetalhes.classList.remove('fixo');
            }
        });


    </script>
</asp:Content>

