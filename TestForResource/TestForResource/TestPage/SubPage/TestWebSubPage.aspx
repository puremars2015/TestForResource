<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestWebSubPage.aspx.cs" Inherits="TestForResource.TestPage.SubPage.TestWebSubPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        
    <div style="font-size:30px;">
        <asp:Label runat="server" meta:resourcekey="Label1">測試文字</asp:Label>
    </div>
    <div style="font-size:30px;">
        <asp:Label runat="server" meta:resourcekey="Label2" />
    </div>
    <div style="font-size:30px;">
        <asp:Label meta:resourcekey="Label2" />
    </div>
    <div style="font-size:30px;">
        <label meta:resourcekey="Label2"/>
    </div>
    <div style="font-size:30px;">
        <asp:Label runat="server">測試</asp:Label>
    </div>
</asp:Content>
