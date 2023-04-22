<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestTreeView.aspx.cs" Inherits="TestForResource.TestTreeView.TestTreeView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">










    <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
    </asp:TreeView>
    <p>
    </p>
    <p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    </p>
    <p>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </p>










</asp:Content>
