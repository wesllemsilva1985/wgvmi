<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DetalhesImovel.aspx.cs" Inherits="wgvmi.Admin.Imoveis.DetalhesImovel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Inclui o arquivo CSS -->
    <link href="../css/DetalhesImovel.css" rel="stylesheet" />

    <!-- Seção property-acoes -->
    <section class="property-acoes">
      
        <div>
            <h3>Ações:</h3>
             <!-- Botão "Inserir Fotos" -->
            <button class="inserir-fotos-btn" id="abrir-modal">Inserir Fotos</button>

           <button class="inserir-fotos-btn" id="excluir-registro">Excluir</button>
         
       <script>
           // Adicionar um evento de clique ao botão
           document.getElementById("excluir-registro").addEventListener("click", function () {
               // Obter o ID da URL atual da página
               var id = obterIDDaURLAtual();

               // Redirecionar para a URL desejada com o ID
               window.location.href = "/Admin/Imoveis/Deletarimovel.aspx?id=" + id;
           });

           // Função para obter o ID da URL atual da página
           function obterIDDaURLAtual() {
               var url = window.location.href;
               var partesDaURL = url.split("?");
               if (partesDaURL.length > 1) {
                   var parametros = partesDaURL[1].split("&");
                   for (var i = 0; i < parametros.length; i++) {
                       var parametro = parametros[i].split("=");
                       if (parametro[0] === "id") {
                           return parametro[1];
                       }
                   }
               }
               return null;
           }
       </script>


        </div>
        <!-- Modal para inserção de fotos -->
        <div class="modal" id="myModal">
            <div class="modal-content">
                <!-- Botão para fechar o modal -->
                <span class="fechar-modal" id="fechar-modal">&times;</span>
                <h2>Inserir Fotos</h2>
                <h3 style="font-size: 14px; color: #000;">Clique nas imagens abaixo para selecionar a foto que deseja carregar.<br />
                    Você pode enviar até 6 imagens.<br />
                    Não é obrigatório selecionar as 6 imagens.
                </h3>
                <!-- Formulário para inserir imagens -->
                <form id="form1" runat="server" enctype="multipart/form-data">
                    <div class="image-preview-container">
                        <!-- Asp:FileUpload 1 -->
                        <asp:FileUpload ID="fileUpload" runat="server" CssClass="file-upload" onchange="previewImage(this);" Style="display: none;" />
                        <asp:Image ID="imagePreview" runat="server" ImageUrl="/Admin/Imoveis/Img/thumSemFoto.jpg"
                            onclick="openFileUploader();" CssClass="image-preview" Style="cursor: pointer; width: 150px;" />

                        <!-- Asp:FileUpload 2 -->
                        <asp:FileUpload ID="fileUpload1" runat="server" CssClass="file-upload" onchange="previewImage1(this);" Style="display: none;" />
                        <asp:Image ID="imagePreview1" runat="server" ImageUrl="/Admin/Imoveis/Img/thumSemFoto.jpg"
                            onclick="openFileUploader1();" CssClass="image-preview" Style="cursor: pointer; width: 150px;" />

                        <!-- Asp:FileUpload 3 -->
                        <asp:FileUpload ID="fileUpload2" runat="server" CssClass="file-upload" onchange="previewImage2(this);" Style="display: none;" />
                        <asp:Image ID="imagePreview2" runat="server" ImageUrl="/Admin/Imoveis/Img/thumSemFoto.jpg"
                            onclick="openFileUploader2();" CssClass="image-preview" Style="cursor: pointer; width: 150px;" />

                        <!-- Asp:FileUpload 4 -->
                        <asp:FileUpload ID="fileUpload3" runat="server" CssClass="file-upload" onchange="previewImage3(this);" Style="display: none;" />
                        <asp:Image ID="imagePreview3" runat="server" ImageUrl="/Admin/Imoveis/Img/thumSemFoto.jpg"
                            onclick="openFileUploader3();" CssClass="image-preview" Style="cursor: pointer; width: 150px;" />

                        <!-- Asp:FileUpload 5 -->
                        <asp:FileUpload ID="fileUpload4" runat="server" CssClass="file-upload" onchange="previewImage4(this);" Style="display: none;" />
                        <asp:Image ID="imagePreview4" runat="server" ImageUrl="/Admin/Imoveis/Img/thumSemFoto.jpg"
                            onclick="openFileUploader4();" CssClass="image-preview" Style="cursor: pointer; width: 150px;" />

                        <!-- Asp:FileUpload 6 -->
                        <asp:FileUpload ID="fileUpload5" runat="server" CssClass="file-upload" onchange="previewImage5(this);" Style="display: none;" />
                        <asp:Image ID="imagePreview5" runat="server" ImageUrl="/Admin/Imoveis/Img/thumSemFoto.jpg"
                            onclick="openFileUploader5();" CssClass="image-preview" Style="cursor: pointer; width: 150px;" />
                        <!-- Botão de envio das imagens -->
                        <div id="numeroImagensCarregadas" class="numeroImagensCarregadas">Nenhuma Imagem Carregada</div>


                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" CssClass="inserir-fotos-btn botao-direita" />

                    </div>
                </form>
            </div>
        </div>

        <!-- Script JavaScript para Pré-Visualização da Imagem -->
        <script type="text/javascript">
            function openFileUploader() {
                // Chama a função click do controle <asp:FileUpload>
                document.getElementById('<%= fileUpload.ClientID %>').click();
            }
            function openFileUploader1() {
                // Chama a função click do controle <asp:FileUpload>
                document.getElementById('<%= fileUpload1.ClientID %>').click();
            }
            function openFileUploader2() {
                // Chama a função click do controle <asp:FileUpload>
                document.getElementById('<%= fileUpload2.ClientID %>').click();
            }
            function openFileUploader3() {
                // Chama a função click do controle <asp:FileUpload>
                document.getElementById('<%= fileUpload3.ClientID %>').click();
            }
            function openFileUploader4() {
                // Chama a função click do controle <asp:FileUpload>
                document.getElementById('<%= fileUpload4.ClientID %>').click();
            }
            function openFileUploader5() {
                // Chama a função click do controle <asp:FileUpload>
                document.getElementById('<%= fileUpload5.ClientID %>').click();
            }
        </script>


        <script type="text/javascript">
            var numeroImagens = 0; // Inicialmente, não há imagens carregadas
            function previewImage(input) {
                if (input.files && input.files[0]) {
                    var file = input.files[0];
                    var fileType = file.type.toLowerCase();

                    // Verifica se o arquivo é uma imagem
                    if (fileType === 'image/jpeg' || fileType === 'image/jpg' || fileType === 'image/png' || fileType === 'image/gif') {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            // Atualiza a propriedade src do controle <asp:Image> com a imagem carregada
                            document.getElementById('<%= imagePreview.ClientID %>').src = e.target.result;
                            numeroImagens++;
                            // Atualiza o texto do div com o número de imagens carregadas
                            document.getElementById('numeroImagensCarregadas').textContent = numeroImagens + (numeroImagens === 1 ? ' imagem carregada' : ' imagens carregadas');
                        };
                        reader.readAsDataURL(file);
                    } else {
                        // Se o arquivo não for uma imagem, exiba uma mensagem de erro
                        alert('Por favor, selecione um arquivo de imagem válido (JPEG, JPG, PNG ou GIF).');
                        // Limpe o controle <asp:FileUpload>
                        input.value = '';
                    }
                }
            }
            function previewImage1(input) {
                if (input.files && input.files[0]) {
                    var file = input.files[0];
                    var fileType = file.type.toLowerCase();

                    // Verifica se o arquivo é uma imagem
                    if (fileType === 'image/jpeg' || fileType === 'image/jpg' || fileType === 'image/png' || fileType === 'image/gif') {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            // Atualiza a propriedade src do controle <asp:Image> com a imagem carregada
                            document.getElementById('<%= imagePreview1.ClientID %>').src = e.target.result;
                            numeroImagens++;
                            // Atualiza o texto do div com o número de imagens carregadas
                            document.getElementById('numeroImagensCarregadas').textContent = numeroImagens + (numeroImagens === 1 ? ' imagem carregada' : ' imagens carregadas');
                        };
                        reader.readAsDataURL(file);
                    } else {
                        // Se o arquivo não for uma imagem, exiba uma mensagem de erro
                        alert('Por favor, selecione um arquivo de imagem válido (JPEG, JPG, PNG ou GIF).');
                        // Limpe o controle <asp:FileUpload>
                        input.value = '';
                    }
                }
            }
            function previewImage2(input) {
                if (input.files && input.files[0]) {
                    var file = input.files[0];
                    var fileType = file.type.toLowerCase();

                    // Verifica se o arquivo é uma imagem
                    if (fileType === 'image/jpeg' || fileType === 'image/jpg' || fileType === 'image/png' || fileType === 'image/gif') {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            // Atualiza a propriedade src do controle <asp:Image> com a imagem carregada
                            document.getElementById('<%= imagePreview2.ClientID %>').src = e.target.result;
                            numeroImagens++;
                            // Atualiza o texto do div com o número de imagens carregadas
                            document.getElementById('numeroImagensCarregadas').textContent = numeroImagens + (numeroImagens === 1 ? ' imagem carregada' : ' imagens carregadas');
                        };
                        reader.readAsDataURL(file);
                    } else {
                        // Se o arquivo não for uma imagem, exiba uma mensagem de erro
                        alert('Por favor, selecione um arquivo de imagem válido (JPEG, JPG, PNG ou GIF).');
                        // Limpe o controle <asp:FileUpload>
                        input.value = '';
                    }
                }
            }
            function previewImage3(input) {
                if (input.files && input.files[0]) {
                    var file = input.files[0];
                    var fileType = file.type.toLowerCase();

                    // Verifica se o arquivo é uma imagem
                    if (fileType === 'image/jpeg' || fileType === 'image/jpg' || fileType === 'image/png' || fileType === 'image/gif') {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            // Atualiza a propriedade src do controle <asp:Image> com a imagem carregada
                            document.getElementById('<%= imagePreview3.ClientID %>').src = e.target.result;
                            numeroImagens++;
                            // Atualiza o texto do div com o número de imagens carregadas
                            document.getElementById('numeroImagensCarregadas').textContent = numeroImagens + (numeroImagens === 1 ? ' imagem carregada' : ' imagens carregadas');
                        };
                        reader.readAsDataURL(file);
                    } else {
                        // Se o arquivo não for uma imagem, exiba uma mensagem de erro
                        alert('Por favor, selecione um arquivo de imagem válido (JPEG, JPG, PNG ou GIF).');
                        // Limpe o controle <asp:FileUpload>
                        input.value = '';
                    }
                }
            }
            function previewImage4(input) {
                if (input.files && input.files[0]) {
                    var file = input.files[0];
                    var fileType = file.type.toLowerCase();

                    // Verifica se o arquivo é uma imagem
                    if (fileType === 'image/jpeg' || fileType === 'image/jpg' || fileType === 'image/png' || fileType === 'image/gif') {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            // Atualiza a propriedade src do controle <asp:Image> com a imagem carregada
                            document.getElementById('<%= imagePreview4.ClientID %>').src = e.target.result;
                            numeroImagens++;
                            // Atualiza o texto do div com o número de imagens carregadas
                            document.getElementById('numeroImagensCarregadas').textContent = numeroImagens + (numeroImagens === 1 ? ' imagem carregada' : ' imagens carregadas');
                        };
                        reader.readAsDataURL(file);
                    } else {
                        // Se o arquivo não for uma imagem, exiba uma mensagem de erro
                        alert('Por favor, selecione um arquivo de imagem válido (JPEG, JPG, PNG ou GIF).');
                        // Limpe o controle <asp:FileUpload>
                        input.value = '';
                    }
                }
            }

            function previewImage5(input) {
                if (input.files && input.files[0]) {
                    var file = input.files[0];
                    var fileType = file.type.toLowerCase();

                    // Verifica se o arquivo é uma imagem
                    if (fileType === 'image/jpeg' || fileType === 'image/jpg' || fileType === 'image/png' || fileType === 'image/gif') {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            // Atualiza a propriedade src do controle <asp:Image> com a imagem carregada
                            document.getElementById('<%= imagePreview5.ClientID %>').src = e.target.result;
                            numeroImagens++;
                            // Atualiza o texto do div com o número de imagens carregadas
                            document.getElementById('numeroImagensCarregadas').textContent = numeroImagens + (numeroImagens === 1 ? ' imagem carregada' : ' imagens carregadas');
                        };
                        reader.readAsDataURL(file);
                    } else {
                        // Se o arquivo não for uma imagem, exiba uma mensagem de erro
                        alert('Por favor, selecione um arquivo de imagem válido (JPEG, JPG, PNG ou GIF).');
                        // Limpe o controle <asp:FileUpload>
                        input.value = '';
                    }
                }
            }
        </script>

        <!-- Script JavaScript para controlar o modal -->
        <script>
            // JavaScript

            // Seleciona o botão "Inserir Fotos" e o modal
            const abrirModalBtn = document.getElementById("abrir-modal");
            const modal = document.getElementById("myModal");

            // Seleciona o botão de fechar o modal
            const fecharModalBtn = document.getElementById("fechar-modal");

            // Abre o modal ao clicar no botão "Inserir Fotos"
            abrirModalBtn.addEventListener("click", () => {
                modal.style.display = "block";
            });

            // Fecha o modal ao clicar no botão de fechar
            fecharModalBtn.addEventListener("click", () => {
                modal.style.display = "none";
            });

            // Fecha o modal ao clicar fora do modal
            window.addEventListener("click", (event) => {
                if (event.target === modal) {
                    modal.style.display = "none";
                }
            });
        </script>

    </section>

    <!-- Seção property-details -->
    <section class="property-details">
        <div class="property-info">
            <h2 style="color: #333;">
                <asp:Label ID="lblTitulo" runat="server"></asp:Label><br />
            </h2>
            <p>
                <strong>Tipo:</strong>
                <asp:Label ID="lblTipo" runat="server"></asp:Label>
            </p>
            <p>
                <strong>Localização:</strong>
                <asp:Label ID="lblEstado" runat="server"></asp:Label>
                - 
                <asp:Label ID="lblCidade" runat="server"></asp:Label>
                -
                <asp:Label ID="lblLocal" runat="server"></asp:Label>
            </p>
            <p><strong>Número de Quartos:</strong> -</p>
            <p><strong>Número de Banheiros:</strong> -</p>
            <p><strong>Garagem:</strong> -</p>
            <p>
                <strong>Valor:</strong>
                <asp:Label ID="lblValor" runat="server"></asp:Label>
            </p>
        </div>
        <div class="property-image">
            <asp:Image ID="imgCapa" runat="server" Style="width: 200px;  height: auto; border: 1px solid #ccc; box-shadow: 0 0 5px rgba(0, 0, 0, 0.2);" />

        </div>
    </section>

    <!-- Seção property-gallery -->
    <section class="property-gallery">
        <h3 style="color: #333;">Galeria de Fotos</h3>
        <div class="image-gallery" style="display: flex; flex-wrap: wrap; justify-content: space-between; margin-top: 10px;">
            <asp:Repeater ID="rptImagens" runat="server">
                <ItemTemplate>
                    <asp:Image ID="imgImagem" runat="server" ImageUrl='<%# "/Imoveis/Imagens/" + Eval("Imagem") %>'
                        AlternateText='<%# Eval("TituloImagem") %>'
                        Style="max-width: calc(20% - 10px); margin: 5px; border: 1px solid #ccc; box-shadow: 0 0 5px rgba(0, 0, 0, 0.2);" />
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </section>

    <!-- Seção property-description -->
    <section class="property-description">
        <h3 style="color: #333;">Descrição do Imóvel</h3>
        <p>
            <asp:Label ID="lblDesc" runat="server"></asp:Label>
        </p>
    </section>
</asp:Content>
