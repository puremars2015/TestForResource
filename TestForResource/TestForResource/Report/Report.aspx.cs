using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestForResource.TestCRUD;

namespace TestForResource.Report
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var sql = @"
            //    SELECT A.mt_yy, 
            //    A.el_no, 
            //    B.el_name1, 
            //    B.el_size, 
            //    A.mt_qty01 '月結數量',  --mt_qty+二碼月份
            //    isnull((SELECT TOP 1 mt_date FROM iemt03d1 a (nolock) WHERE a.el_no = A.el_no AND a.mt_list LIKE 'CA%' AND mt_date <= '2023/01/01' ORDER BY mt_date DESC),'') '完工入庫日',
            //    isnull((SELECT TOP 1 mt_list FROM iemt03d1 a (nolock) WHERE a.el_no = A.el_no AND a.mt_list LIKE 'CA%' AND mt_date <= '2023/01/01' ORDER BY mt_date DESC),'') '完工入庫單',
            //    isnull((SELECT TOP 1 a.ch_date FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '2023/01/01' ORDER BY a.ch_date DESC),'') '驗收入庫日',
            //    isnull((SELECT TOP 1 a.ch_acno FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '2023/01/01' ORDER BY a.ch_date DESC),'') '驗收入庫單',
            //    isnull((SELECT TOP 1 a.od_id FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '2023/01/01' ORDER BY a.ch_date DESC),0) '幣別',
            //    isnull((SELECT TOP 1 b.ch_price FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '2023/01/01' ORDER BY a.ch_date DESC),0) '原幣單價', 
            //    isnull((SELECT TOP 1 CASE od_id WHEN 'NTD' THEN b.ch_price ELSE round(a.ch_rate * b.ch_price,2) END FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '2023/01/01' ORDER BY a.ch_date DESC),0) 'NTD單價',
            //    isnull((SELECT TOP 1 b.sa_date FROM iesa00h a (nolock) INNER JOIN iesa00d1 b (nolock) ON a.sa_no = b.sa_no WHERE a.sa_date <= '2023/01/01' AND b.el_no = A.el_no ORDER BY a.sa_date DESC),'') '銷貨日期',
            //    isnull((SELECT TOP 1 b.sa_no FROM iesa00h a (nolock) INNER JOIN iesa00d1 b (nolock) ON a.sa_no = b.sa_no WHERE a.sa_date <= '2023/01/01' AND b.el_no = A.el_no ORDER BY a.sa_date DESC),'') '銷貨單號',
            //    isnull((SELECT TOP 1 CASE a.od_id WHEN 'NTD' THEN b.sa_price ELSE round(a.sa_rate * b.sa_price,2) END FROM iesa00h a (nolock) INNER JOIN iesa00d1 b (nolock) ON a.sa_no = b.sa_no WHERE a.sa_date <= '2023/01/01' AND b.el_no = A.el_no ORDER BY a.sa_date DESC),0) '銷貨單價NTD' 
            //    FROM iemt11h A (nolock) 
            //    INNER JOIN ieel00h B (nolock) 
            //    ON A.el_no = B.el_no 
            //    WHERE A.mt_yy = '2023' 
            //    AND A.mt_qty01 <> 0  --mt_qty+二碼月份
            //    ORDER BY A.el_no";

            //var tb = sql.GetData();

            //this.GridView1.DataSource = tb;
            //this.GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var selected = this.Calendar1.SelectedDate;
            var selectedYear = selected.Year.ToString();
            var selectedMonth = selected.ToString("MM");
            var selectedDate = selected.ToString("yyyy/MM/dd");
            var sql = $@"
                SELECT
                A.mt_yy, 
                A.el_no, 
                B.el_name1, 
                B.el_size, 
                A.mt_qty{selectedMonth} '{selectedMonth}月結數量',  --mt_qty+二碼月份
                isnull((SELECT TOP 1 mt_date FROM iemt03d1 a (nolock) WHERE a.el_no = A.el_no AND a.mt_list LIKE 'CA%' AND mt_date <= '{selectedDate}' ORDER BY mt_date DESC),'') '完工入庫日',
                isnull((SELECT TOP 1 mt_list FROM iemt03d1 a (nolock) WHERE a.el_no = A.el_no AND a.mt_list LIKE 'CA%' AND mt_date <= '{selectedDate}' ORDER BY mt_date DESC),'') '完工入庫單',
                isnull((SELECT TOP 1 a.ch_date FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '{selectedDate}' ORDER BY a.ch_date DESC),'') '驗收入庫日',
                isnull((SELECT TOP 1 a.ch_acno FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '{selectedDate}' ORDER BY a.ch_date DESC),'') '驗收入庫單',
                isnull((SELECT TOP 1 a.od_id FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '{selectedDate}' ORDER BY a.ch_date DESC),0) '幣別',
                isnull((SELECT TOP 1 b.ch_price FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '{selectedDate}' ORDER BY a.ch_date DESC),0) '原幣單價', 
                isnull((SELECT TOP 1 CASE od_id WHEN 'NTD' THEN b.ch_price ELSE round(a.ch_rate * b.ch_price,2) END FROM iech03h a (nolock) INNER JOIN iech03d1 b (nolock) ON a.ch_acno = b.ch_acno WHERE b.el_no = A.el_no AND a.ch_date <= '{selectedDate}' ORDER BY a.ch_date DESC),0) 'NTD單價',
                isnull((SELECT TOP 1 b.sa_date FROM iesa00h a (nolock) INNER JOIN iesa00d1 b (nolock) ON a.sa_no = b.sa_no WHERE a.sa_date <= '{selectedDate}' AND b.el_no = A.el_no ORDER BY a.sa_date DESC),'') '銷貨日期',
                isnull((SELECT TOP 1 b.sa_no FROM iesa00h a (nolock) INNER JOIN iesa00d1 b (nolock) ON a.sa_no = b.sa_no WHERE a.sa_date <= '{selectedDate}' AND b.el_no = A.el_no ORDER BY a.sa_date DESC),'') '銷貨單號',
                isnull((SELECT TOP 1 CASE a.od_id WHEN 'NTD' THEN b.sa_price ELSE round(a.sa_rate * b.sa_price,2) END FROM iesa00h a (nolock) INNER JOIN iesa00d1 b (nolock) ON a.sa_no = b.sa_no WHERE a.sa_date <= '{selectedDate}' AND b.el_no = A.el_no ORDER BY a.sa_date DESC),0) '銷貨單價NTD' 
                FROM iemt11h A (nolock) 
                INNER JOIN ieel00h B (nolock) 
                ON A.el_no = B.el_no 
                WHERE A.mt_yy = '{selectedYear}' 
                AND A.mt_qty{selectedMonth} <> 0  --mt_qty+二碼月份
                ORDER BY A.el_no";



            var tb = sql.GetData();


            this.GridView1.DataSource = tb;
            this.GridView1.DataBind();
        }
    }
}