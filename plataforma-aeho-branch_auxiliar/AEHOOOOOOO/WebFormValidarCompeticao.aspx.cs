using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Sistema_Aeho;

namespace AEHOOOOOOO
{
    public partial class WebFormValidarCompeticao : System.Web.UI.Page
    {
        void RetornarCompeticao(Object sender, CommandEventArgs e)
        {
            Session["Competicao_abrir"] = e.CommandArgument;
            Response.Redirect("WebFormCompDAO.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Write("<script>window.alert('Usuário não está logado! Você não tem acesso a essa página! Sendo redirecionado para a página de competições abertas.'); self.location = 'WebFormCompeticoesAbertas.aspx' </script>)");
            }
            if (Session["tipousuario"].ToString() != "999")
                Response.Write("<script>window.alert('Você não tem permissão para acessar esta página! Sendo redirecionado para a página de competições abertas.'); self.location = 'WebFormCompAbertDAO.aspx'");

            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Competições a serem validadas";
            Label Label2 = Master.FindControl("LabelUsuario") as Label;
            Label2.Text = Session["Login"].ToString();

            Competicao c = new Competicao();
            List<Competicao> lista = c.Selecionar_competicoes_com_status(0);
            foreach (Competicao l in lista)
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