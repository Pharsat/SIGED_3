using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SIGED_3.CRM.Web.Modulos.Informes
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnCompras.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infCompras.aspx") + "');return false;";
            btnPedidos.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infPedidos.aspx") + "');return false;";
            btnPlanCompras.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infPlanDeCompras.aspx") + "');return false;";
            btnDespachos.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infOrdenesDeTrabajo.aspx") + "');return false;";
            btnCostos.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infCostos.aspx") + "');return false;";
            btnInventario.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infInventario.aspx") + "');return false;";
            btnVentas.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infVentas.aspx") + "');return false;";
            btnUtilidad.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infUtilidades.aspx") + "');return false;";
            btnListaPrecios.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infLista_Precios.aspx") + "');return false;";
            btnListaPreciosCliente.OnClientClick = "javascript:openWin('0','" + ResolveUrl("~/Modulos/Informes/infLista_Precios_2.aspx") + "');return false;";
            
        }
    }
}