<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalogue.aspx.cs" Inherits="MoreEcommerce.Catalogue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalogue</title>
    <link href="/styles/main.css" rel="stylesheet" />
</head>
<body class="Panels">
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tblProducts" runat="server" BorderColor="Black" BorderWidth="1px" BorderStyle="Solid" CellPadding="5" CellSpacing="0">
            <asp:TableHeaderRow CssClass="TableHeader">
                <asp:TableCell></asp:TableCell>
                <asp:TableCell>Product #</asp:TableCell>
                <asp:TableCell>Name</asp:TableCell>
                <asp:TableCell>Price</asp:TableCell>                
                <asp:TableCell></asp:TableCell>
            </asp:TableHeaderRow>
        </asp:Table>
        <asp:Button ID="btnAddToCart" runat="server" Text="Add To Cart"
            style="visibility: hidden;" OnClick="btnAddToCart_Click" />
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
