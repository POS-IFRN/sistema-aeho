using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Aeho;

namespace AEHOOOOOOO
{
    public partial class WebFormMensagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["rid"] != null)
            {
                Label Label1 = new Label();
                Label1.Text = "Enviando mensagem para: " + Request.QueryString["rid"].ToString();
            }
            else
            {
                DropDownList ddlist = new DropDownList();
                ddlist.ID = "ddlist";
                Registro c = new Registro();
                List<Registro> ru = new List<Registro>();
                if (Session["tipousuario"].ToString() != "1")
                {
                    ru = c.selec_all();
                }
                else
                {
                    ru = c.selec_all(int.Parse(Session["tipousuario"].ToString()));
                }
                
                foreach (Registro r in ru)
                {
                    ListItem l = new ListItem();
                    l.Value = l.Text = r.Usuario;
                    ddlist.Items.Add(l);
                }
                Panel1.Controls.Add(ddlist); 
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["cid"] != null && Request.QueryString["rid"] != null)
            {
                Mensagem k = new Mensagem(TextBox1.Text, Request.QueryString["rid"], int.Parse(Request.QueryString["cid"].ToString()), Session["Login"].ToString());
                try
                {
                    k.Inserir_mensagem();
                    Response.Write("<script>window.alert('Mensagem cadastrada com sucesso!');</script>");
                }
                catch
                {
                    Response.Write("<script>window.alert('Que Pena! Ocorreu um erro ao cadastrar sua mensagem!</script>')");
                }


            }
            else if (Request.QueryString["rid"] != null)
            {
                Mensagem k = new Mensagem(TextBox1.Text, Request.QueryString["rid"], Session["Login"].ToString());
                try
                {
                    k.Inserir_mensagem();
                    Response.Write("<script>window.alert('Mensagem cadastrada com sucesso!');</script>");
                }
                catch
                {
                    Response.Write("<script>window.alert('Que Pena! Ocorreu um erro ao cadastrar sua mensagem!</script>')");
                }
            }
        
            else
            {
                DropDownList ddl1 = (DropDownList)Page.FindControl("ddlist");
                Mensagem k = new Mensagem(TextBox1.Text, ddl1.SelectedValue, Session["Login"].ToString());
                try
                {
                    k.Inserir_mensagem();
                    Response.Write("<script>window.alert('Mensagem cadastrada com sucesso!');</script>");
                }
                catch
                {
                    Response.Write("<script>window.alert('Que Pena! Ocorreu um erro ao cadastrar sua mensagem!</script>')");
                }
            }

        }
    }
}