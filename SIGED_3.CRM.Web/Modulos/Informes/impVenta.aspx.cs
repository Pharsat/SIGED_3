using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using SIGED_3.CRM.Model.Servicios.Fachadas;
using SIGED_3.CRM.Model.Util.Session;

namespace SIGED_3.CRM.Web.Modulos.Informes
{
    public partial class impVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                long Id_Venta = long.Parse(Request["Id"].ToString());
                rptViewer.Visible = true;
                rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\impVenta.rdlc";
                ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
                ReportDataSource ObjReport_2 = new ReportDataSource("dtsVenta", new VentaFachada().Impresion_Venta(Id_Venta));
                ReportDataSource ObjReport_3 = new ReportDataSource("dtsVentaDetalle", new VentaFachada().Impresion_Venta_Detalle(Id_Venta));
                rptViewer.LocalReport.DataSources.Clear();
                rptViewer.LocalReport.DataSources.Add(ObjReport_1);
                rptViewer.LocalReport.DataSources.Add(ObjReport_2);
                rptViewer.LocalReport.DataSources.Add(ObjReport_3);
                rptViewer.LocalReport.Refresh();
            }
        }
    }
}