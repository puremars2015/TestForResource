<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestUCMain.aspx.cs" Inherits="TestForResource.TestUC.TestUCMain" %>

<%@ Register Src="~/TestUC/TestUCItem.ascx" TagPrefix="uc1" TagName="uc1Name" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <uc1:uc1Name ID="uc1Name1" runat="server"></uc1:uc1Name>
    <uc1:uc1Name ID="uc1Name2" runat="server"></uc1:uc1Name>
    <uc1:uc1Name ID="uc1Name3" runat="server"></uc1:uc1Name>
</asp:Content>
