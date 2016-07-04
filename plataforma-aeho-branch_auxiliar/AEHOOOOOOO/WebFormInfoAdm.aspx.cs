using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormInfoAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label label1 = Master.FindControl("titulo") as Label;
            label1.Text = "Seja um Organizador";
        }
    }
}