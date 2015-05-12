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
    public partial class infVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
            rptViewer.Visible = true;
            rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\infVentas.rdlc";
            ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
            ReportDataSource ObjReport_2 = new ReportDataSource("dtsVenta", new VentaFachada().Informe_Ventas(SessionManager.Id_GrupoDeMiembros, dtDesde.SelectedDate, dtHasta.SelectedDate));
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(ObjReport_1);
            rptViewer.LocalReport.DataSources.Add(ObjReport_2);
            rptViewer.LocalReport.Refresh();
        }
    }
}