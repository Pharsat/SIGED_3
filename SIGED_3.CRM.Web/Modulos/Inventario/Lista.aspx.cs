using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using SIGED_3.CRM.Model.Negocio.Entidades;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Web.MasterPage;
using SIGED_3.CRM.Model.Util.Genericos;
using SIGED_3.CRM.Model.Util.Enum;
namespace SIGED_3.CRM.Web.Modulos.Inventario
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Inventario/Detalle.aspx") + "');return false;";
                new Genericos().ConfigurarPermisosLista(null, btnEliminar, btnBuscar, null, (int)Modulo_Enum.Inventario);
                new Genericos().ConfigurarPermisosLista(btnDisminuirExistencia, (int)Modulo_Enum.Inventario);
                new Genericos().ConfigurarPermisosLista(btnAumentarExistencia, (int)Modulo_Enum.Inventario);
                new Genericos().ConfigurarPermisosLista(btnDisminuirStock, (int)Modulo_Enum.Inventario);
                new Genericos().ConfigurarPermisosLista(btnAumentarStock, (int)Modulo_Enum.Inventario);
                new Genericos().ConfigurarPermisosLista(btnRecargarInventario, (int)Modulo_Enum.Inventario);
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
                    SIGED_3.CRM.Model.Negocio.Entidades.Inventario objInventario = new SIGED_3.CRM.Model.Negocio.Entidades.Inventario();
                    objInventario.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new InventarioFachada().Eliminar(objInventario);
                }
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                if ((bool)((LP_InventarioResult)e.Row.DataItem).Estado)
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Habilitado.png";
                }
                else
                {
                    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Deshabilitado.png";
                }
                //((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_InventarioResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Inventario/Detalle.aspx") + "');return false;";
            }
        }
        protected void btnAumentarExistencia_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCantidad.Value != null)
            {
                bool Resultado = true;
                foreach (GridViewRow Row in gvPrincipal.Rows)
                {
                    if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                    {
                        bool RelParcial = new InventarioFachada().Mover_Cantidad(long.Parse(((HiddenField)Row.FindControl("hdfId")).Value), (decimal)txtCantidad.Value);
                        if (!RelParcial)
                        {
                            Resultado = false;
                        }
                    }
                }
                gvPrincipal.DataBind();
                if (!Resultado)
                {
                    ScriptManager.RegisterStartupScript((this.Master as Ppal).Expose_upLista, (this.Master as Ppal).Expose_upLista.GetType(), "CallMyFunction", "MensajeTres('No se han podido realizar uno o mas movimientos en inventario debido a restricciones de Stock.')", true);
                }
            }
        }
        protected void btnDisminuirExistencia_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCantidad.Value != null)
            {
                bool Resultado = true;
                foreach (GridViewRow Row in gvPrincipal.Rows)
                {
                    if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                    {
                        bool RelParcial = new InventarioFachada().Mover_Cantidad(long.Parse(((HiddenField)Row.FindControl("hdfId")).Value), -1 * (decimal)txtCantidad.Value);
                        if (!RelParcial)
                        {
                            Resultado = false;
                        }
                    }
                }
                gvPrincipal.DataBind();
                if (!Resultado)
                {
                    ScriptManager.RegisterStartupScript((this.Master as Ppal).Expose_upLista, (this.Master as Ppal).Expose_upLista.GetType(), "CallMyFunction", "MensajeTres('No se han podido realizar uno o mas movimientos en inventario debido a restricciones de Stock.')", true);
                }
            }
        }
        protected void btnDisminuirStock_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCantidad.Value != null)
            {
                bool Resultado = true;
                foreach (GridViewRow Row in gvPrincipal.Rows)
                {
                    if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                    {
                        bool RelParcial = new InventarioFachada().Mover_StockMinimo(long.Parse(((HiddenField)Row.FindControl("hdfId")).Value), (decimal)txtCantidad.Value);
                        if (!RelParcial)
                        {
                            Resultado = false;
                        }
                    }
                }
                gvPrincipal.DataBind();
                if (!Resultado)
                {
                    ScriptManager.RegisterStartupScript((this.Master as Ppal).Expose_upLista, (this.Master as Ppal).Expose_upLista.GetType(), "CallMyFunction", "MensajeTres('No se han podido realizar uno o mas movimientos en inventario debido a restricciones de Stock.')", true);
                }
            }
        }
        protected void btnAumentarStock_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCantidad.Value != null)
            {
                bool Resultado = true;
                foreach (GridViewRow Row in gvPrincipal.Rows)
                {
                    if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                    {
                        bool RelParcial = new InventarioFachada().Mover_StockMaximo(long.Parse(((HiddenField)Row.FindControl("hdfId")).Value), (decimal)txtCantidad.Value);
                        if (!RelParcial)
                        {
                            Resultado = false;
                        }
                    }
                }
                gvPrincipal.DataBind();
                if (!Resultado)
                {
                    ScriptManager.RegisterStartupScript((this.Master as Ppal).Expose_upLista, (this.Master as Ppal).Expose_upLista.GetType(), "CallMyFunction", "MensajeTres('No se han podido realizar uno o mas movimientos en inventario debido a restricciones de Stock.')", true);
                }
            }
        }
        protected void btnGenerarProductos(object sender, ImageClickEventArgs e)
        {
            new InventarioFachada().CompletarInventario();
            gvPrincipal.DataBind();
        }
        protected void cboBodegas_DataBound(object sender, EventArgs e)
        {
            cboBodegas.Items.Add(new RadComboBoxItem("[Ninguno]", (0).ToString()));
        }

        protected void btnMoverABodegaLosSeleccionados_Click(object sender, ImageClickEventArgs e)
        {
            if (txtCantidad.Value != null && cboBodegasAEnviar.SelectedValue != "0")
            {
                bool Resultado = true;
                foreach (GridViewRow Row in gvPrincipal.Rows)
                {
                    if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                    {
                        bool RelParcial = new InventarioFachada().Mover_En_Inventario(long.Parse(((HiddenField)Row.FindControl("hdfId")).Value), (decimal)txtCantidad.Value, long.Parse(cboBodegasAEnviar.SelectedValue));
                        if (!RelParcial)
                        {
                            Resultado = false;
                        }
                    }
                }
                gvPrincipal.DataBind();
                if (!Resultado)
                {
                    ScriptManager.RegisterStartupScript((this.Master as Ppal).Expose_upLista, (this.Master as Ppal).Expose_upLista.GetType(), "CallMyFunction", "MensajeTres('No se han podido realizar uno o mas movimientos en inventario debido a restricciones de Stock.')", true);
                }
            }
        }

        protected void btnCambiarEstado_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow Row in gvPrincipal.Rows)
            {
                if (((CheckBox)Row.FindControl("chkSeleccionarFila")).Checked)
                {
                    var inventarioManager = new InventarioFachada();

                    var inventario = inventarioManager.Seleccionar_Id(long.Parse(((HiddenField)Row.FindControl("hdfId")).Value));
                    inventario.Estado = !inventario.Estado;

                    inventarioManager.Actualizar(inventario);
                }
            }
            gvPrincipal.DataBind();
        }
    }
}