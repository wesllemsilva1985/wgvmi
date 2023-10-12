<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="wgvmi.Admin.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
            text-align: center;
        }
        
        .container {
            max-width: 600px;
            margin: 30px auto 0;
            padding: 20px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 255, 0.2); /* Alterado para cor azul clara */
        }

        h1 {
            color: #333;
        }

        .notice {
            background-color: #4caf50;
            color: #fff;
            padding: 10px;
            border-radius: 5px;
            margin-top: 20px;
        }

        p {
            font-size: 18px;
        }
    </style>

    <div class="container">
        <h1>Novas funcionalidades inseridas!</h1>
        <div class="notice">
            <p>Já é possível listar todas as fotos cadastradas para visualizar ou deletar uma a uma.</p>
        </div>
    </div>
   
</asp:Content>
