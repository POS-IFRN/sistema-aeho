using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Sistema_Aeho;
using System.Globalization;
using System.Text;

namespace AEHOOOOOOO
{

    public partial class WebFormRegistro : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbplataformaAEHOConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["tipousuario"] != null && Session["tipousuario"].ToString() == "999") Page.MasterPageFile = "~/MasterADM.Master";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipousuario"] != null && Session["tipousuario"].ToString() != "999")
            {
                Response.Write("<script>window.alert('Usuário já está logado! Você não tem acesso a essa página! Sendo redirecionado para a página de competições abertas.'); self.location='WebFormCompAbertDAO.aspx';</script>)");
            }
            if ((Session["tipousuario"] == null || Session["tipousuario"].ToString() != "999") && Request.QueryString["privilegio"].ToString() == "2")
            {
                Response.Write("<script>window.alert('Você está tentando realizar uma operação que somente administradores podem. Sendo redirecionado para a página de competições abertas.'); self.location='WebFormCompAbertDAO.aspx';</script>)");
            }
            
            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Registro";
            if (Session["tipousuario"] != null && Session["tipousuario"].ToString() == "999")
            {
                Label Label2 = Master.FindControl("LabelUsuario") as Label;
                Label2.Text = Session["Login"].ToString();
            }
        }

        protected void TextBoxCEP_TextChanged(object sender, EventArgs e)
       {
           RegularExpressionValidator1.Validate();
            if (TextBoxCEP.Text != null && RegularExpressionValidator1.IsValid)
            {
                
                    WebRequest request = WebRequest.Create("http://clareslab.com.br/ws/cep/json/" + TextBoxCEP.Text);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("iso-8859-1"), true);
                    string dados = stream.ReadToEnd();
                    dados = dados.Replace("{", "");
                    dados = dados.Replace("}", "");
                    dados = dados.Replace("\"", "");
                    string[] valores = dados.Split(',');
                    for (int i = 0; i < valores.Length; i++)
                    {
                        valores[i] = valores[i].Substring(valores[i].IndexOf(':') + 1);
                    }
                    //0 = cidade, 1 = bairro, 3 = uf, 4 = rua
                    TextBoxCidade.Text = string.Empty;
                    TextBoxCidade.Text = valores[0];
                    TextBoxBairro.Text = string.Empty;
                    TextBoxBairro.Text = valores[1];
                    TextBoxUF.Text = string.Empty;
                    TextBoxUF.Text = valores[3];
                    TextBoxRua.Text = string.Empty;
                    TextBoxRua.Text = valores[4];
               
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                DateTime nascimento = DateTime.ParseExact(TextBoxNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string ncerto = nascimento.ToString("d");
                int Privilegio = int.Parse(Request.QueryString["privilegio"]);

                HttpPostedFile fotopostada = FileUpload1.PostedFile;
                int lenfotopostada = fotopostada.ContentLength;
                byte[] minhafoto = new byte[lenfotopostada];
                fotopostada.InputStream.Read(minhafoto, 0, lenfotopostada);
                string aux = Path.GetFileName(fotopostada.FileName);
                cmd.Parameters.AddWithValue("@infofoto", aux);
                FileStream novaimagem = new FileStream(Server.MapPath("~/ImagensSalvas/Usuario/" + aux), FileMode.Create);
                novaimagem.Write(minhafoto, 0, minhafoto.Length);
                novaimagem.Close();

                Registro r = new Registro(TextBoxNome.Text, ncerto, TextBoxRG.Text, TextBoxCPF.Text, DropDownListGenero.SelectedItem.Text, TextBoxEmail.Text, TextBoxLogin.Text, TextBoxSenha.Text, aux, TextBoxRua.Text, int.Parse(TextBoxNumero.Text), TextBoxBairro.Text, TextBoxUF.Text, TextBoxCidade.Text, TextBoxCEP.Text, TextBoxComplemento.Text, Privilegio);

                try
                {
                    r.inserir_Usuario();
                    Response.Write("<script>window.alert('Você se cadastrou com sucesso na nossa plataforma!'); self.location='WebFormLogin.aspx';</script>");
                }
                catch
                {
                    Response.Write("<script>window.alert('Ocorreu um erro ao tentar se cadastrar!');</script>");
                }



            }
            else Response.Write("<script>window.alert('Corrija todos os erros!');</script>");
        }
    }
}