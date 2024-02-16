<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Esercizio_be_s3l5.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cart</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            background-color: lightsteelblue;
        }
        h1, h5, #TotalLabel{
            color: darkblue;
        }
        p{
            color: slateblue;
        }
        .container {
            margin-top: 50px;
        }
        .cart-item {
            background-color: aliceblue;
            border-radius: 5px;
            margin-bottom: 20px;
            padding: 20px;
            width: 500px;
        }
        .btn-remove {
            margin-top: 10px;
        }
        .container{
            width: 530px;
        }
</style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="container">
            <h1 class="mt-5 mb-4">Carrello</h1>
            <div id="EmptyCartMessage" runat="server" visible="false" class="alert alert-info">
                Il carrello è vuoto.
            </div>
            <asp:Repeater ID="CartRepeater" runat="server">
                <ItemTemplate>
                    <div class="cart-item">
                        <div class="row">
                            <div class="col-md-8">
                                <h5><%# Eval("Name") %></h5>
                                <p>Prezzo: € <%# Eval("Price") %></p>
                                <p>Quantità: <%# Eval("Quantity") %></p>
                            </div>
                            <div class="col-md-4 d-flex align-items-center">
                                <asp:Button runat="server" Text="Rimuovi" CommandArgument='<%# Eval("Id") %>' OnClick="RemoveFromCart_Click" CssClass="btn btn-danger btn-remove" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
             <asp:Label runat="server" ID="TotalLabel" CssClass="mt-3 mb-3 font-weight-bold"></asp:Label>
            <div class="mt-3 d-flex justify-content-between">
                <asp:Button runat="server" Text="Svuota Carrello" OnClick="ClearCart_Click" CssClass="btn btn-secondary" />
                <asp:Button runat="server" Text="Torna alla HomePage" OnClick="ReturnToHomePage_Click" CssClass="btn btn-primary" />
            </div>
             
        </div>
    </form>
</body>
</html>
