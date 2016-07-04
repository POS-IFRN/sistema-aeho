using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Aeho;

namespace AEHOOOOOOO
{
    public partial class WebFormMengDAO : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["tipousuario"] != null)
            {
                if (Session["tipousuario"].ToString() == "1")
                    Page.MasterPageFile = "~/MasterAtleta.Master";
                else if (Session["tipousuario"].ToString() == "2")
                    Page.MasterPageFile = "~/MasterOrganizador.master";
                else if (Session["tipousuario"].ToString() == "999")
                    Page.MasterPageFile = "~/MasterADM.Master";
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Mensagem_abrir"] != null)
            {
                Label Labelt = Master.FindControl("titulo") as Label;
                Label Labelu = Master.FindControl("LabelUsuario") as Label;
                Button Responder = new Button();
                Responder.CssClass = "ls-btn";
                Mensagem m = new Mensagem(int.Parse(Session["Mensagem_abrir"].ToString()));
                m = m.Selecionar_uma();
                Labelu.Text = Session["Login"].ToString();
                Labelt.Text = "Mensagem de: " + m.Registro_remetente;
                string comandojs = "window.open('WebFormMensagem.aspx?rid=" + m.Registro_remetente;
                if (m.Competicao_id.HasValue)
                    comandojs += "&cid=" + m.Competicao_id;
                comandojs += "', 'Envio de mensagem', 'height=500px, width=500px')";
                Responder.Attributes.Add("onclick", comandojs);
                Responder.Text = "Responder a mensagem";
                Label cool = new Label();
                cool.Text = m.Mensagem_conteudo + "<br />Enviada por: " + m.Registro_remetente + "<br /><br />Enviada em: " + m.Data_envio + "<br />";
                cool.Font.Name = "verdana";
                Panel1.Controls.Add(cool);
                Panel1.Controls.Add(Responder);
            }
        }

    }
}