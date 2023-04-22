using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TestForResource.TestCRUD
{
    public static class MyExtension
    {
        public static DataTable GetData(this string SQL)
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

        public static List<dynamic> GetDataByDapper(string sql)
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["ToERP"].ToString();
            var conn = new SqlConnection(ConnectionString);
            var results = conn.Query(sql).ToList();

            return results;
        }
    }
}