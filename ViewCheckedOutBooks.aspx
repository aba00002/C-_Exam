<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ViewCheckedOutBooks.aspx.cs" Inherits="ViewCheckedOutBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Algonquin College Book Store</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body> 
    <div class="center">
        <h1 style="text-align:center">Algonquin College Book Store</h1>
        <form id="form1" runat="server">
            <div>
            <p>You have checked out <asp:Label runat="server" ID="lblNumCheckouts"></asp:Label> book(s): </p>
            <p>You can select one or more books and click the Remove button to move them from your checkout list</p>
            <asp:CheckBoxList runat="server" ID="lstCheckedOutBooks">
            </asp:CheckBoxList>
            <div>
                <br />
                <asp:Button runat="server" ID="btnRemove" Text="Remove" cssClass="button" OnClick="btnRemove_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;<a href="BookStore.aspx">Back to Book Store</a>
            </div>
            </div>
        </form>
    </div>
</body>
</html>
