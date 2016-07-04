using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Aeho;

namespace AEHOOOOOOO
{
    public partial class WebFormSuasMensagens : System.Web.UI.Page
    {
        void RetornarMensagem(Object sender, CommandEventArgs e)
        {
            Session["Mensagem_abrir"] = e.CommandArgument;
            Response.Redirect("WebFormMengDAO.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label Label1 = Master.FindControl("titulo") as Label;
            Label Label2 = Master.FindControl("LabelUsuario") as Label;
            Label2.Text = Session["Login"].ToString();
            Label1.Text = "Ver suas mensagens";
            Mensagem m = new Mensagem(Session["Login"].ToString());
            List<Mensagem> k = m.Selecionar_suas_mensagens();

            foreach (Mensagem msg in k)
            {
                LinkButton newlink = new LinkButton();
                Label newLabel = new Label();
                newlink.Command += new CommandEventHandler(RetornarMensagem);
                newlink.CommandArgument = msg.Id.ToString();
                string aux = msg.Mensagem_conteudo;
                if (aux.Length > 20) aux = aux.Substring(0, 7) + "...";
                newlink.Text = aux + "<br />";
                aux = "";
                aux = "De: " + msg.Registro_remetente;
                newLabel.Text = aux;
                TableCell tc = new TableCell();
                tc.Controls.Add(newlink);
                tc.Controls.Add(newLabel);
                TableRow tr = new TableRow();
                tr.Controls.Add(tc);
                Table1.Controls.Add(tr);
            }
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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.open('WebFormMensagem.aspx', 'Envio de mensagem ao organizador', 'height=500px, width=500px');</script>");
        }
    }
}