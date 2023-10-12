<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="CadastroImoveis.aspx.cs" Inherits="wgvmi.Admin.Imoveis.CadastroImoveis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/5.0.6/jquery.inputmask.min.js"></script>

    <link href="../css/imoveis.css" rel="stylesheet" />

    <form id="form1" runat="server" enctype="multipart/form-data">
        <!-- Bloco Foto de Capa -->
        <div class="form-group">
            <label for="fileUpload" class="file-label">Foto de Capa:</label>
            <asp:FileUpload ID="fileUpload" runat="server" CssClass="file-upload" onchange="previewImage(this);" Style="display: none;" />

            <br />
            <asp:Image ID="imagePreview" runat="server" ImageUrl="/Admin/Imoveis/Img/thumSemFoto.jpg" CssClass="image-preview"
                onclick="openFileUploader();" />

            <br />
            <div id="divMensagemErro" class="error-message" style="display: none;"></div>
        </div>

        <!-- Bloco Título -->
        <div class="form-group form-group-inline-title-type error-tooltip">
            <asp:Label ID="lblTitulo" runat="server" Text="Título:" AssociatedControlID="txtTitulo" />
            <asp:TextBox ID="txtTitulo" runat="server" CssClass="input-field" />
            <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo"
                InitialValue="" Display="Dynamic"
                ErrorMessage="O campo Título não pode ficar em branco." CssClass="error-message" />

            <asp:RegularExpressionValidator ID="revTitulo" runat="server" ControlToValidate="txtTitulo"
                Display="Dynamic"
                ValidationExpression=".{10,}"
                ErrorMessage="O título deve conter no mínimo 10 caracteres." CssClass="error-message" />
        </div>

        <!-- Bloco Tipo -->
        <div class="form-group form-group-inline-title-type error-tooltip">
            <asp:Label ID="lblTipo" runat="server" Text="Tipo:" AssociatedControlID="ddlTipo" />
            <asp:DropDownList ID="ddlTipo" runat="server" CssClass="input-field">
                <asp:ListItem Text="Selecione" Value="0"></asp:ListItem>
                <asp:ListItem Text="Casa" Value="Casa"></asp:ListItem>
                <asp:ListItem Text="Sitio" Value="Sitio"></asp:ListItem>
                <asp:ListItem Text="Terreno" Value="Terreno"></asp:ListItem>
                <asp:ListItem Text="Área Comercial" Value="Area Comercial"></asp:ListItem>
                <asp:ListItem Text="Galpão" Value="Galpão"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvTipo" runat="server" ControlToValidate="ddlTipo"
                InitialValue="0" Display="Dynamic"
                ErrorMessage="Selecione o tipo do imóvel." CssClass="error-message" />
        </div>

        <!-- Bloco Preço de Venda -->
        <div class="form-group form-group-inline-title-type error-tooltip">
            <asp:Label ID="lblPrecoVenda" runat="server" Text="Preço de Venda:" AssociatedControlID="txtPrecoVenda" />
            <asp:TextBox ID="txtPrecoVenda" runat="server" CssClass="input-field" onfocus="applyCurrencyMask(this)" />
            <asp:RequiredFieldValidator ID="rfvPreco" runat="server" ControlToValidate="txtPrecoVenda"
                InitialValue="" Display="Dynamic" ErrorMessage="O campo de preço é obrigatório." CssClass="error-message" />
        </div>

        <!-- Bloco Estado -->
        <div class="form-group form-group-inline error-tooltip">
            <asp:Label ID="lblEstado" runat="server" Text="Estado:" AssociatedControlID="ddlEstado" />
            <asp:DropDownList ID="ddlEstado" runat="server" CssClass="input-field">
                <asp:ListItem Text="Selecione" Value="0"></asp:ListItem>
                <asp:ListItem Text="Rio de Janeiro" Value="Rio de Janeiro"></asp:ListItem>
                <asp:ListItem Text="São Paulo" Value="São Paulo"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado"
                InitialValue="0" Display="Dynamic"
                ErrorMessage="Selecione o estado." CssClass="error-message" />
        </div>

        <!-- Bloco Cidade -->
        <div class="form-group form-group-inline error-tooltip">
            <asp:Label ID="lblCidade" runat="server" Text="Cidade:" AssociatedControlID="txtCidade" />
            <asp:TextBox ID="txtCidade" runat="server" CssClass="input-field" />
            <asp:RequiredFieldValidator ID="rfvCidade" runat="server" ControlToValidate="txtCidade"
                InitialValue="" Display="Dynamic"
                ErrorMessage="O campo Cidade não pode ficar em branco." CssClass="error-message" />
        </div>

        <!-- Bloco Bairro -->
        <div class="form-group form-group-inline error-tooltip">
            <asp:Label ID="lblBairro" runat="server" Text="Bairro:" AssociatedControlID="txtBairro" />
            <asp:TextBox ID="txtBairro" runat="server" CssClass="input-field" />
            <asp:RequiredFieldValidator ID="rfvBairro" runat="server" ControlToValidate="txtBairro"
                InitialValue="" Display="Dynamic"
                ErrorMessage="O campo Bairro não pode ficar em branco." CssClass="error-message" />
        </div>

        <!-- Bloco Endereço -->
        <div class="form-group error-tooltip">
            <asp:Label ID="lblEndereco" runat="server" Text="Endereço:" AssociatedControlID="txtEndereco" />
            <asp:TextBox ID="txtEndereco" runat="server" CssClass="input-field" />
            <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" ControlToValidate="txtEndereco"
                InitialValue="" Display="Dynamic"
                ErrorMessage="O campo Endereço não pode ficar em branco." CssClass="error-message" />
        </div>

        <!-- Bloco Descrição -->
        <div class="form-group">
            <asp:Label ID="lblDescricao" runat="server" Text="Descrição:" AssociatedControlID="txtDescricao" />
            <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" CssClass="input-field" Rows="10" />
            <asp:RequiredFieldValidator ID="rfvDescricao" runat="server" ControlToValidate="txtDescricao"
                InitialValue="" Display="Dynamic" ForeColor="Red"
                ErrorMessage="O campo Descrição não pode ficar em branco." />
        </div>

        <!-- Botão Salvar -->
        <div class="form-group">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn-salvar" OnClick="btnSalvar_Click" />
        </div>

        <!-- Script JavaScript para Pré-Visualização da Imagem -->
        <script type="text/javascript">
            function openFileUploader() {
                // Chama a função click do controle <asp:FileUpload>
                document.getElementById('<%= fileUpload.ClientID %>').click();
            }
        </script>

        <script type="text/javascript">
           function previewImage(input) {
               if (input.files && input.files[0]) {
                   var fileName = input.files[0].name;
                   var fileExtension = fileName.split('.').pop().toLowerCase();

                   // Verifica se a extensão é uma imagem suportada (por exemplo, jpg, jpeg, png, gif)
                   if (fileExtension === 'jpg' || fileExtension === 'jpeg' || fileExtension === 'png' || fileExtension === 'gif') {
                       var reader = new FileReader();
                       reader.onload = function (e) {
                           // Atualiza a propriedade src do controle <asp:Image> com a imagem carregada
                           document.getElementById('<%= imagePreview.ClientID %>').src = e.target.result;

                    // Esconde a mensagem de erro, se estiver visível
                    document.getElementById('divMensagemErro').style.display = 'none';
                };
                reader.readAsDataURL(input.files[0]);
            } else {
                var mensagemErro = "A extensão do arquivo de imagem é inválida. Por favor, selecione um arquivo de imagem válido.";
                // Exibe a mensagem de erro e define a imagem padrão
                document.getElementById('divMensagemErro').innerText = mensagemErro;
                document.getElementById('divMensagemErro').style.display = 'block';
                document.getElementById('<%= imagePreview.ClientID %>').src = "/Admin/Imoveis/Img/thumSemFoto.jpg"; // Substitua pelo caminho da imagem padrão
                   }
               }
           }
        </script>

        <script type="text/javascript">
            function applyCurrencyMask(input) {
                // Configura a máscara de moeda brasileira
                var options = {
                    alias: 'numeric',
                    radixPoint: ',',
                    groupSeparator: '.',
                    autoGroup: true,
                    prefix: 'R$ ',
                    numericInput: true
                };

                // Aplica a máscara ao campo Preço de Venda
                $(input).inputmask(options);
            }
        </script>
    </form>
</asp:Content>