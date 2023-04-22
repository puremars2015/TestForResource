<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCreateForm.aspx.cs" Inherits="TestForResource.TestCRUD.TestCreateForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #Select1 {
            width: 146px;
            height: 45px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 124px">
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:ListBox ID="ListBox1" runat="server" Width="254px"></asp:ListBox>
        </p>
        <p>
            &nbsp;</p>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
