using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Enum;
namespace SIGED_3.CRM.Web.Modulos.Movimiento
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnEliminar.Visible = new PermisosFachada().PermisosDeUsuario((int)Modulo_Enum.Inventario).EliminarRegistro.Value;
                btnBuscar.Visible = new PermisosFachada().PermisosDeUsuario((int)Modulo_Enum.Inventario).ConsultarLista.Value;
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
                    SIGED_3.CRM.Model.Negocio.Entidades.EntradaOSalida objEntradaOSalida = new SIGED_3.CRM.Model.Negocio.Entidades.EntradaOSalida();
                    objEntradaOSalida.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new EntradaOSalidaFachada().Eliminar(objEntradaOSalida);
                }
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                switch(((LP_EntradasOSalidasResult)e.Row.DataItem).Movimiento)
                {
                    case "E":
                        ((Image)e.Row.FindControl("imgMovimiento")).ImageUrl = "~/Recursos/Diseno/Iconos/Entrada.png";
                        break;
                    case "S":
                        ((Image)e.Row.FindControl("imgMovimiento")).ImageUrl = "~/Recursos/Diseno/Iconos/Salida.png";
                        break;
                    default:
                        break;
                }
            }
        }
    }
}