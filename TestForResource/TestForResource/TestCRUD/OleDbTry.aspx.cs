using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestCRUD
{
    public partial class OleDbTry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var IP = "172.16.20.93";

                var conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;data source=\\" + IP + @"\Database\Web6000LotData.mdb");

                var dt = new DataTable();

                using (var conection = conn)
                {
                    conection.Open();
                    var query = @"
SELECT LotNumber,ShowNumber  
FROM LotTable 
WHERE StartTime>#2023/03/28 11:31:53# 
AND StartTime<#2023/03/28 15:31:53# 
ORDER BY LotNumber DESC";
                    var adapter = new OleDbDataAdapter(query, conection);
                
                    adapter.Fill(dt);
                }

                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();

            }
            catch(Exception ex)
            {
                this.Label1.Text = ex.Message;
            }
        }
    }
}