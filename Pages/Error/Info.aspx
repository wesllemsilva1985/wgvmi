<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="wgvmi.Pages.Error.Info" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Manutenção em Andamento</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f2f2f2;
            text-align: center;
            padding: 100px;
        }

        .maintenance-container {
            background-color: #fff;
            border-radius: 10px;
            padding: 20px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.3);
        }

        h1 {
            color: #ff5555;
        }

        p {
            font-size: 18px;
            color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="maintenance-container">
            <h1>Manutenção em Andamento</h1>
            <p>Nosso site está passando por uma atualização e está temporariamente fora do ar. Pedimos desculpas pelo inconveniente.</p>
            <p>Estamos trabalhando para melhorar a sua experiência. Por favor, tente novamente em breve.</p>
        </div>
    </form>
</body>
</html>
