<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestReport.aspx.cs" Inherits="TestForResource.TestCRUD.TestReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">




        <div>
            <asp:Label id="Label1" Text="選擇年份與月份" runat="server"></asp:Label>
        </div>
        <div>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        <div>
            <asp:Button ID="Button1" Text="查詢" runat="server" OnClick="Button1_Click" />
        </div>
   
    </form>
</body>
</html>
