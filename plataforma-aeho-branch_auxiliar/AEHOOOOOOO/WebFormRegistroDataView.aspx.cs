using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AEHOOOOOOO
{
    public partial class WebFormRegistroDataView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                string codigo;

                int index = Convert.ToInt32(e.CommandArgument);

                codigo = GridView1.Rows[index].Cells[0].Text;

                Session["competicao_id"] = codigo;
                Response.Redirect("~\\WebFormRegistroDataViewEdit.aspx");
            }


        }
    }
}