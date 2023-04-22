<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TwoTierInOneRowColumn.aspx.cs" Inherits="TestForResource.TestGrid.TwoTierInOneRowColumn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID"
                        SortExpression="ID" />
                    <asp:BoundField DataField="orgID" HeaderText="母批"
                        SortExpression="orgID" />
                    <asp:BoundField DataField="matrlNo" HeaderText="料號"
                        SortExpression="matrlNo" />
                    <asp:BoundField DataField="MoID" HeaderText="膜"
                        SortExpression="MoID" />
                    <asp:TemplateField HeaderText="組合欄位">
                        <ItemTemplate>
                            <div style="border-bottom:1px solid black;text-align:center;">
                                <label>組合欄位ID</label>
                            </div>
                            <div style="border-bottom:1px solid black;text-align:center;">
                                <asp:Label ID="Label1" runat="server"
                                    Text='<%# Bind("ID") %>'></asp:Label>
                            </div>
                            <div style="border-bottom:1px solid black;text-align:center;">
                                <label>組合欄位OrgID</label>
                            </div>
                            <div style="text-align:center;">
                                <asp:Label ID="Label2" runat="server"
                                    Text='<%# Bind("matrlNo") %>'></asp:Label>
                            </div>
                        </ItemTemplate>

                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
