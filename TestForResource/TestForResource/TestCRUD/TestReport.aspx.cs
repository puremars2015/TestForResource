using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestCRUD
{
    public partial class TestReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
      
            if (!this.IsPostBack)
            {
                var dd1v = new List<string>();

                for (int i = 2020; i <= 2024; i++)
                {
                    dd1v.Add(i.ToString());
                }

                this.DropDownList1.DataSource = dd1v;
                this.DropDownList1.DataBind();


                var dd2v = new List<string>();

                for (int i = 1; i <= 12; i++)
                {
                    dd2v.Add(string.Format("{0:00}", i));
                }


                this.DropDownList2.DataSource = dd2v;
                this.DropDownList2.DataBind();
            }


        }





        private DataTable GetData(string SQL)
        {

            string ConnectionString = ConfigurationManager.ConnectionStrings["ToERP"].ToString();

            DbConnection objConnection = SqlClientFactory.Instance.CreateConnection();

            objConnection.ConnectionString = ConnectionString;

            objConnection.Open();

            DbCommand objCommand = SqlClientFactory.Instance.CreateCommand();

            objCommand.Connection = objConnection;

            objCommand.CommandText = SQL;

            DbDataReader objDataReader = objCommand.ExecuteReader();

            var dt = new DataTable();

            dt.Load(objDataReader);

            objDataReader.Close();

            return dt;

        }

        private List<dynamic> GetDataByDapper(string sql)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ToERP"].ToString();
            var conn = new SqlConnection(ConnectionString);
            var results = conn.Query(sql).ToList();

            return results;
        }

        private DataTable GetDataWithRetry(string sql)
        {
            var retryCount = 0;
            var retryLimit = 3;
            var retryInterval = 1000;

            while (true)
            {
                try
                {
                    return GetData(sql);
                }
                catch (Exception ex)
                {
                    if (retryCount < retryLimit)
                    {
                        retryCount++;
                        Thread.Sleep(retryInterval);
                    }
                    else
                    {
                        throw ex;
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var year = this.DropDownList1.Text;
            var month = this.DropDownList2.Text;

            var sql = @"

--iemt11h 取出要結算的料號
--iemt00h 庫存的表頭 C1R1上半部
--iemt00d1庫存的表身 C1R1下半部的庫存現況
--iemt03d1庫存的異動表 C1R1下半部的異動明細


WITH m AS 
(
	SELECT A.mt_yy, 
	A.el_no
	FROM iemt11h A
	WHERE A.mt_yy = '{year}' 
	AND el_no IS NOT NULL
	AND el_no <> ''
	AND A.mt_qty{month} <> 0  -- mt_qty+二碼月份
	AND el_no NOT LIKE '9%'
), d2 AS
(	
	-- 用iemt03d1組合出最後一張驗收入庫或完工入庫的異動單
	SELECT t1.lot_no,t1.el_no,t1.mt_list,t1.mt_date 
	FROM iemt03d1 t1 
	JOIN 
	(
		SELECT el_no,max(mt_list)mt_list,max(mt_date)last_mt_date 
		FROM iemt03d1
		WHERE (mt_code = 'A' OR mt_code = 'B') AND el_no NOT LIKE '9%'
		GROUP BY el_no
	) t2
	ON t1.el_no = t2.el_no AND t1.mt_date = t2.last_mt_date AND t1.mt_list = t2.mt_list
	WHERE lot_no <> '' AND lot_no IS NOT NULL
	GROUP BY t1.lot_no,t1.el_no,t1.mt_list,t1.mt_date 
)

SELECT 
	m.mt_yy 年份
	,m.el_no 料號
	,d1.lot_no 批號
	,d1.mt_area 庫位
	,d1.mt_qty 庫存數量
	,d2.mt_date '驗收日期(異動日期)'
	,d2.mt_list '驗收單號(單據編號)'
FROM m
LEFT JOIN iemt00h h ON m.el_no = h.el_no
LEFT JOIN iemt00d1 d1 ON m.el_no = d1.el_no
LEFT JOIN d2 ON m.el_no = d2.el_no AND d1.lot_no = d2.lot_no
"
            ;

            sql = sql.Replace("{year}", year).Replace("{month}", month);
            var dt = GetData(sql);

            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();
        }
    }
}