using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Web.MasterPage;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
namespace SIGED_3.CRM.Web.Modulos.ProcesoDeFabricacion
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/ProcesoDeFabricacion/Detalle.aspx") + "');return false;";
                new Genericos().ConfigurarPermisosLista(btnNuevo, btnEliminar, btnBuscar, gvPrincipal.Columns[1], (int)Modulo_Enum.Procesos);
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
            bool Existen = false;
            foreach (GridViewRow Row in gvPrincipal.Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    if (!new ProcesoDeFabricacionFachada().AnalizarRegistrosVinculados(int.Parse(((HiddenField)Row.FindControl("hdfId")).Value)))
                    {
                        SIGED_3.CRM.Model.Negocio.Entidades.ProcesoDeFabricacion objProcesoDeFabricacion = new SIGED_3.CRM.Model.Negocio.Entidades.ProcesoDeFabricacion();
                        objProcesoDeFabricacion.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                        new ProcesoDeFabricacionFachada().Eliminar(objProcesoDeFabricacion);
                    }
                    else
                    {
                        Existen = true;
                    }
                }
            }
            if (Existen)
            {
                //ScriptManager.RegisterStartupScript((this.Master as Ppal).Expose_upLista, (this.Master as Ppal).Expose_upLista.GetType(), "CallMyFunction", "MensajeTres('Uno o mas elementos a eliminar no pudieron ser elimindos ya que estan siendo usados por el sistema.')", true);
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                if ((bool)((LP_ProcesosDeFabricacionResult)e.Row.DataItem).Estado)
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Habilitado.png";
                }
                else
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Deshabilitado.png";
                }
                ((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_ProcesosDeFabricacionResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/ProcesoDeFabricacion/Detalle.aspx") + "');return false;";
                ((Label)e.Row.FindControl("lblDescripcion")).Text = ((LP_ProcesosDeFabricacionResult)e.Row.DataItem).Descripcion.Replace("\r\n", "<br />");
            }
        }
    }
}