using Sistema_Aeho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormVerSuasPremiacoes : System.Web.UI.Page
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
                if (Session["tipousuario"].ToString() == "1")
                    Page.MasterPageFile = "~/MasterAtleta.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            Label Label1 = Master.FindControl("titulo") as Label;
            Label1.Text = "Suas premiacões";
            Label Label2 = Master.FindControl("LabelUsuario") as Label;
            Premiacao p = new Premiacao();
            List<Premiacao> lista = new List<Premiacao>();
            try { 
                lista = p.totalMedalhas(Session["Login"].ToString());
            }
            catch
            {
                Response.Write("<script>window.alert('Ocorreu um erro nesta página')</script>");
            }
            //int i = 0;
            foreach (Premiacao o in lista)
            {
                Label label1 = new Label();
                Image img = new Image();
                img.Width = img.Height = 100;
                if (o.Tipo_medalha == 1)
                {
                    label1.Text = "Medalha de ouro em " + o.Competicao.Nome + "</br></br>";
                    img.ImageUrl = "fotos_premiacao/ouro.png";
                }
                else if (o.Tipo_medalha == 2)
                {
                    label1.Text = "Medalha de prata em " + o.Competicao.Nome + "</br></br>";
                    img.ImageUrl = "fotos_premiacao/prata.png";
                }
                else if (o.Tipo_medalha == 3)
                {
                    label1.Text = "Medalha de bronze em " + o.Competicao.Nome + "</br></br>";
                    img.ImageUrl = "fotos_premiacao/bronze.png";
                }

                label1.Font.Name = "verdana";
                label1.Font.Size = 20;

                TableCell newTablecell = new TableCell();
                newTablecell.Controls.Add(img);
                newTablecell.Controls.Add(label1);
                TableRow newTablerow = new TableRow();
                newTablerow.Controls.Add(newTablecell);
                Table1.Controls.Add(newTablerow);
            }
        }
    }
}