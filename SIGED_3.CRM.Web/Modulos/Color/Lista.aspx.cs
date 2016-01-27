using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Negocio.Entidades;
using System.Web.UI.HtmlControls;
using SIGED_3.CRM.Web.MasterPage;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;
namespace SIGED_3.CRM.Web.Modulos.Color
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Color/Detalle.aspx") + "');return false;";
                new Genericos().ConfigurarPermisosLista(btnNuevo, btnEliminar, btnBuscar, gvPrincipal.Columns[1], (int)Modulo_Enum.Colores);
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
            bool NoEliminados = false;
            foreach (GridViewRow Row in gvPrincipal.Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    SIGED_3.CRM.Model.Negocio.Entidades.Color objColor = new SIGED_3.CRM.Model.Negocio.Entidades.Color();
                    objColor.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    if (!new FichaTecnica_ColorFachada().Existencia_PorColor(objColor.Id))
                    {
                        new ColorFachada().Eliminar(objColor);
                    }
                    else
                    {
                        NoEliminados = true;
                    }
                }
            }
            if (NoEliminados)
            {
                //ScriptManager.RegisterStartupScript((this.Master as Ppal).Expose_upLista, (this.Master as Ppal).Expose_upLista.GetType(), "CallMyFunction", "Mensaje('Eliminación parcial, algunos registros no fueron eliminados debido a que estan siendo usados en la aplicación.')", true);
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                if ((bool)((LP_ColoresResult)e.Row.DataItem).Estado)
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Habilitado.png";
                }
                else
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Deshabilitado.png";
                }
                ((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_ColoresResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Color/Detalle.aspx") + "');return false;";
                ((HtmlGenericControl)e.Row.FindControl("gcColor")).Attributes.Remove("style");
                if (((LP_ColoresResult)e.Row.DataItem).Color == "")
                {
                    ((HtmlGenericControl)e.Row.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: #fff;");
                }
                else
                {
                    ((HtmlGenericControl)e.Row.FindControl("gcColor")).Attributes.Add("style", "width: 99px; height: 19px; border: 1px solid #000; background-color: " + ((LP_ColoresResult)e.Row.DataItem).Color + ";");
                }
            }
        }
    }
}