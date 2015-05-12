using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;

namespace SIGED_3.CRM.Web.Modulos.Miembros
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Miembros/Detalle.aspx") + "');return false;";
                new Genericos().ConfigurarPermisosLista(btnNuevo, btnEliminar, btnBuscar, gvPrincipal.Columns[1], (int)Modulo_Enum.Miembros);
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
                    SIGED_3.CRM.Model.Negocio.Entidades.Miembro objCompra = new SIGED_3.CRM.Model.Negocio.Entidades.Miembro();
                    objCompra.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new MiembroFachada().Eliminar(objCompra);
                }
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                if (((LP_MiembrosResult)e.Row.DataItem).Cuenta.HasValue)
                {
                    ((ImageButton)e.Row.FindControl("imgSolicitarCuenta")).ImageUrl = "~/Recursos/Diseno/Iconos/Habilitado.png";
                    ((ImageButton)e.Row.FindControl("imgSolicitarCuenta")).OnClientClick = "return false;";
                }
                else if (((LP_MiembrosResult)e.Row.DataItem).CodigoDeActivacion.HasValue)
                {
                    ((ImageButton)e.Row.FindControl("imgSolicitarCuenta")).ImageUrl = "~/Recursos/Diseno/Iconos/Espera.png";
                    ((ImageButton)e.Row.FindControl("imgSolicitarCuenta")).OnClientClick = "return false;";
                }
                else
                {
                    ((ImageButton)e.Row.FindControl("imgSolicitarCuenta")).ImageUrl = "~/Recursos/Diseno/Iconos/Deshabilitado.png";
                }
                
                ((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_MiembrosResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Miembros/Detalle.aspx") + "');return false;";
                //((ImageButton)e.Row.FindControl("imgSolicitarCuenta")).CommandArgument = ((LP_MiembrosResult)e.Row.DataItem).Id.ToString();
            }
        }

        protected void imgSolicitarCuenta_Click(object sender, ImageClickEventArgs e)
        {
            CodigosDeActivacionFachada objCodigoDeActivacion = new CodigosDeActivacionFachada();
            objCodigoDeActivacion.GenerarCodigoCuenta(long.Parse(((ImageButton)sender).CommandArgument));

            gvPrincipal.DataBind();
        }
    }
}