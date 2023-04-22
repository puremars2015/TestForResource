<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGrid.aspx.cs" Inherits="TestForResource.TestGrid.TestGrid" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TRACK_ID" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="TRACK_ID" HeaderText="TRACK_ID" ReadOnly="True" SortExpression="TRACK_ID" />
        <asp:BoundField DataField="TRACK_DESC" HeaderText="TRACK_DESC" SortExpression="TRACK_DESC" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:UOF116CS %>" SelectCommand="SELECT * FROM [TB_WKF_TRACK]"></asp:SqlDataSource>





</asp:Content>
