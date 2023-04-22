<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TestUCItem.ascx.cs" Inherits="TestForResource.TestUC.TestUCItem" %>



<ol>
    <li>
        <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
        <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
    </li>
    <li>
        <asp:Label ID="lblAge" runat="server" Text="Age"></asp:Label>
        <asp:TextBox ID="tbAge" runat="server"></asp:TextBox>
    </li>
</ol>