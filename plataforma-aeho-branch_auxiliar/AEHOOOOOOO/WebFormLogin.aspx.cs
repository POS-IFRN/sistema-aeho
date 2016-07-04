using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Sistema_Aeho;
namespace AEHOOOOOOO
{

    public partial class WebFormLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Form.DefaultButton = this.Button1.UniqueID;
            if (Session["Login"] != null)
            {
                Response.Write("<script>window.alert('Usuário já está logado! Você não tem acesso a essa página! Sendo redirecionado para a página de competições abertas.'); self.location = 'WebFormCompAbertDAO.aspx' </script>)");
            }
            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Login";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Registro r = new Registro(TextBoxUsuario.Text, TextBoxSenha.Text);
            bool estaPresente = r.usuario_existe();
            if (estaPresente)
            {
                Response.Write("<script>window.alert('Logado com sucesso!'); self.location='WebFormCompAbertDAO.aspx';</script>");
                Session["Login"] = TextBoxUsuario.Text;
                Session["s"] = TextBoxSenha.Text;
                Registro raux = r.selecionar_usuario();
                Session["tipousuario"] = raux.Privilegio;
            }
            else Response.Write("<script>window.alert('Bicho, vc não tem cadastro no nosso site! Redirecionando para a página de registro.'); self.location='WebFormRegistro.aspx?privilegio=1'</script>");
        }
    }
}