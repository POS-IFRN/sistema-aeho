
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormCompeticoesAbertas1 : System.Web.UI.Page
    {
        void RetornarCompeticao(Object sender, CommandEventArgs e)
        {
            Session["Competicao_abrir"] = e.CommandArgument;
            Response.Redirect("WebFormCompeticao.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["status_competicao"] = 1;
            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "eae meninas";


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbplataformaAEHOConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("Select id, nome, foto_da_competicao, descricao, modalidade from Competicao where status_competicao = 1", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                string nome = "l" + i.ToString();
                string x = dr["nome"].ToString();
                string d = dr["descricao"].ToString();
                string m = dr["modalidade"].ToString();

                Label newLabel = new Label();
                LinkButton newHyperLink = new LinkButton();

                newHyperLink.Text = x;

                newHyperLink.Command += new CommandEventHandler(RetornarCompeticao);
                newHyperLink.CommandArgument = dr["id"].ToString();
                newHyperLink.Font.Name = "verdana";
                newHyperLink.Font.Size = 20;
                newLabel.ID = nome;

                newLabel.Text = "</br> Descricao: " + d + " </br> Modalidade:" + m + " </br></br>";
                newLabel.Font.Name = "verdana";
                newLabel.Font.Size = 12;
                Image imagem = new Image();
                imagem.ImageUrl = "~/ImagensSalvas/Competicao/" + dr["foto_da_competicao"].ToString();
                imagem.Width = 250;
                imagem.Height = 250;
                TableCell newTablecell = new TableCell();
                newTablecell.Controls.Add(newHyperLink);
                newTablecell.Controls.Add(newLabel);
                newTablecell.Controls.Add(imagem);
                // newTablecell.Controls.Add(rimage);
                TableRow newTablerow = new TableRow();
                newTablerow.Controls.Add(newTablecell);
                Table1.Controls.Add(newTablerow);
                i++;
            }
            conn.Close();
        }

       
    }
}