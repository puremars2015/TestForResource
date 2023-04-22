<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestUpdatePanel.aspx.cs" Inherits="TestForResource.TestUpdatePanel.TestUpdatePanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="height: 400px; width: 400px; background-color: aqua;">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="無資料" />
                <asp:Button ID="Button1" runat="server" Text="更新" OnClick="btn_Click" />
            </ContentTemplate>
          
        </asp:UpdatePanel>
    </div>

</asp:Content>

