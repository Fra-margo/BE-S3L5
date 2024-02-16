<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Esercizio_be_s3l5.ProductDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Product Details</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            background-color: lightsteelblue;
        }
        img{
            max-height: 250px;
        }
        .card {
            width: 500px;
            background-color: aliceblue;
        }
        h1, h5 {
            color: darkblue;
            font-weight: bold;
        }
        p {
            color: slateblue;
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container mt-5">
             <h1 class="mt-5 mb-4">Scheda Prodotto</h1>
            <% var productId = int.Parse(Request.QueryString["id"]); %>
            <% var product = Products.GetAllProducts().Find(p => p.Id == productId); %>
            <div class="card">
                <img class="card-img-top" src="<%= product.ImageUrl %>" alt="<%= product.Name %>">
                <div class="card-body">
                    <h5 class="card-title"><%= product.Name %></h5>
                    <p class="card-text">Prezzo: € <%= product.Price %></p>
                    <p class="card-text">Descrizione: <%= product.Description %></p>
                    <div class="card-body d-flex justify-content-between">
                        <asp:Button runat="server" Text="Aggiungi al carrello" OnClick="AddToCart_Click" CssClass="btn btn-primary" />
                        <asp:Button runat="server" Text="Torna alla HomePage" OnClick="ReturnToHomePage_Click" CssClass="btn btn-secondary" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
