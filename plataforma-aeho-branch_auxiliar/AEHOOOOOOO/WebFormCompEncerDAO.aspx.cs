using Sistema_Aeho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormCompEncer : System.Web.UI.Page
    {
        void RetornarCompeticao(Object sender, CommandEventArgs e)
        {
            Session["Competicao_abrir"] = e.CommandArgument;
            Response.Redirect("WebFormCompDAO.aspx");
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["tipousuario"] != null)
            {
                if (Session["tipousuario"].ToString() == "1")
                    Page.MasterPageFile = "~/FormBuceta.Master";
                else if (Session["tipousuario"].ToString() == "2")
                    Page.MasterPageFile = "~/MasterOrganizador.master";
                else if (Session["tipousuario"].ToString() == "999")
                    Page.MasterPageFile = "~/MasterADM.Master";
            }
            

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label Labelt = Master.FindControl("titulo") as Label;
            Labelt.Text = "Competições encerradas";
            Label Labelu = Master.FindControl("LabelUsuario") as Label;
            if (Session["Login"] != null)Labelu.Text = Session["Login"].ToString();
            DateTime firstDate = new DateTime(2002, 10, 22);
            TimeSpan span = new TimeSpan(1, 2, 0, 30, 0);
            Competicao c = new Competicao();
            List<Competicao> listacompete = c.Selecionar_competicoes_com_status(3);
            foreach (Competicao l in listacompete)
            {
               
                Label newLabel = new Label();
                LinkButton newHyperLink = new LinkButton();

                newHyperLink.Text = l.Nome;

                newHyperLink.Command += new CommandEventHandler(RetornarCompeticao);
                newHyperLink.CommandArgument = l.Id.ToString();
                newHyperLink.Font.Name = "verdana";
                newHyperLink.Font.Size = 20;
                newLabel.ID = l.Id.ToString();

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
            }
        }
    }
}