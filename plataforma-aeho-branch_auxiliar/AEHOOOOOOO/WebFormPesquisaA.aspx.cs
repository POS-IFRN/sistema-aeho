using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Aeho;

namespace AEHOOOOOOO
{
    public partial class WebFormPesquisaA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TextBox TextBox1 = Master.FindControl("TextBuscar") as TextBox;
            //if (TextBox1.Text != "")

            
            DataBind();
            
            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Resultado da busca";
            Label Label2 = Master.FindControl("LabelUsuario") as Label;
            Label2.Text = Session["Login"].ToString();

          
            if (GridView1.Rows.Count == 0)
            {
                Label12.Text = "Nenhum registro encontrado";
                HyperLinkAbertas.Enabled = false;
                HyperLinkAbertas.Visible = false;
                HyperLinkEncerradas.Enabled = false;
                HyperLinkEncerradas.Visible = false;
            }
            else
            {
                Label12.Text = "";
            }

            
        }
    }
}