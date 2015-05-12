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

namespace SIGED_3.CRM.Web.Modulos.RolesXCuenta
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                new Genericos().ConfigurarPermisosLista(btnLigarARol, (int)Modulo_Enum.ConfiguracionDeRoles);
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

        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {

            }
        }

        protected void btnLigarARol_Click(object sender, ImageClickEventArgs e)
        {
            if (cboRoles.SelectedIndex > -1)
            {

                foreach (GridViewRow Row in gvPrincipal.Rows)
                {
                    if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                    {
                        Cuentas objCuenta = new CuentasFachada().Seleccionar_Id(long.Parse(((HiddenField)Row.FindControl("hdfId")).Value))[0];
                        objCuenta.Id_Rol = int.Parse(cboRoles.SelectedValue);
                        new CuentasFachada().Actualizar(objCuenta);
                    }
                }
                gvPrincipal.DataBind();
            }
        }
    }
}