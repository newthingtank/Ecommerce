<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="MoreEcommerce.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Form</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label runat="server" Text ="Customer #" ID="lblCustomerNo"></asp:Label>
        <asp:TextBox runat="server" ID ="txtCustomerNo"></asp:TextBox>
        <br/>
         
        <asp:Label runat="server" Text ="First Name" ID="lblFirstName"></asp:Label>
        <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
        <br />

        <asp:Label runat="server" Text ="Last Name" ID="lblLastName"></asp:Label>
        <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
        <br />

        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />&nbsp;
        <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" />&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />&nbsp;
        <br /> <br />

        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
