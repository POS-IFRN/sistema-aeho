using Sistema_Aeho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace AEHOOOOOOO
{
    public partial class WebFormVerPerfil : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Perfil";
            Label Label2 = Master.FindControl("LabelUsuario") as Label;
            Label2.Text = Session["Login"].ToString();

            CultureInfo arSA = new CultureInfo("pt-BR");
            Registro usuario = new Registro();
            usuario = usuario.RegAtleta(Session["Login"].ToString())[0];

            ImagePerfil.ImageUrl = "~/ImagensSalvas/Usuario/" + usuario.Foto_do_perfil;
            ImagePerfil.Width = 350;
            ImagePerfil.Height = 250;

            LabelNome.Text = LabelNome.Text + usuario.Nome;
            LabelNascimento.Text += usuario.Nascimento;
            LabelRg.Text += usuario.Rg;
            LabelCPF.Text += usuario.Cpf;
            LabelGenero.Text += usuario.Genero;
            LabelEmail.Text += usuario.Email;
            LabelUsuario.Text += usuario.Usuario;
            LabelRua.Text += usuario.Rua;
            LabelNumero.Text += usuario.Numero;
            LabelBairro.Text += usuario.Bairro;
            LabelUF.Text += usuario.Uf;
            LabelCidade.Text += usuario.Cidade;
            LabelCEP.Text += usuario.Cep;
            LabelComplemento.Text += usuario.Complemento;
            LabelPrivilegio.Text += usuario.Privilegio;
            
            


        }
    }
}