<%--資源檔隱式設定方法
1.要使用資源的檔案為[TestWebPage.aspx]時,資源檔名必需為[TestWebPage.aspx.resx],aspx這個副檔名不可以少
2.使用資源檔的該行物件需為server端物件,一般物件沒用,所以需要是asp:xxx這樣形式的,且必須加上runat="server"
3.另外該行物件需加上meta:resourcekey="Label1"這樣的標示,如果是要帶入到這個物件的Text屬性,那資源檔那邊的[名稱]就設置為Label1.Text,[值]就設置為要顯示的字
--%>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestWebPage.aspx.cs" Inherits="TestForResource.TestPage.TestWebPage" %>
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

