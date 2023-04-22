using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestGrid
{
    public partial class TwoTierInOneRowColumn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.DataSource = GetData();
            this.GridView1.DataBind();
        }

        private DataTable GetData()
        {
            var sql = @"
            SELECT TOP 20
	            a.ID
	            ,a.orgID 
	            ,ISNULL((SELECT TOP 1 Remark FROM TB_WEB_WNA13 A13 WHERE A13.ID = a.orgID) , '') pe_unusual
	            ,ISNULL(F.FilmID,ISNULL(G.FilmNo,'')) FilmNo
	            ,a.matrlNo
	            ,a.MoID
	            ,a.locA
	            ,E.ma_name
	            ,c.el_size
	            ,a.instockWgt qty
	            ,a.instockQty qty1
	            ,a.custNo
	            ,a.orderNo orderNo
	            ,a.BarcodeID 
	            ,a.BundleNo
	            ,a.LotNo
	            ,a.SlitJoint
	            ,a.sc_odno
	            ,a.status
	            ,B.CodeDesc
	            ,D.CodeDesc STATUS_CodeDesc
	            ,a.createDate 
            FROM TB_WEB_ISN01 a (nolock) 
            LEFT JOIN ieel00h c (nolock) ON a.matrlNo = c.el_no 
            LEFT JOIN TB_WEB_CODE B ON B.TableID='IS_LOCTYPE' AND a.lockType=B.Code  
            LEFT JOIN TB_WEB_CODE D ON D.TableID='IS_STATUS' AND a.status=D.Code  
            LEFT JOIN iepb27h E ON c.ma_no=E.ma_no  
            LEFT JOIN TB_WEB_WNA43 F ON a.orgID = F.ID 
            LEFT JOIN TB_WEB_WNA33 G ON a.orgID = G.ID   
            WHERE a.createDate>= '2023/04/01' AND a.createDate<='2023/04/30' 
";

            return this.GetDataWithRetry(sql);
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

        //private DataTable GetDataWithRetry2(string sql)
        //{
        //    var retryLimit = 3;
        //    var retryInterval = 1000;

        //    for(int retryCount = 0; retryCount < retryLimit; retryCount++)
        //    {
        //        try
        //        {
        //            return GetData(sql);
        //        }
        //        catch (Exception ex)
        //        {
        //            if (retryCount < retryLimit - 1)
        //            {
        //                Thread.Sleep(retryInterval);
        //            }
        //            else
        //            {
        //                throw ex;
        //            }
        //        }
        //    }
        //}

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
    }
}