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
    public partial class infPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnGenerar_Click(object sender, ImageClickEventArgs e)
        {
            rptViewer.Visible = true;
            rptViewer.LocalReport.ReportPath = "Modulos\\Informes\\infPedidos.rdlc";
            ReportDataSource ObjReport_1 = new ReportDataSource("dtsGrupo", new GrupoDeMiembrosFachada().RelatorioGrupo_Tabla(SessionManager.Id_GrupoDeMiembros));
            ReportDataSource ObjReport_2 = new ReportDataSource("dtsPedidos", new PedidoFachada().RelatorioDePedidos((long?)txtConsecutivo.Value, SessionManager.Id_GrupoDeMiembros));
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(ObjReport_1);
            rptViewer.LocalReport.DataSources.Add(ObjReport_2);
            rptViewer.LocalReport.Refresh();
        }
    }
}