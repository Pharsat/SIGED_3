using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Session;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
namespace SIGED_3.CRM.Web.Modulos.Venta
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Venta/Detalle.aspx") + "');return false;";
                if (new ConsecutivosFachada().HayConsecutivo((long)Modulo_Enum.Ventas, SessionManager.Id_GrupoDeMiembros.Value))
                {
                    new Genericos().ConfigurarPermisosLista(btnNuevo, null, null, null, (int)Modulo_Enum.Ventas);
                }
                else
                {
                    btnNuevo.Visible = false;
                }
                new Genericos().ConfigurarPermisosLista(null, btnEliminar, btnBuscar, gvPrincipal.Columns[1], (int)Modulo_Enum.Ventas);
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
                    SIGED_3.CRM.Model.Negocio.Entidades.Venta objVenta = new SIGED_3.CRM.Model.Negocio.Entidades.Venta();
                    objVenta.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new VentaFachada().Eliminar(objVenta);
                }
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                ((ImageButton)e.Row.FindControl("imgImprimir")).OnClientClick = "javascript:openWin('" + ((LP_VentasResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Informes/impVenta.aspx") + "');return false;";
                ((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_VentasResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Venta/Detalle.aspx") + "');return false;";
            }
        }
    }
}