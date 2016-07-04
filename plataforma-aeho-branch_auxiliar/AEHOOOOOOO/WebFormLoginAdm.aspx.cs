using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Aeho;
namespace AEHOOOOOOO
{
    public partial class WebFormLoginAdm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.Button1.UniqueID;
            if (Session["Login"] != null)
            {
                Response.Write("<script>window.alert('Usuário já está logado! Você não tem acesso a essa página! Sendo redirecionado para a página de competições abertas.'); self.location = 'WebFormCompeticoesAbertas.aspx' </script>)");
            }
            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Login Administrativo";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Registro r = new Registro(TextBoxUsuario.Text, TextBoxSenha.Text);
            bool estaPresente = r.adm_existe();

            if (estaPresente)
            {
                Response.Write("<script>window.alert('Logado com sucesso!')</script>");
                Session["Login"] = TextBoxUsuario.Text;
                Session["tipousuario"] = 999;
                Response.Redirect("WebFormCompAbertDAO.aspx");
            }
            else Response.Write("<script>window.alert('Bicho, vc não tem cadastro no nosso site!')</script>");
        }
    }
}