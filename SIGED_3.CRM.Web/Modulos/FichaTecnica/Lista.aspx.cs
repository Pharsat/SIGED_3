using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
namespace SIGED_3.CRM.Web.Modulos.FichaTecnica
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/FichaTecnica/Detalle.aspx") + "');return false;";
                new Genericos().ConfigurarPermisosLista(btnNuevo, btnEliminar, btnBuscar, gvPrincipal.Columns[1], (int)Modulo_Enum.FichaTecnica);
            }
            if (Page.Request.Params["__EVENTTARGET"] == "recargarPagina")
            {
                gvPrincipal.DataBind();
            }
        }
        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            gvPrincipal.DataBind();
        }
        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in gvPrincipal.Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica objFichaTecnica = new SIGED_3.CRM.Model.Negocio.Entidades.FichaTecnica();
                    objFichaTecnica.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new FichaTecnicaFachada().Eliminar(objFichaTecnica);
                }
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                ((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_FichasTecnicasResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/FichaTecnica/Detalle.aspx") + "');return false;";
                ((ImageButton)e.Row.FindControl("imgImprimir")).OnClientClick = "javascript:openWin('" + ((LP_FichasTecnicasResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Informes/impFichaTecnica.aspx") + "');return false;";
            }
        }
    }
}