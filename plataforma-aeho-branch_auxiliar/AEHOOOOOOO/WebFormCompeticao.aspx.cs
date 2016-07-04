using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormCompeticao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["Competicao_abrir"].ToString();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbplataformaAEHOConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("Select id, nome, descricao, organizador_usuario, modalidade, foto_da_competicao, status_competicao from Competicao where id = @outronome", conn);
            cmd.Parameters.AddWithValue("@outronome", int.Parse(Session["Competicao_abrir"].ToString()));
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                string nome = "l" + i.ToString();
                string x = dr["nome"].ToString();
                string d = dr["descricao"].ToString();
                string m = dr["modalidade"].ToString();
                Label Label1 = Master.FindControl("titulo") as Label;
                Label1.Text = x;
                Label newLabel = new Label();
                Label LabelTitulo = new Label();
                LinkButton newHyperLink = new LinkButton();
                newHyperLink.Text = x;
                //newHyperLink.PostBackUrl = "WebFormCompeticao.aspx";
                newLabel.ID = nome;
                LabelTitulo.Text = x;
                newLabel.Text = "</br> Descricao: " + d + " </br> Modalidade:" + m + " </br></br>" + dr["status_competicao"].ToString();
                Label2.Text = LabelTitulo.Text;
                Label2.Font.Name = "verdana";
                Label2.Font.Size = 20;
                Label1.Text = newLabel.Text;
                Image1.ImageUrl = "~/ImagensSalvas/Competicao/" + dr["foto_da_competicao"].ToString();
                Image1.Width = 250;
                Image1.Height = 250;
               if (dr["status_competicao"].ToString() == "1")
                {
                    Button validar = new Button();
                    Button mensagem = new Button();
                    validar.Text = "Validar competição";
                    mensagem.Text = "Enviar mensagem ao organizador";
                    mensagem.Attributes.Add("onclick", "window.open('WebFormMensagem.aspx?cid=" + dr["id"].ToString() + "&ous=" + dr["organizador_usuario"] + "', " + " 'Envio de mensagem ao organizador', 'height=500px, width=500px')");
                    Panel1.Controls.Add(validar);
                    Panel1.Controls.Add(mensagem);
                }
                i++;
            }
          
            
            conn.Close();
        }
    }
}