using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestForResource.TestUC
{
    public partial class TestUCItem : System.Web.UI.UserControl
    {
        public Label NameLabel 
        { 
            get
            {
                return this.lblName;
            }
        }

        public Label AgeLabel
        {
            get
            {
                return this.lblAge;
            }
        }

        public TextBox NameInput
        {
            get
            {
                return this.tbName;
            }
        }

        public TextBox AgeInput
        {
            get
            {
                return this.tbAge;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}