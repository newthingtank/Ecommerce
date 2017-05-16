<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MoreEcommerce.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Super Awesome things Store</title>
    <link href="/styles/main.css" type="text/css" rel="stylesheet" />
</head>
<body style="background-color:black;">

    <form id="form1" runat="server">
    <div>

        <asp:Button ID="btnCatalogue" runat="server" Text="Catalogue" OnClick="btnCatalogue_Click" />
        <asp:Button ID="btnCart" runat="server" Text="Cart" OnClick="btnCart_Click" />
        <iframe id="CustomerFrame" name="Customers" src="Catalogue.aspx" runat="server">
        </iframe>
       
    </div>
    </form>
</body>
</html>
