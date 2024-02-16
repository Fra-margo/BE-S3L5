<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Esercizio_be_s3l5.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>HomePage</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body{
            background-color: lightsteelblue;
        }
        img{
            max-height: 200px;
        }
        .card {
            height: 100%;
            background-color: aliceblue;
        }
        h1, h5{
            color: darkblue;
        }
        p{
            color: slateblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="mt-5 mb-4">Prodotti disponibili</h1>
            <asp:HyperLink runat="server" NavigateUrl="~/Cart.aspx" Text="Vai al Carrello" CssClass="btn btn-primary mb-3" />
            <div class="row">
                <% foreach (var product in Products.GetAllProducts()) { %>
                    <div class="col-lg-4 col-md-6 mb-4">
                        <div class="card">
                            <img class="card-img-top" src="<%= product.ImageUrl %>" alt="<%= product.Name %>">
                            <div class="card-body">
                                <h5 class="card-title"><%= product.Name %></h5>
                                <p class="card-text">Prezzo: € <%= product.Price %></p>
                                <a href="ProductDetails.aspx?id=<%= product.Id %>" class="btn btn-primary">Dettagli</a>
                            </div>
                        </div>
                    </div>
                <% } %>
            </div>
        </div>
    </form>
</body>
</html>
