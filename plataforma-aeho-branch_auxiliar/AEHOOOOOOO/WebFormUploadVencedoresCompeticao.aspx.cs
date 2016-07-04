using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sistema_Aeho;
using System.IO;

namespace AEHOOOOOOO
{
    public partial class WebFormUploadVencedoresCompeticao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipousuario"] == null || Session["tipousuario"].ToString() != "2")
            {
                Response.Write("<script>window.alert('Você não tem privilégios suficientes para acessar esta página. Sendo redirecionado para a página de competições abertas.'); self.location = 'WebFormCompAbertDAO.aspx';</script>)");
            }
            Label Label1 = Master.FindControl("titulo") as Label;
            Label Label2 = Master.FindControl("LabelUsuario") as Label;
            if (Session["tipousuario"] != null)
                Label2.Text = Session["Login"].ToString();
            Label1.Text = "Upload Vencedores da Competição";
            Competicao c = new Competicao();
            List<Competicao> listacompete = null;
            if (Session["tipousuario"] != null)
            {
                listacompete = c.Selecionar_suas_competicoes_encerradas(Session["Login"].ToString());
            }
            if (!IsPostBack)

            foreach (Competicao l in listacompete)
            {
                ListItem item = new ListItem(l.Nome, l.Id.ToString());
                DropDownList1.Items.Add(item);
            }
            preencher_gridview();

        }
        public void preencher_gridview()
        {
            Registro r = new Registro();
            GridView1.DataSource = r.atletas_inscritos(int.Parse(DropDownList1.SelectedValue));
            GridView1.DataBind();

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!(TextBox1.Text == TextBox2.Text || TextBox2.Text == TextBox3.Text || TextBox1.Text == TextBox3.Text))
            {
                Premiacao p = new Premiacao(new Registro(TextBox1.Text), new Competicao(int.Parse(DropDownList1.SelectedValue)), 1);
                Premiacao s = new Premiacao(new Registro(TextBox2.Text), new Competicao(int.Parse(DropDownList1.SelectedValue)), 2);
                Premiacao t = new Premiacao(new Registro(TextBox3.Text), new Competicao(int.Parse(DropDownList1.SelectedValue)), 3);
               try{
                    p.inserir_premiacao();
                    s.inserir_premiacao();
                    t.inserir_premiacao();
                    Response.Write("<script>window.alert('Premiações inseridas com sucesso!');</script>");
               }
               catch
               {
                   Response.Write("<script>window.alert('Ocorreu um erro ao inserir as premiações!');</script>");
               }
            }
            else Response.Write("<script>window.alert('Você tem o mesmo usuario ganhando duas ou mais medalhas, portanto, a operação não será realizada!'); </script>");

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "plugar")
            {
                TextBox1.Text = GridView1.Rows[index].Cells[1].Text;
            }
            if (e.CommandName == "slugar")
            {
                TextBox2.Text = GridView1.Rows[index].Cells[1].Text;
            }
            if (e.CommandName == "tlugar")
            {
                TextBox3.Text = GridView1.Rows[index].Cells[1].Text;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow r in GridView1.Rows)
            {
                if (r.Cells[0].Text.IndexOf(TextBox4.Text) < 0 && r.Cells[1].Text.IndexOf(TextBox4.Text) < 0)
                {
                    GridView1.Rows[r.RowIndex].Visible = false;
                }
            }
        }


    }
}