<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestPage2.aspx.cs" Inherits="TestForResource.TestPage2.TestPage2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" style="font-size:50px;" runat="server" meta:resourcekey="Label1"></asp:Label>
    </div>
    <div>

        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />

    </div>
    <div>

        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />

    </div>
    <div>

        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />

    </div>
</asp:Content>
