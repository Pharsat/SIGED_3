﻿using System;
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
namespace SIGED_3.CRM.Web.Modulos.Proveedor
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Proveedor/Detalle.aspx") + "');return false;";
                new Genericos().ConfigurarPermisosLista(btnNuevo, btnEliminar, btnBuscar, gvPrincipal.Columns[1], (int)Modulo_Enum.Proveedores);
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
                    SIGED_3.CRM.Model.Negocio.Entidades.Proveedor objProveedor = new SIGED_3.CRM.Model.Negocio.Entidades.Proveedor();
                    objProveedor.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new ProveedorFachada().Eliminar(objProveedor);
                }
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                if ((bool)((LP_ProveedoresResult)e.Row.DataItem).Estado)
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Habilitado.png";
                }
                else
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Deshabilitado.png";
                }
                ((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_ProveedoresResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Proveedor/Detalle.aspx") + "');return false;";
            }
        }
    }
}