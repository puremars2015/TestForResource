using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestCRUD
{
    public partial class TestCreateForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var l = new List<string>();
            l.Add("1");
            l.Add("2");
            this.ListBox1.DataSource = l;
            this.ListBox1.DataBind();
        }
    }
}