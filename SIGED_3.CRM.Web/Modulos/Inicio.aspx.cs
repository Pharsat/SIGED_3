using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Util.Session;
using System.Web.UI.HtmlControls;
using SIGED_3.CRM.Model.Util.Genericos;
namespace SIGED_3.CRM.Web.Modulos
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label objNombre = (Label)e.Row.FindControl("lblNombre");
                Label objRol = (Label)e.Row.FindControl("lblRol");
                Label objPublicacion = (Label)e.Row.FindControl("lblPublicacion");
                objPublicacion.Text = new Genericos().AgregarBRs(objPublicacion.Text);
            }
        }
    }
}