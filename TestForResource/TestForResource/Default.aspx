<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestForResource._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div style="font-size:60px; font-style:italic;">
        <asp:Label ID="Label0" runat="server"></asp:Label>
    </div>


    <div style="font-size:30px;">
        <asp:Label ID="Label1" runat="server" meta:resourcekey="Label1" Text="DefaultText"></asp:Label>
    </div>



</asp:Content>
