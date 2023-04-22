using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Globalization;
using static TestForResource.TestCalendar.Calendar;
using System.Web.Services;

namespace TestForResource.TestCalendar
{
    public partial class Calendar : System.Web.UI.Page
    {
        public class DateObject
        {
            public DateTime Date { get; set; }
            public string Note { get; set; }
        }

        public int Weeks { get; set; }

        public List<DateObject> Date 
        { 
            get
            {
                if (_Date == null)
                {
                    _Date = new List<DateObject>();
                }
                return _Date;
            }
        }

        private List<DateObject> _Date;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Weeks = CalculateWeeks(DateTime.Now);

                var now = DateTime.Now;
                var year = now.Year;
                var month = now.Month;
                var firstDateOfMonth = new DateTime(year, month, 1);
                var firstDateOfCalendar = firstDateOfMonth.AddDays(-(int)firstDateOfMonth.DayOfWeek);
                var lastDateOfCalendar = firstDateOfCalendar.AddDays(7 * Weeks);

                for (DateTime di = firstDateOfCalendar; di < lastDateOfCalendar; di = di.AddDays(1))
                {
                    var dO = new DateObject();
                    dO.Date = di;
                    dO.Note = "";
                    Date.Add(dO);
                }
            }
        }

        [WebMethod]
        public static string SayHello()
        {
            return "Greeting";
        }

        private int CalculateWeeks(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, 
                DateTime.DaysInMonth(date.Year, date.Month));

            // Get the week number of the first and last day of the month
            System.Globalization.Calendar calendar = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = calendar.GetWeekOfYear(firstDayOfMonth, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            int lastWeek = calendar.GetWeekOfYear(lastDayOfMonth, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);

            // Calculate the number of weeks in the month
            int weeksInMonth = lastWeek - firstWeek + 1;

            return weeksInMonth;
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

    }
}