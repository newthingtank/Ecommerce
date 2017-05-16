<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="MoreEcommerce.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/styles/main.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="tblCart" runat="server" CellPadding="10"
            CellSpacing="0" BorderColor="Black" BorderWidth="1px"
            BorderStyle="Solid">            
        </asp:Table>
        <asp:Button ID="btnHiddenRemove" runat="server" 
                       style="visibility: hidden;" 
             OnClick ="btnHiddenRemove_Click" />
        Your total bill will be: <asp:Label ID="lblGrandTotal" 
             runat="server" Text="0.00"></asp:Label>
        <br />
        <asp:Button ID="btnRecalculate" runat="server" 
            Text="Recalculate Total" OnClick="btnRecalculate_Click" />
    </div>
    </form>
</body>
</html>
