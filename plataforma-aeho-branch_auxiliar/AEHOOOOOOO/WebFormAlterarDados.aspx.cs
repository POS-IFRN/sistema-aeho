using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Aeho;
using System.Globalization;

namespace AEHOOOOOOO
{
    public partial class WebFormRegistrarOrganizador : System.Web.UI.Page
    {
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
            Label Labelt = Master.FindControl("titulo") as Label;
            Label Labelu = Master.FindControl("LabelUsuario") as Label;
            if (Session["Login"] != null)
            {
                Labelu.Text = Session["Login"].ToString();
            }
            Labelt.Text = "Alterar dados";
        }
        public void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Registro r = new Registro(Session["Login"].ToString());
                Registro k = r.selecionar_usuario();
                TextBoxNome.Text = k.Nome;
                TextBoxNascimento.Text = k.Nascimento;
                TextBoxRG.Text = k.Rg;
                TextBoxCPF.Text = k.Cpf;
                TextBoxCEP.Text = k.Cep;
                TextBoxRua.Text = k.Rua;
                TextBoxNumero.Text = k.Numero.ToString();
                TextBoxBairro.Text = k.Bairro;
                TextBoxCidade.Text = k.Cidade;
                TextBoxUF.Text = k.Uf;
                TextBoxComplemento.Text = k.Complemento;
                TextBoxEmail.Text = k.Email;
                Session["g"] = k.Genero;
                Session["pp"] = k.Foto_do_perfil;
            }

        }

        public void Button1_Click(object sender, EventArgs e)
        {
            DateTime AUXZILIAR = DateTime.ParseExact(TextBoxNascimento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string nascimento = AUXZILIAR.ToString("d");
            Registro r = new Registro(TextBoxNome.Text, nascimento, TextBoxRG.Text, TextBoxCPF.Text, Session["g"].ToString(), TextBoxEmail.Text, Session["Login"].ToString(), Session["s"].ToString(), Session["pp"].ToString(), TextBoxRua.Text, int.Parse(TextBoxNumero.Text), TextBoxBairro.Text, TextBoxUF.Text, TextBoxCidade.Text, TextBoxCEP.Text, TextBoxComplemento.Text, int.Parse(Session["tipousuario"].ToString()));
            try
            {
                r.Update_Usuario();
                Response.Write("<script>window.alert('Dados alterados com sucesso!'); self.location('WebFormCompAbertDAO.aspx')</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Dados não foram alterados devido a um erro desconhecido.'); self.location('WebFormCompAbertDAO.aspx')</script>");
            } 

                /*SqlCommand cmd = new SqlCommand("UPDATE [dbplataformaAEHO].[dbo].[Registro]   SET [nome] =@nome, [nascimento] =@nascimento, [rg] =@rg, [cpf] =@cpf, [email] =@email, [rua] =@rua, [numero] =@numero, [bairro] =@bairro, [uf] =@uf, [cidade] =@cidade, [cep] =@cep WHERE usuario =@usuario", conn);
                cmd.Parameters.AddWithValue("@nome", TextBoxNome.Text);
                cmd.Parameters.AddWithValue("@nascimento", TextBoxNascimento.Text);
                cmd.Parameters.AddWithValue("@rg", TextBoxRG.Text);
                cmd.Parameters.AddWithValue("@cpf", TextBoxCPF.Text);
                cmd.Parameters.AddWithValue("@cep", TextBoxCEP.Text);
                cmd.Parameters.AddWithValue("@rua", TextBoxRua.Text);
                cmd.Parameters.AddWithValue("@numero", TextBoxNumero.Text);
                cmd.Parameters.AddWithValue("@bairro", TextBoxBairro.Text);
                cmd.Parameters.AddWithValue("@cidade", TextBoxCidade.Text);
                cmd.Parameters.AddWithValue("@uf", TextBoxUF.Text);
                cmd.Parameters.AddWithValue("@email", TextBoxEmail.Text);
                cmd.Parameters.AddWithValue("@usuario", Session["Login"].ToString());
                cmd.ExecuteNonQuery();*/
 

        }
    }
}
    
