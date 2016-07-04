using Sistema_Aeho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormVerCompDAO : System.Web.UI.Page
    {
        void RetornarCompeticao(Object sender, CommandEventArgs e)
        {
            Session["Competicao_abrir"] = e.CommandArgument;
            Response.Redirect("WebFormCompDAO.aspx");
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["tipousuario"] != null )
            {
                if (Session["tipousuario"].ToString() == "1")
                    Page.MasterPageFile = "~/MasterAtleta.Master";
                else if (Session["tipousuario"].ToString() == "2")
                    Page.MasterPageFile = "~/MasterOrganizador.Master";
                else if (Session["tipousuario"].ToString() == "999")
                    Page.MasterPageFile = "~/MasterADM.Master";
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label Label1 = Master.FindControl("titulo") as Label;
            Label Label2 = Master.FindControl("LabelUsuario") as Label;
            Label2.Text = Session["Login"].ToString();
            Label1.Text = "Ver suas competições";
            DateTime firstDate = new DateTime(2002, 10, 22);
            TimeSpan span = new TimeSpan(1, 2, 0, 30, 0);
            Competicao c = new Competicao();
            List<Competicao> listacompete = new List<Competicao>();
            if (Session["tipousuario"].ToString() == "2")
                listacompete = c.Selecionar_suas_competicoes(Session["Login"].ToString());

            else if (Session["tipousuario"].ToString() == "1")
                listacompete = c.Selecionar_suas_competicoesAtle(Session["Login"].ToString());

            int i = 0;
            foreach (Competicao l in listacompete)
            {
                string nome = "l" + i.ToString();
                Label newLabel = new Label();
                LinkButton newHyperLink = new LinkButton();

                newHyperLink.Text = l.Nome;

                newHyperLink.Command += new CommandEventHandler(RetornarCompeticao);
                newHyperLink.CommandArgument = l.Id.ToString();
                newHyperLink.Font.Name = "verdana";
                newHyperLink.Font.Size = 20;
                newLabel.ID = nome;

                newLabel.Text = "</br> Descricao: " + l.Descricao + " </br> Modalidade:" + l.Modalidade + " </br></br>";
                newLabel.Font.Name = "verdana";
                newLabel.Font.Size = 12;
                Image imagem = new Image();
                imagem.ImageUrl = "~/ImagensSalvas/Competicao/" + l.Foto_da_competicao;
                imagem.Width = 350;
                imagem.Height = 250;
                TableCell newTablecell = new TableCell();
                newTablecell.Controls.Add(newHyperLink);
                newTablecell.Controls.Add(newLabel);
                newTablecell.Controls.Add(imagem);
                TableRow newTablerow = new TableRow();
                newTablerow.Controls.Add(newTablecell);
                Table1.Controls.Add(newTablerow);
                i++;
            }
        }
    }
}