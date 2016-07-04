using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormPesquisarAno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBind();

            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Resultado da busca";


            if (GridView1.Rows.Count == 0)
            {
                Label123.Text = "Nenhum registro encontrado";
                HyperLinkAbertas1.Enabled = false;
                HyperLinkAbertas1.Visible = false;
                HyperLinkEncerradas1.Enabled = false;
                HyperLinkEncerradas1.Visible = false;
            }
            else
            {
                Label123.Text = "";
            }

        }
    }
}