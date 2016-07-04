using Sistema_Aeho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormPesquisa : System.Web.UI.Page
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
            Label1.Text = "Resultado da busca";
            Label label2 = Master.FindControl("LabelUsuario") as Label;

            if (Session["Login"] != null)
                label2.Text = Session["Login"].ToString();
            Competicao c = new Competicao();
            List<Competicao> lista  = c.buscar(Session["busca"].ToString());
            foreach (Competicao o in lista)
            {
                Label newLabel = new Label();
                LinkButton newHyperLink = new LinkButton();

                newHyperLink.Text = o.Nome;

                newHyperLink.Command += new CommandEventHandler(RetornarCompeticao);
                newHyperLink.CommandArgument = o.Id.ToString();
                newHyperLink.Font.Name = "verdana";
                newHyperLink.Font.Size = 20;
                newLabel.ID = o.Id.ToString();

                newLabel.Text = "</br> Descricao: " + o.Descricao + " </br> Modalidade:" + o.Modalidade + " </br></br>";
                newLabel.Font.Name = "verdana";
                newLabel.Font.Size = 12;
                Image imagem = new Image();
                imagem.ImageUrl = "~/ImagensSalvas/Competicao/" + o.Foto_da_competicao;
                imagem.Width = 350;
                imagem.Height = 250;
                TableCell newTablecell = new TableCell();
                newTablecell.Controls.Add(newHyperLink);
                newTablecell.Controls.Add(newLabel);
                newTablecell.Controls.Add(imagem);
                TableRow newTablerow = new TableRow();
                newTablerow.Controls.Add(newTablecell);
                Table1.Controls.Add(newTablerow);
                // i++;
            }


        }

        
    }
}