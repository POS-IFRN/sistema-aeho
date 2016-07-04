using Sistema_Aeho;
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
    public partial class WebFormCompDAO : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["tipousuario"] != null)
            {
                if (Session["tipousuario"].ToString() == "1")
                    Page.MasterPageFile = "~/MasterAtleta.Master";
                else if (Session["tipousuario"].ToString() == "2")
                    Page.MasterPageFile = "~/MasterOrganizador.master";
                else if (Session["tipousuario"].ToString() == "999")
                    Page.MasterPageFile = "~/MasterADM.Master";
            }

        }
        protected void b_Click(object sender, EventArgs e)
        {
            Registro r = new Registro(Session["Login"].ToString());
            r = r.selecionar_usuario();
            Competicao c = new Competicao(int.Parse(Session["Competicao_abrir"].ToString()));
            c.preencher_competicao();
            if (c.pegar_qtd_inscritos() < c.Maximoinscritos && (r.Genero == c.Genero || c.Genero.Length > 9))
            {
                try { 
                    c.InscreverSeEm_Competicao(r);
                    Response.Write("<script>window.alert('Você se inscreveu com sucesso na competição!'); self.location='WebFormCompDAO.aspx';</script>");
                }
                catch { Response.Write("<script>window.alert('Você já está inscrito para esta competição!'); self.location='WebFormCompDAO.aspx';</script>"); }
            }
            else if (c.pegar_qtd_inscritos() >= c.Maximoinscritos) Response.Write("<script>window.alert('A competição já atingiu o número máximo de inscritos, tente novamente na próxima edição(se houver)!'); self.location='WebFormCompDAO.aspx';</script>");
            else Response.Write("<script>window.alert('Você não atende aos requisitos de gênero para esta competição!'); self.location='WebFormCompDAO.aspx';</script>");

        }

        protected void cancelar_inscricao_Click(object sender, EventArgs e)
        {
            Premiacao prem = new Premiacao(new Registro(Session["Login"].ToString()), new Competicao(int.Parse(Session["Competicao_abrir"].ToString())));
            try
            {
                prem.Cancelar_inscricao_Competicao();
                Response.Write("<script>window.alert('Você cancelou sua inscrição com sucesso nessa competição!'); self.location='WebFormCompDAO.aspx';</script>");
            }
            catch 
            {
                Response.Write("<script>window.alert('Você não cancelou sua inscrição para esta competição!'); self.location='WebFormCompDAO.aspx';</script>");
            }
        }
        protected void validar_Click(object sender, EventArgs e)
        {
            Competicao c = new Competicao(int.Parse(Session["Competicao_abrir"].ToString()));
            try
            {
                c.validar_competicao();
                Response.Write("<script>window.alert('Competição validada com sucesso!'); self.location = 'WebFormCompAbertDAO.aspx';</script>");
            }
            catch
            {
                Response.Write("<script>window.alert('Ocorreu um erro ao validar a competição!'); self.location = 'WebFormCompAbertDAO.aspx';</script>");
            }
        }
        public void Deletar_Click(object sender, EventArgs e)
        {
            Competicao c = new Competicao();
            Competicao l = c.CompeticaoIndi(int.Parse(Session["Competicao_abrir"].ToString()));
            try 
            { 
                l.Delete_Competicao(l.Id);
                Response.Write("<script>window.alert('Competição deletada com sucesso! Você será redirecionado para a página de competições abertas.'); self.location='WebFormCompAbertDAO.aspx';</script>");
            }
            catch 
            {
                Response.Write("<script>window.alert('Ocorreu um erro ao deletar a competição!');</script>");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label Labelt = Master.FindControl("titulo") as Label;
            Label Labelu = Master.FindControl("LabelUsuario") as Label;
            Premiacao prem = new Premiacao();
            if (Session["Login"] != null)
            {
                Labelu.Text = Session["Login"].ToString();
                prem = new Premiacao(new Registro(Session["Login"].ToString()), new Competicao(int.Parse(Session["Competicao_abrir"].ToString())));
            }
            Competicao c = new Competicao();
            Competicao l = c.CompeticaoIndi(int.Parse(Session["Competicao_abrir"].ToString()));

            Registro organizador = new Registro(l.Organizador_usuario);
            organizador.selecionar_usuario();

            Labelt.Text = "Competição: " + l.Nome;
            string st = string.Empty;
            Label2.Text = l.Nome;
            Label2.Font.Name = "verdana";
            Label2.Font.Size = 20;
            if (l.Status_competicao == 0) st = "Não validada";
            else if (l.Status_competicao == 1) st = "Validada";
            else if (l.Status_competicao == 3) st = "Encerrada";
            Label1.Text = "</br></br> Descricao: " + l.Descricao + " </br> Modalidade:" + l.Modalidade + " </br> Status da Competicao: " + st + " </br> Data de início das inscrições: " + l.Inscricaoinicio + " </br> Data de término das inscrições: " + l.Inscricaofim + " </br Data da competição: " + l.Competicaoinicio + " </br> Hora de início da competição: " + l.Horainicio + " </br> Dia de término da competição: " + l.Competicaofim + " </br> Nome do organizador: " + organizador.Nome + " </br> Quantidade máxima de inscritos: " + l.Maximoinscritos + " </br> Valor da inscrição: " + l.ValorInscricao;
            Label1.Font.Name = "verdana";
            Image1.ImageUrl = "~/ImagensSalvas/Competicao/" + l.Foto_da_competicao.ToString();
            Image1.Width = 250;
            Image1.Height = 250;
            Label3.Font.Name = "verdana";
            Label3.Text = "<br />Endereço da competição<br />Rua: " + l.Rua + "<br />Complemento: " + l.Complemento + "<br />Número: " + l.Numero + "<br />Bairro: " + l.Bairro + "<br />CEP: " + l.Cep + "<br />Cidade: " + l.Cidade + "<br />Estado: " + l.Uf + "<br /><br />";

            if (Session["Login"] != null)
            {
                if (l.Status_competicao.ToString() == "1" && Session["tipousuario"].ToString() == "1" && !prem.esta_inscrito())
                {
                    Button b = new Button();
                    b.CssClass = "ls-btn";
                    b.Text = "Inscrever-se";
                    b.Click += b_Click;
                    Panel1.Controls.Add(b);
                }
                if (l.Status_competicao.ToString() == "1" && Session["tipousuario"].ToString() == "1" && prem.esta_inscrito())
                {
                    Button cancelar = new Button();
                    cancelar.CssClass = "ls-btn";
                    cancelar.Text = "Cancelar inscrição";
                    cancelar.Click += cancelar_inscricao_Click;
                    Panel1.Controls.Add(cancelar);
                }
                if (l.Status_competicao.ToString() == "0" && Session["tipousuario"].ToString() == "999")
                {
                    Button validar = new Button();
                    Button mensagem = new Button();
                    validar.CssClass = "ls-btn";
                    mensagem.CssClass = "ls-btn";
                    validar.Text = "Validar competição";
                    validar.Click += validar_Click;
                    mensagem.Text = "Enviar mensagem ao organizador";
                    mensagem.Attributes.Add("onclick", "window.open('WebFormMensagem.aspx?rid=" + l.Organizador_usuario + "&cid=" + l.Id.ToString() + "', " + " 'Envio de mensagem ao organizador', 'height=500px, width=500px')");
                    Panel1.Controls.Add(validar);
                    Panel1.Controls.Add(mensagem);
                    List<Mensagem> lista;
                    Mensagem mens = new Mensagem();
                    if (mens.existe_mensagem_competicao(Convert.ToInt16(Session["Competicao_abrir"])))
                    {
                        Label4.Visible = true;
                        lista = mens.selec_mensagem_comp(Convert.ToInt16(Session["Competicao_abrir"]));
                        foreach (Mensagem mensg in lista)
                        {
                            TableCell tc = new TableCell();
                            Label textinho = new Label();
                            textinho.Text = "Enviada por: " + mensg.Registro_remetente + "<br /> Mensagem: " + mensg.Mensagem_conteudo + "<br /> Data de envio: " + mensg.Data_envio;
                            TableRow tr = new TableRow();
                            tc.Controls.Add(textinho);
                            tr.Controls.Add(tc);
                            TableMensagens.Rows.Add(tr);
                        }
                    }
                    
                }

                if (Session["tipousuario"].ToString() == "2" && l.Organizador_usuario.ToString() == Session["Login"].ToString() && l.Status_competicao == 1)
                {
                    Button Editar = new Button();
                    Button Deletar = new Button();
                    Registro r = new Registro();
                    Button2.Visible = TextBox4.Visible = Label5.Visible =true;
                    GridView2.DataSource = r.atletas_inscritos(int.Parse(Session["Competicao_abrir"].ToString()));
                    GridView2.DataBind();
                    Editar.CssClass = "ls-btn";
                    Deletar.CssClass = "ls-btn";
                    Editar.PostBackUrl = "~/WebFormEditarCompete.aspx";
                    Editar.Text = "Editar competição";
                    Deletar.Text = "Deletar Competicão";
                    Deletar.Click += Deletar_Click;
                    Panel1.Controls.Add(Editar);
                    Panel1.Controls.Add(Deletar);
                }

                if (Session["tipousuario"].ToString() != "1" && Session["tipousuario"].ToString() != "2" && Session["tipousuario"].ToString() != "null")
                {
                    Button Deletar = new Button();
                    Deletar.CssClass = "ls-btn";
                    Deletar.Text = "Deletar Competicão";
                    Deletar.Click += Deletar_Click;
                    Panel1.Controls.Add(Deletar);
                }

            }
            if (l.Status_competicao.ToString() == "3")
            {
                string z = "";
                Premiacao k = new Premiacao();
                k.Competicao = new Competicao(l.Id);
                List<Premiacao> lista = k.selecionar_vencedores();
                foreach (Premiacao a in lista)
                {
                    z += "Atleta: " + a.Atleta.Nome + "<br />Recebeu medalha de ";
                    if (a.Tipo_medalha == 1) z += "ouro. <br />";
                    else if (a.Tipo_medalha == 2) z += "prata. <br />";
                    else if (a.Tipo_medalha == 3) z += "bronze. <br />";
                }
                LabelVencedores.Text = z;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow r in GridView2.Rows)
            {
                if (r.Cells[0].Text.IndexOf(TextBox4.Text) < 0 && r.Cells[1].Text.IndexOf(TextBox4.Text) < 0 && r.Cells[2].Text.IndexOf(TextBox4.Text) < 0)
                {
                    GridView2.Rows[r.RowIndex].Visible = false;
                }
            }
        }



        }
    }
