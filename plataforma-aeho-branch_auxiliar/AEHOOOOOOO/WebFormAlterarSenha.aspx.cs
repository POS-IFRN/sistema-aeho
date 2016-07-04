using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Aeho;
namespace AEHOOOOOOO
{
    public partial class WebFormAlterarSenha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["tipousuario"] != null)
            {
                if (Session["tipousuario"].ToString() == "1")
                    Page.MasterPageFile = "~/MasterAtleta.Master";
                else if (Session["tipousuario"].ToString() == "2")
                    Page.MasterPageFile = "~/MasterOrganizador.Master";
                else if (Session["tipousuario"].ToString() == "999")
                    Page.MasterPageFile = "~/MasterADM.Master";
            }

            Label Labelt = Master.FindControl("titulo") as Label;
            Label Labelu = Master.FindControl("LabelUsuario") as Label;
            if (Session["Login"] != null)
            {
                Labelu.Text = Session["Login"].ToString();
            }
            Labelt.Text = "Alterar senha";
        }
       
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBoxSenhaAntiga.Text = ("");
            TextBoxSenhaNova.Text = ("");
            TextBoxConfirmarNovaSenha.Text = ("");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Registro r = new Registro(Session["Login"].ToString());
            Registro y = r.selecionar_usuario();
            if (TextBoxSenhaAntiga.Text == y.Senha && TextBoxSenhaNova.Text == TextBoxConfirmarNovaSenha.Text)
            {
                try
                {
                    y.Update_Usuario_senha(TextBoxSenhaNova.Text);
                    Response.Write("<script>window.alert('Senha alterada com sucesso!'); self.location('WebFormCompAbertDAO.aspx')</script>");
                }
                catch
                {
                    Response.Write("<script>window.alert('Senha não foi alterada devido a um erro desconhecido.'); self.location('WebFormCompAbertDAO.aspx')</script>");
                }
            }
            
        }
    }
}