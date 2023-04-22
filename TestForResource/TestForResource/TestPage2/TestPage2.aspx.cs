using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestPage2
{
    public partial class TestPage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Label1.Text  = this.GetLocalResourceObject("ResourceName").ToString();
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            this.Label1.Text = HttpContext.GetLocalResourceObject("~/TestPage2/TestPage2.aspx", "ResourceName").ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           
            this.Label1.Text = HttpContext.GetGlobalResourceObject("TestGlobalResource", "MessageKey").ToString();
        }
    }
}