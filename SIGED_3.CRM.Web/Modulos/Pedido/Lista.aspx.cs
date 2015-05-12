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
using SIGED_3.CRM.Model.Util.Session;
using Telerik.Web.UI;
namespace SIGED_3.CRM.Web.Modulos.Pedido
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnNuevo.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Pedido/Detalle.aspx") + "');return false;";
                if (new ConsecutivosFachada().HayConsecutivo((long)Modulo_Enum.Pedidos, SessionManager.Id_GrupoDeMiembros.Value))
                {
                    new Genericos().ConfigurarPermisosLista(btnNuevo, null, null, null, (int)Modulo_Enum.Pedidos);
                }
                else
                {
                    btnNuevo.Visible = false;
                }
                new Genericos().ConfigurarPermisosLista(null, btnEliminar, btnBuscar, gvPrincipal.Columns[1], (int)Modulo_Enum.Pedidos);
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
                    SIGED_3.CRM.Model.Negocio.Entidades.Pedido objPedido = new SIGED_3.CRM.Model.Negocio.Entidades.Pedido();
                    objPedido.Id = long.Parse(((HiddenField)Row.FindControl("hdfId")).Value);
                    new PedidoFachada().Eliminar(objPedido);
                }
            }
            gvPrincipal.DataBind();
        }
        protected void gvPrincipal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                //if ((bool)((LP_PedidosResult)e.Row.DataItem).Estado)
                //{
                //    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Habilitado.png";
                //}
                //else
                //{
                //    ((Image)e.Row.FindControl("imgEstado")).ImageUrl = "~/Recursos/Diseno/Iconos/Deshabilitado.png";
                //}
                ((ImageButton)e.Row.FindControl("imgEditar")).OnClientClick = "javascript:openWin('" + ((LP_PedidosResult)e.Row.DataItem).Id.ToString() + "','" + ResolveUrl("~/Modulos/Pedido/Detalle.aspx") + "');return false;";
            }
        }

        protected void cboClientes_DataBound(object sender, EventArgs e)
        {
            cboClientes.Items.Add(new RadComboBoxItem("[Ninguno]", (0).ToString()));
        }
    }
}