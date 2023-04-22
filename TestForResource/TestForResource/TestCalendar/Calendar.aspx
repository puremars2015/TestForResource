<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="TestForResource.TestCalendar.Calendar" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="//code.jquery.com/jquery-3.6.0.min.js"></script>
    <style>
        table {
            border-collapse: collapse;
            width: 100%;
            text-align: center;
        }

        th, td {
            border: 1px solid #ccc;
            padding: 10px;
        }

        th {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <thead>
                    <tr>
                        <th>Sun</th>
                        <th>Mon</th>
                        <th>Tue</th>
                        <th>Wed</th>
                        <th>Thu</th>
                        <th>Fri</th>
                        <th>Sat</th>
                    </tr>
                </thead>
                <tbody>
                    <% for (int i = 0, k = 0; i < this.Weeks; i++){ %>

                    <tr>
                        <% for (int j = 0; j < 7; j++, k++){ %>
                        <td>
                            <div>
                                <label><%=Date[k].Date.ToString("MM") %>月</label>
                                <label><%=Date[k].Date.ToString("dd") %>日</label>
                            </div>
                   
                            <div>
                                <label>機台名稱:PEL3</label>
                                <br />
                                <label>預計運行時數:</label>
                                <input style="width:50px" id="hours" value="" />
                            </div>

                            <div>
                                <input class="ButtonSave" type="button" value="保存"/>
                            </div>

                         
                        </td>
                        <% } %>
                    </tr>

                    <%}%>
                </tbody>
            </table>

        </div>
    </form>

    <script>
        $(document).ready(function () {
            $('.ButtonSave').click(function (sn) {
                let name = 'OK';

                $.ajax({
                    type: "POST",
                    url: "Calendar.aspx/SayHello",
                    data: JSON.stringify({ name: name }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response.d);
                    },
                    error: function (e) {
                        console.log(e);
                    }
                });
            });
        });
    </script>
</body>
</html>
