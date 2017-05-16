<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="MoreEcommerce.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblProdID" runat="server" Text="Product ID"></asp:Label>
        <asp:TextBox ID="txtProdID" runat="server" style="margin-left: 43px"></asp:TextBox>

        <!--Validation controls
            --perform testing on the client side
            --natively use JQuery to do client side validation
            --require unobtrusive to be set to none in the web configuration file
              so the JQuery library is not required or JQuery doesn't have to be registered on the page
            -->
        

        <asp:RequiredFieldValidator ID="rfvProdID" runat="server" ErrorMessage="Product ID is a required field"
            ControlToValidate="txtProdID" ></asp:RequiredFieldValidator>
        <br />
        
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" style="margin-left: 75px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is a required field"
            ControlToValidate="txtName" ></asp:RequiredFieldValidator>
        <br />

        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server" style="margin-left: 82px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPrice" runat="server"
         ControlToValidate="txtPrice" ErrorMessage="Price is a required field">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revPrice" runat="server"
         ControlToValidate="txtPrice" ErrorMessage="The price is not valid"
        ValidationExpression="^([0-9]{3}, ([0-9]{3},)*[0-9]{3}|[0-9]+)(.[0-9][0-9])?$">*</asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="lblPhone" runat="server" Text="Supplier Phone"></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server" style="margin-left: 21px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Supplier Phone is a required field"
        ControlToValidate="txtPhone" ></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revPhone" runat="server" 
            ErrorMessage="The phone is not in a valid format" ControlToValidate="txtPhone" 
            ValidationExpression="^(?:\([2-9]\d{2}\)\ ?|[2-9]\d{2}(?:\-?|\ ?))[2-9]\d{2}[- ]?\d{4}$">*</asp:RegularExpressionValidator>
        <br />

        <asp:Label ID="lblImage" runat="server" Text="Image"></asp:Label>
        <asp:FileUpload ID="fulImage" runat="server" style="margin-left: 77px" />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        <br />
        <asp:ValidationSummary ID="vsValidationErrors" runat="server" />
        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>

    </div>
    </form>
</body>
</html>
