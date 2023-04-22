using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestCRUD
{
    public partial class TestReadForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            
       

            var result = this.GetAllBeforeIDByID("GD01040101");


            // Some Code
            stopWatch.Stop();

            this.Label1.Text = result.Item1 + "<br>" +
                result.Item2 + "<br>" +
                result.Item3 + "<br>" +
                result.Item4 + "<br>" +
                result.Item5 + "<br>" +
                $"運行時間:{stopWatch.ElapsedMilliseconds}";

      

            var sql = @"SELECT TOP(5) * FROM TB_WEB_WNA33";

            this.GridView1.DataSource = sql.GetData();
            this.GridView1.DataBind();




            //this.GridView2.DataSource = GetDataByDapper(sql);
            //this.GridView2.DataBind();


            DataTable dt2 = new DataTable();
            dt2.Columns.Add("values");


            var data = GetDataByDapper(sql);

            foreach (var items in data)
            {
                DataRow row = dt2.NewRow();
                dt2.Rows.Add(items.ID);
            }

            this.GridView2.DataSource = dt2;
            this.GridView2.DataBind();


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }


        /// <summary>
        /// 檢查是否為分條,如果是,則回傳分條前的原料ID
        /// 
        /// REF:https://dotblogs.com.tw/jeff-yeh/2008/11/04/5870
        /// 所以使用+串接字串即可
        /// </summary>
        /// <param name="ID">待檢查</param>
        /// <returns></returns>
        private Tuple<bool, string, string> IsSplit(string ID)
        {
            var dt1 = GetData(@"
                SELECT ProductName AS Source
                FROM TB_WEB_WNA24 (nolock) 
                WHERE ID = '" + ID + "'");

            if (dt1.Rows.Count > 0)
            {
                return new Tuple<bool, string, string>(
                    true,
                    ID,
                    dt1.Rows[0]["Source"].ToString());
            }
            else
            {
                return new Tuple<bool, string, string>(false, "", "");
            }
        }

        /// <summary>
        /// 檢查是否為貼合,若是則回傳資料
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private Tuple<bool, string, string, string> IsStick(string ID)
        {
            var dt1 = GetData(@"
                SELECT FilmNo AS Source,Remark
                FROM TB_WEB_WNA33  (nolock) 
                WHERE ID = '" + ID + "'");

            if (dt1.Rows.Count > 0)
            {
                return new Tuple<bool, string, string, string>(
                    true,
                    ID,
                    dt1.Rows[0]["Source"].ToString(),
                    dt1.Rows[0]["Remark"].ToString());
            }
            else
            {
                return new Tuple<bool, string, string, string>(false, "", "", "");
            }
        }

        /// <summary>
        /// 檢查是否為印刷,若是則回傳資料
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private Tuple<bool, string, string, string> IsPrint(string ID)
        {
            var dt1 = GetData(@"
                SELECT FilmID AS Source,Remark
                FROM TB_WEB_WNA43  (nolock) 
                WHERE ID = '" + ID + "'");

            if (dt1.Rows.Count > 0)
            {
                return new Tuple<bool, string, string, string>(
                    true,
                    ID,
                    dt1.Rows[0]["Source"].ToString(),
                    dt1.Rows[0]["Remark"].ToString());
            }
            else
            {
                return new Tuple<bool, string, string, string>(false, "", "", "");
            }
        }

        /// <summary>
        /// 檢查是否為半成品膜
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private Tuple<bool, string, string> IsFilm(string ID)
        {
            var dt1 = GetData(@"
                SELECT Remark 
                FROM TB_WEB_WNA13 
                WHERE ID = '" + ID + "'");

            if (dt1.Rows.Count > 0)
            {
                return new Tuple<bool, string, string>(
                    true,
                    ID,
                    dt1.Rows[0]["Remark"].ToString());
            }
            else
            {
                return new Tuple<bool, string, string>(false, "", "");
            }
        }

        /// <summary>
        /// 依據ID,取得所有前站的ID
        /// 例如:GD01061701,依序可以取得
        /// 貼合產生:8D010425
        /// 印刷產生:7D010323
        /// 空白膜產生:4C121613B
        /// 空白膜輸出的產品,等於輸入印刷的原料,印刷輸出的產品,
        /// 等於輸入貼合的原料,貼合輸出的產品,等於輸入製膜的原料
        /// </summary>
        /// <param name="ID">當前用來查詢的ID</param>
        /// <returns>
        /// 回推前站的ID,
        /// T1:分條
        /// T2:貼合
        /// T3:印刷
        /// T4:膜
        /// T5:全部錯誤訊息
        /// 若為string.empty,表示沒有該站
        /// </returns>
        private Tuple<string, string, string, string, string> GetAllBeforeIDByID(string ID)
        {
            //檢查是否為分條
            var isSplit = IsSplit(ID);

            if (isSplit.Item1)
            {
                ID = isSplit.Item3;
            }

            //檢查是否為貼合
            var isStick = IsStick(ID);

            if (isStick.Item1)
            {
                ID = isStick.Item3;
            }

            //檢查是否為印刷
            var isPrint = IsPrint(ID);

            if (isPrint.Item1)
            {
                ID = isPrint.Item3;
            }

            //檢查是否為空白膜
            var isFilm = IsFilm(ID);

            return new Tuple<string, string, string, string, string>(
                isSplit.Item2, isStick.Item2, isPrint.Item2, isFilm.Item2,
                isStick.Item4 + isPrint.Item4 + isFilm.Item3);
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
    }
}