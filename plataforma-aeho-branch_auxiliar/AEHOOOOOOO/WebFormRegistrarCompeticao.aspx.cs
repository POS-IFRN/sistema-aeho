
using Sistema_Aeho;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class ReghistrarCOmpete : System.Web.UI.Page
    {
        System.Text.Encoding utf_8 = System.Text.Encoding.UTF8;
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbplataformaAEHOConnectionString"].ToString());
        SqlCommand cmd = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["tipousuario"] == null || Session["tipousuario"].ToString() != "2")
            {
                Response.Write("<script>window.alert('Você não tem privilégios suficientes para acessar esta página. Sendo redirecionado para a página de competições abertas.'); self.location = 'WebFormCompAbertDAO.aspx';</script>)");
            }
            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Registrar Competição";
            Label Label2 = Master.FindControl("LabelUsuario") as Label;
            if (Session["tipousuario"] != null )
                Label2.Text = Session["Login"].ToString();
        }

        protected void TextBoxCEP_TextChanged(object sender, EventArgs e)
        {
            RegularExpressionValidator1.Validate();
            if (TextBoxCep.Text != null && RegularExpressionValidator1.IsValid)
            {
                WebRequest request = WebRequest.Create("http://clareslab.com.br/ws/cep/json/" + TextBoxCep.Text);
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
                try {
                    TextBoxCidade.Text = string.Empty;
                    TextBoxCidade.Text = valores[0];
                    TextBoxBairro.Text = string.Empty;
                    TextBoxBairro.Text = valores[1];
                    TextBoxUF.Text = string.Empty;
                    TextBoxUF.Text = valores[3];
                    TextBoxRua.Text = string.Empty;
                    TextBoxRua.Text = valores[4];
                }
                catch
                {
                    TextBoxCep.Text = string.Empty;
                    Response.Write("<script>window.alert('Tivemos algum problema com seu CEP, digite-o corretamente.');</script>)");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             
            DateTime auxinicInscri = DateTime.ParseExact(TextBoxInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime auxencInscri = DateTime.ParseExact(TextBoxEncerramento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime auxencComp = DateTime.ParseExact(TextBoxEnCompet.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime auxinicComp = DateTime.ParseExact(TextBoxData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan hora = TimeSpan.Parse(TextBoxHorario.Text);
            string inicInscri = auxinicInscri.ToString("yyyyMMdd");
            string encInscri = auxencInscri.ToString("yyyyMMdd");
            string encComp = auxencComp.ToString("yyyyMMdd");
            string inicComp = auxinicComp.ToString("yyyyMMdd");

            HttpPostedFile fotopostada = FileUpload1.PostedFile;
            int lenfotopostada = fotopostada.ContentLength;
            byte[] minhafoto = new byte[lenfotopostada];
            fotopostada.InputStream.Read(minhafoto, 0, lenfotopostada);
            string aux = Path.GetFileName(fotopostada.FileName);
            cmd.Parameters.AddWithValue("@infofoto", aux);
            FileStream novaimagem = new FileStream(Server.MapPath("~/ImagensSalvas/Competicao/" + aux), FileMode.Create);
            novaimagem.Write(minhafoto, 0, minhafoto.Length);
            novaimagem.Close();

            Competicao c = new Competicao(TextBoxNome.Text, TextBoxModal.Text, DropDownListGenero.SelectedItem.Text, TextBoxDesc.Text, Session["Login"].ToString(), aux, TextBoxRua.Text, TextBoxBairro.Text, TextBoxUF.Text, TextBoxCidade.Text, TextBoxCep.Text, TextBoxPontoReferencia.Text, int.Parse(TextBoxNumeroInscritos.Text), int.Parse(TextBoxNumero.Text), 0, hora, inicComp, encComp, inicInscri, encInscri, double.Parse(TextBoxValor.Text));
                c.Inserir_competicao();
                Response.Write("<script>window.alert('Você cadastrou sua competicao com sucesso! Algum de nossos adminstradores irá avaliá-la e retornaremos contato'); self.location='WebFormCompAbertDAO.aspx';</script>");
           // }
            //catch
           // {
                Response.Write("<script>window.alert('Você não conseguiu cadastrar sua competicao na plataforma, tente novamente!!'); self.location='WebFormRegistrarCompeticao.aspx';</script>");
           // }
        }
    }
}