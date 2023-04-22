<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestReadForm.aspx.cs" Inherits="TestForResource.TestCRUD.TestReadForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            <asp:Label id="Label1" runat="server"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"></asp:GridView>
        </div>
        <div>
            <asp:GridView ID="GridView2" runat="server"></asp:GridView>
        </div>
   
    </form>
</body>
</html>
