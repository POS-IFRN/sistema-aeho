﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class MasterAno : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string k = TextBuscar.Text;
            Session["busca"] = TextBuscar.Text;
            Response.Redirect("WebFormPesquisa.aspx");
        }

    }
}