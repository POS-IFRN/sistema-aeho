﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormVerSuasCompeticoes : System.Web.UI.Page
    {
        void RetornarCompeticao(Object sender, CommandEventArgs e)
        {
            Session["Competicao_abrir"] = e.CommandArgument;
            Response.Redirect("~/WebFormCompeticao.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbplataformaAEHOConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("Select id, Organizador_usuario, nome, descricao, modalidade, foto_da_competicao from Competicao where Organizador_usuario = @usuario", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@usuario", Session["Login"].ToString());
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
                //newHyperLink.PostBackUrl = "WebFormCompeticao.aspx";
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
                TableRow newTablerow = new TableRow();
                newTablerow.Controls.Add(newTablecell);
                Table1.Controls.Add(newTablerow);
                i++;
            }
            conn.Close();
        }
    }
}