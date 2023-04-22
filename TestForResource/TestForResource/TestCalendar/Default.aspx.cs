using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace TestForResource.TestCalendar
{
    public partial class Default : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ToERP"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        // 繫結 GridView
        private void BindGridView()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ID, convert(varchar, Date, 111) as Date, Event FROM Events";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                GridView1.DataSource = table;
                GridView1.DataBind();
            }
        }

        // 新增事件
        protected void AddButton_Click(object sender, EventArgs e)
        {
            string date = DateTextBox.Text;
            string @event = EventTextBox.Text;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Events (Date, Event) VALUES (@Date, @Event)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Event", @event);
                int result = command.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageLabel.Text = "Event added successfully";
                    DateTextBox.Text = "";
                    EventTextBox.Text = "";
                    BindGridView();
                }
                else
                {
                    MessageLabel.Text = "Failed to add event";
                }
            }
        }

        // 編輯事件 - 進入編輯模式
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        // 編輯事件 - 取消編輯
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        // 編輯事件 - 更新事件
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string date = (row.FindControl("TextBox1") as TextBox).Text;
            string @event = (row.FindControl("TextBox2") as TextBox).Text;
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Events SET Date=@Date, Event=@Event WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Event", @event);
                command.Parameters.AddWithValue("@ID", id);
                int result = command.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageLabel.Text = "Event updated successfully";
                    GridView1.EditIndex = -1;
                    BindGridView();
                }
                else
                {
                    MessageLabel.Text = "Failed to update event";
                }
            }
        }

        // 刪除事件
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM Events WHERE ID=@ID";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@ID", id);
                int result = command.ExecuteNonQuery();
                if (result == 1)
                {
                    MessageLabel.Text = "Event deleted successfully";
                    BindGridView();
                }
                else
                {
                    MessageLabel.Text = "Failed to delete event";
                }
            }

        }

        // 在 GridView 的 RowDataBound 事件中將 Date 和 Event 欄位轉換成可編輯的 TextBox 控制項
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            //{
            //    TextBox dateTextBox = e.Row.FindControl("Date") as TextBox;
            //    TextBox eventTextBox = e.Row.FindControl("Event") as TextBox;
            //    string date = (e.Row.Cells[0].Text).ToString();
            //    string @event = (e.Row.Cells[1].Text).ToString();
            //    dateTextBox.Text = date;
            //    eventTextBox.Text = @event;
            //}

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string firstCellValue = e.Row.Cells[0].Text;
            //}

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    //string cellValue = e.Row.Cells[0].Text;
            //    // 取得第一個 Cell 的值
            //    // 或者可以使用以下方式取得所有 Cell 的值
            //    foreach (TableCell cell in e.Row.Cells)
            //    {
            //        string cellValue = cell.Text;
            //        // Do something with cellValue
            //        Console.WriteLine(cellValue);
            //    }
            //}
        }
    }
}