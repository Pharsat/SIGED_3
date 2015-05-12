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
    public partial class infInventario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
            rptViewer.Visible = true;
            rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\infInventario.rdlc";
            ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
            ReportDataSource ObjReport_2 = new ReportDataSource("dtsInventario", new InventarioFachada().Reporte_Inventario(SessionManager.Id_GrupoDeMiembros, (long?)long.Parse(cboBodega.SelectedValue)));
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(ObjReport_1);
            rptViewer.LocalReport.DataSources.Add(ObjReport_2);
            rptViewer.LocalReport.Refresh();
        }
    }
}