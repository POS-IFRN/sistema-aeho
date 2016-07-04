using Sistema_Aeho;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormEditarCompete : System.Web.UI.Page
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
                if (Session["tipousuario"].ToString() == "2")
                    Page.MasterPageFile = "~/MasterOrganizador.Master";
                else if (Session["tipousuario"].ToString() == "999")
                    Page.MasterPageFile = "~/MasterADM.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Editar Competição";
            if (!IsPostBack)
            {
                Competicao c = new Competicao(int.Parse(Session["Competicao_abrir"].ToString()));
                Competicao compete = c.selecionar_competicao(int.Parse(Session["Competicao_abrir"].ToString()), Session["Login"].ToString());
                TextBoxNome.Text = compete.Nome;
                TextBoxInicio.Text = compete.Inscricaoinicio;
                TextBoxEncerramento.Text = compete.Inscricaofim;
                TextBoxData.Text = compete.Competicaoinicio;
                TextBoxEnCompet.Text = compete.Competicaofim;
                TextBoxModal.Text = compete.Modalidade;
                TextBoxHorario.Text = compete.Horainicio.ToString();
                DropDownListGenero.SelectedValue = compete.Genero;
                TextBoxRua.Text = compete.Rua;
                TextBoxNumero.Text = compete.Numero.ToString();
                TextBoxBairro.Text = compete.Bairro;
                TextBoxCep.Text = compete.Cep;
                TextBoxPontoReferencia.Text = compete.Complemento;
                TextBoxCidade.Text = compete.Cidade;
                TextBoxUF.Text = compete.Uf;
                TextBoxValor.Text = compete.ValorInscricao.ToString();
                TextBoxDesc.Text = compete.Descricao;
                TextBoxNumeroInscritos.Text = compete.Maximoinscritos.ToString();

            }
        }

        public void Editar_Click(object sender, EventArgs e)
        {
            DateTime Ini = DateTime.ParseExact(TextBoxInicio.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string inicio = Ini.ToString("yyyyMMdd");

            DateTime enInscr = DateTime.ParseExact(TextBoxEncerramento.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string enIn = enInscr.ToString("yyyyMMdd");

            DateTime data = DateTime.ParseExact(TextBoxData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string Data = data.ToString("yyyyMMdd");

            DateTime ence = DateTime.ParseExact(TextBoxEnCompet.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string enEve = ence.ToString("yyyyMMdd");


            Competicao aux = new Competicao(int.Parse(Session["Competicao_abrir"].ToString()));
            aux.preencher_competicao();
            Competicao c = new Competicao(int.Parse(Session["Competicao_abrir"].ToString()), TextBoxNome.Text, TextBoxModal.Text, aux.Genero, TextBoxDesc.Text, Session["Login"].ToString(), aux.Foto_da_competicao, TextBoxRua.Text, TextBoxBairro.Text, TextBoxUF.Text, TextBoxCidade.Text, TextBoxCep.Text, TextBoxPontoReferencia.Text, int.Parse(TextBoxNumeroInscritos.Text), int.Parse(TextBoxNumero.Text), aux.Status_competicao, TimeSpan.Parse(TextBoxHorario.Text), Data, enEve, inicio, enIn, double.Parse(TextBoxValor.Text));
            c.Update_competicao();

        }
    }
}