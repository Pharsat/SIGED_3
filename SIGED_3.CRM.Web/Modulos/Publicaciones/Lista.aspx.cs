﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Enum;
using SIGED_3.CRM.Model.Util.Genericos;

namespace SIGED_3.CRM.Web.Modulos.Publicaciones
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Publicaciones/Detalle.aspx") + "');return false;";
                new Genericos().ConfigurarPermisosLista(btnNuevo, btnEliminar, btnBuscar, gvPrincipal.Columns[1], (int)Modulo_Enum.Publicaciones);
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
                    SIGED_3.CRM.Model.Negocio.Entidades.Publicaciones objPublicaciones = new SIGED_3.CRM.Model.Negocio.Entidades.Publicaciones();
                    objPublicaciones.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new PublicacionesFachada().Eliminar(objPublicaciones);
                }
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                ((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_PublicacionesResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Publicaciones/Detalle.aspx") + "');return false;";
            }
        }
    }
}