using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestUC
{
    public partial class TestUCMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.uc1Name1.NameLabel.Text = "Name1";
            this.uc1Name2.NameLabel.Text = "Name2";
            this.uc1Name3.NameLabel.Text = "Name3";
       
            this.uc1Name1.AgeLabel.Text = "Age1";
            this.uc1Name2.AgeLabel.Text = "Age2";
            this.uc1Name3.AgeLabel.Text = "Age3";
            
        }
    }
}